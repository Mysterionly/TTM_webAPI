using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TTMapi.Models
{
    public class TagCat
    {
        private string tc_id { get; set; }
        private string tc_catName { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {
            get => tc_id;
            set => tc_id = value;
        }
        public string catName
        {
            get => tc_catName;
            set => tc_catName = value;
        }
    }
}