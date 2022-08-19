using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TTMapi.Models
{

    public class LetterStyle
    {
        private string ls_penStyle;// { get; set; }
        private string ls_paperStyle;// { get; set; }

        public string penStyle
        {
            get => ls_penStyle;
            set => ls_penStyle = value;
        }
        public string paperStyle
        {
            get => ls_paperStyle;
            set => ls_paperStyle = value;
        }

        public LetterStyle()
        {

        }
    }
}