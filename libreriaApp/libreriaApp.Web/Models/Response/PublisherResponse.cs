using System.Collections.Generic;

namespace libreriaApp.Web.Models.Response
{
    public class PublisherResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public PublisherModel data { get; set; }
    }
}
