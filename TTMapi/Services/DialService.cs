using TTMapi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Bson;

namespace TTMapi.Services
{
    public class DialService
    {
        private readonly IMongoCollection<Dial> _dials;
        private readonly IMongoCollection<DialMsg> _msgs;

        public DialService(TTMDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dials = database.GetCollection<Dial>(settings.DialCollectionName);
            _msgs = database.GetCollection<DialMsg>(settings.MsgCollectionName);
        }

        public List<Dial> Get()
        {
            List<TTMapi.Models.Dial> bap = _dials.Find(Dial => true).ToList();
            return bap;
        }
        public Dial GetByTag(string tag, string uid)
        {
            List<TTMapi.Models.Dial> bap = _dials.Find(c => c.user1.uid != uid && c.user2 == null && c.tagList[0] == tag).ToList();
            if (bap.Count > 0)
                return bap[0];
            else
                return null;
        }

        public Dial Get(string id) =>
            _dials.Find<Dial>(Dial => Dial.Id == id).FirstOrDefault();

        public Dial Create(Dial Dial)
        {
            _dials.InsertOne(Dial);
            return Dial;
        }
        public DialMsg newDialMsg(DialMsg msg)
        {
            _msgs.InsertOne(msg);
            return msg;
        }

        public void Update(string id, Dial DialIn) =>
            _dials.ReplaceOne(Dial => Dial.Id == id, DialIn);

        public void Remove(Dial DialIn) =>
            _dials.DeleteOne(Dial => Dial.Id == DialIn.Id);

        public void Remove(string id) =>
            _dials.DeleteOne(Dial => Dial.Id == id);
    }
}