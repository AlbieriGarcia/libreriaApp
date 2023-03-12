using System;
using System.ComponentModel.DataAnnotations;

namespace libreriaApp.BLL.Dtos.Publisher
{
    public class PublisherRemoveDto
    {

 
        public string pub_id { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? UserDeleted { get; set; }
    }
}
