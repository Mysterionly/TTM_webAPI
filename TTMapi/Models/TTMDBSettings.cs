namespace TTMapi.Models
{
    public interface ITTMDBSettings
    {
        string UserCollectionName { get; set; }
        string DialCollectionName { get; set; }
        string MsgCollectionName { get; set; }
        string ItemCollectionName { get; set; }
        string TagCatCollectionName { get; set; }
        string TagCollectionName { get; set; }
        string LangCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class TTMDBSettings : ITTMDBSettings
    {
        public string UserCollectionName { get; set; }
        public string DialCollectionName { get; set; }
        public string MsgCollectionName { get; set; }
        public string ItemCollectionName { get; set; }
        public string TagCatCollectionName { get; set; }
        public string TagCollectionName { get; set; }
        public string LangCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

}