using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TTMapi.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }
}