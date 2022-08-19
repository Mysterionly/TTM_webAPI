using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TTMapi.Models
{
    public class Language
    {
        private string l_id { get; set; }
        private string l_lang { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {
            get => l_id;
            set => l_id = value;
        }
        public string lang
        {
            get => l_lang;
            set => l_lang = value;
        }
    }
}