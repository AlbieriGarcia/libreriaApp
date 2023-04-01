namespace libreriaApp.Web.Models.Response
{
    public class AuthorsResponse
    {
        public bool success { get; set; }
        public AuthorsModels data { get; set; }
        public object message { get; set; }
    }
}
