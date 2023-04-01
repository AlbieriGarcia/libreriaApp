using System.Collections.Generic;

namespace libreriaApp.Web.Models.Response
{
    public class PublisherListResponse 
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<PublisherModel> data { get; set; }
    }
}
