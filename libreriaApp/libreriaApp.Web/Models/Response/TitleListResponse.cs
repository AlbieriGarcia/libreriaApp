using System.Collections.Generic;

namespace libreriaApp.Web.Models.Response
{
    public class TitleListResponse
    {
        public bool success { get; set; }
        public List<TitleModel> data { get; set; }
        public string message { get; set; }
    }
}
