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
    public class TagService
    {
        private readonly IMongoCollection<Models.Tag> _tags;

        public TagService(TTMDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tags = database.GetCollection<Models.Tag>(settings.TagCollectionName);
        }

        public List<Models.Tag> Get()
        {
            List<Models.Tag> bap = _tags.Find(Tag => true).ToList();
            return bap;
        }
    }
}