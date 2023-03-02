using libreriaApp.DAL.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace libreriaApp.DAL.Entities
{
    
    public class Publisher : AuditEntity
    {

        [Key]
        public  string pub_id { get; set; }
        public string pub_name { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string? state { get; set; }

    }
}
