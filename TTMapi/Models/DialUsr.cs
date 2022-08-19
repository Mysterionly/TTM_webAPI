namespace TTMapi.Models
{
    public class DialUsr
    {
        private string du_id; //{ get; set; }
        private string du_nname; //{ get; set; }
        private LetterStyle du_letterStyle; //{ get; set; }

        public string uid
        {
            get => du_id;
            set => du_id = value;
        }
        public string nickName
        {
            get => du_nname;
            set => du_nname = value;
        }
        public LetterStyle letterStyle
        {
            get => du_letterStyle;
            set => du_letterStyle = value;
        }
        public DialUsr(string du_id_, string nickName_)
        {
            du_id = du_id_;
            nickName = nickName_;
        }
    }
}