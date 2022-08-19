using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TTMapi.Models
{
    public class Tag
    {
        private string t_id { get; set; }
        private string t_category { get; set; }
        private string t_tagName { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {
            get => t_id;
            set => t_id = value;
        }
        public string category
        {
            get => t_category;
            set => t_category = value;
        }
        public string tagName
        {
            get => t_tagName;
            set => t_tagName = value;
        }
    }
}