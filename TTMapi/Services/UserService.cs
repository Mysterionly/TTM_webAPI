using TTMapi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Security.Claims;

namespace TTMapi.Services
{
    public class Authenticator
    {
        public string Secret { get; set; }
    }

    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        private readonly Authenticator auth;

        public UserService(TTMDBSettings settings, Authenticator auth)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UserCollectionName);
            this.auth = auth;
        }

        public string GetToken(string id)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(auth.Secret));
            var signInCredentials = new SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);
            var claims = new List<Claim>();
            claims.Add(new Claim("Id", id));
            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signInCredentials, 
                claims: claims
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public List<User> Get()
        {
            List<TTMapi.Models.User> bap = _users.Find(User => true).ToList();
            return bap;
        }

        public User Get(string id) =>
            _users.Find<User>(User => User.Id == id).FirstOrDefault();

        public string GetByGid(string gid)
        {
            User u = _users.Find<User>(User => User.googleId == gid).FirstOrDefault();
            if (u != null) return u.Id;
            else return null;
        }

        public User Create(User User)
        {
            _users.InsertOne(User);
            return User;
        }

        public void Update(string id, User UserIn) =>
            _users.ReplaceOne(User => User.Id == id, UserIn);

        public void Remove(User UserIn) =>
            _users.DeleteOne(User => User.Id == UserIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(User => User.Id == id);
    }
}