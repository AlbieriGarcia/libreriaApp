using System;

namespace libreriaApp.BLL.Dtos.Publisher
{
    public class PublisherAddDto
    {
        
        public string pub_id { get; set; }
        public string pub_name { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string? state { get; set; }
        public int? CreationUser { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime StartDate { get; set; }
    }
}
