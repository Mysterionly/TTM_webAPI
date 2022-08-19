using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TTMapi.Models
{
    public class DialCmd : Dial
    {
        public string command;

        public DialCmd(string cmd, string Id, string title, bool priv, string language, string[] tagList, DialUsr user1, DialUsr user2) : base(Id, title, priv, language, tagList, user1, user2, "testTag")
        {
            command = cmd;
        }
    }

    public class Dial
    {
        private string d_Id { get; set; }
        
        private string d_title { get; set; }
        private bool d_priv { get; set; }
        private string d_language { get; set; }
        private string[] d_tagList { get; set; }
        private DialUsr d_user1;// { get; set; }
        private DialUsr d_user2;// { get; set; }
        private Item[] itemList;// { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {
            get => d_Id;
            set => d_Id = value;
        }
        public string title
        {
            get => d_title;
            set => d_title = value;
        }
        public bool priv
        {
            get => d_priv;
            set => d_priv = value;
        }
        public string language
        {
            get => d_language;
            set => d_language = value;
        }
        public string[] tagList
        {
            get => d_tagList;
            set => d_tagList = value;
        }
        public DialUsr user1
        {
            get => d_user1;
            set => d_user1 = value;
        }
        public DialUsr user2
        {
            get => d_user2;
            set => d_user2 = value;
        }

        public Dial(string Id, string title, bool priv, string language, string[] tagList, DialUsr user1, DialUsr user2, string tag)
        {
            d_Id = Id;
            d_title = title;
            d_priv = priv;
            d_language = language;
            d_tagList = tagList;
            d_user1 = user1;
            d_user2 = user2;
            d_tagList = new string[1];
            d_tagList[0] = tag;
        }
    }
}