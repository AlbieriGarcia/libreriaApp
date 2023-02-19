using System;
using System.ComponentModel.DataAnnotations;

namespace libreriaApp.DAL.Entities
{
    
    public class publishers : Core.AuditEntity
    {

        [Key]
        public  char pub_id { get; set; }
        public string? pub_name { get; set; }
        public string? country { get; set; }

    }
}
