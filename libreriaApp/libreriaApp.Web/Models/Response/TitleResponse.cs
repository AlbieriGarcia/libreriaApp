using System.Collections.Generic;

namespace libreriaApp.Web.Models.Response
{
    public class TitleResponse
    {
        public bool success { get; set; }
        public TitleModel data { get; set; }
        public string message { get; set; }
    }
}
