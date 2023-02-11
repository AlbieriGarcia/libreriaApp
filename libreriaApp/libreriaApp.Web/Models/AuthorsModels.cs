namespace libreriaApp.Web.Models
{
    public class AuthorsModels
    {
        public int au_id { get; set; }
        public string au_lname { get; set; }
        public string au_fname { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public byte contact { get; set; }
    }
}
