using System;
using System.ComponentModel.DataAnnotations;

namespace libreriaApp.BLL.Dtos.Publisher
{

    public class PublisherUpdateDto
    {
        public string pub_id { get; set; }
        public string pub_name { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string? state { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? UserMod { get; set; }
    }
}
