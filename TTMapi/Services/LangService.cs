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
    public class LangService
    {
        private readonly IMongoCollection<Language> _langs;

        public LangService(TTMDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _langs = database.GetCollection<Language>(settings.LangCollectionName);
        }

        public List<Language> Get()
        {
            List<Language> bap = _langs.Find(TagCat => true).ToList();
            return bap;
        }
    }
}