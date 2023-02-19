namespace libreriaApp.API.Requests
{
    public class AuthorsAddRequest : RequestAddBase
    {
        public string au_id { get; set; }
        public string au_fname { get; set; }
        public string au_lname { get; set; }
        public string phone { get; set; }
        public string? address { get; set; }
        public string? zip { get; set; }
        public char contact { get; set; }
    }
}
