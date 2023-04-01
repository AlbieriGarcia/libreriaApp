using System;

namespace libreriaApp.Web.Models.Request
{
    public class PublisherUpdateRequest
    {
        public string pub_id { get; set; }
        public string pub_name { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public DateTime startDate { get; set; }
        public DateTime modifyDate { get; set; }
        public int userMod { get; set; }
    }
}
