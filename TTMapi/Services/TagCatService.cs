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
    public class TagCatService
    {
        private readonly IMongoCollection<TagCat> _cats;

        public TagCatService(TTMDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cats = database.GetCollection<TagCat>(settings.TagCatCollectionName);
        }

        public List<TagCat> Get()
        {
            List<TagCat> bap = _cats.Find(TagCat => true).ToList();
            return bap;
        }
    }
}