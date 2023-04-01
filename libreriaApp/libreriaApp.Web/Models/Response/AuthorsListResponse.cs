using System.Collections.Generic;

namespace libreriaApp.Web.Models.Response
{
    public class AuthorsListResponse 
    {
        public bool success { get; set; }
        public List<AuthorsModels> data { get; set; }
        public object message { get; set; }
    }
}
