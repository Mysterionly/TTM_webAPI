using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TTMapi.Models
{
    public class DialMsg
    {
        //public string m_msg_id { get; set; }
        private string m_dial_id { get; set; }
        private string m_user_id { get; set; }

        private DateTime m_time { get; set; }
        private string m_text { get; set; }
        private bool m_readen { get; set; }

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string msg_id
        //{
        //    get => m_msg_id;
        //    set => m_msg_id = value;
        //}
        public string dial_id
        {
            get => m_dial_id;
            set => m_dial_id = value;
        }
        public string user_id
        {
            get => m_user_id;
            set => m_user_id = value;
        }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime time
        {
            get => m_time;
            set => m_time = value;
        }
        public string text
        {
            get => m_text;
            set => m_text = value;
        }
        public bool readen
        {
            get => m_readen;
            set => m_readen = value;
        }

        public DialMsg(string m_dial_id_, string m_user_id_, DateTime time_, string text_)
        {
            m_dial_id = m_dial_id_;
            m_user_id = m_user_id_;
            m_time = time_;
            m_text = text_;
            m_readen = false;
        }
    }
}