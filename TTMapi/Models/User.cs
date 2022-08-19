using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TTMapi.Models
{

    public class UserCmd : User
    {
        public string command;

        public UserCmd(string cmd, string id, string uN, string gid, string pass, string email, string[] lL, string[] tL, string[] iL, string[] bL) : base(id, uN, gid, pass, email, lL, tL, iL, bL)
        {
            command = cmd;
        }
    }

    public class User
    {
        private string u_Id;// { get; set; }

        //[BsonElement("Name")]
        private string u_userName;// { get; set; }
        private string u_googleId;// { get; set; }
        private string u_password;// { get; set; }
        private string u_email;// { get; set; }

        private string[] u_langList;// { get; set; }
        private string[] u_tagList;// { get; set; }
        private string[] u_itemList;// { get; set; }
        private string[] u_blockedList;// { get; set; }


        public User(string id, string uN, string gid, string pass, string email, string[] lL, string[] tL, string[] iL, string[] bL)
        {
            u_Id = id;
            u_userName = uN;
            u_googleId = gid;
            u_password = pass;
            u_email = email;
            u_langList = lL;
            u_tagList = tL;
            u_itemList = iL;
            u_blockedList = bL;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {
            get => u_Id;
            set => u_Id = value;
        }
        public string userName
        {
            get => u_userName;
            set => u_userName = value;
        }
        public string googleId
        {
            get => u_googleId;
            set => u_googleId = value;
        }
        public string password
        {
            get => u_password;
            set => u_password = value;
        }
        public string email
        {
            get => u_email;
            set => u_email = value;
        }
        public string[] langList
        {
            get => u_langList;
            set => u_langList = value;
        }
        public string[] tagList
        {
            get => u_tagList;
            set => u_tagList = value;
        }
        public string[] itemList
        {
            get => u_itemList;
            set => u_itemList = value;
        }
        public string[] blockedList
        {
            get => u_blockedList;
            set => u_blockedList = value;
        }
    }
}