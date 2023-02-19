using System;
using System.ComponentModel.DataAnnotations;

namespace libreriaApp.API.Requests
    
{
    public class PublisherAddRequest : RequestAddBase
    {
        
        public char pub_id { get; set; }
        public string? pub_name { get; set; }
        public string? country { get; set; }
    }
}
