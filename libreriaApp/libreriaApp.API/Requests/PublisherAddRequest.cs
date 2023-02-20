using System;
using System.ComponentModel.DataAnnotations;

namespace libreriaApp.API.Requests
    
{
    public class PublisherAddRequest : RequestAddBase
    {
        public int pub_id { get; set; }
        public string? pub_name { get; set; }
        public string? country { get; set; }
        public string? city { get; set; }
        public char? state { get; set; }
    }
}
