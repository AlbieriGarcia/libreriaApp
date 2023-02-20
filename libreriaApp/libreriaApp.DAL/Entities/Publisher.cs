using libreriaApp.DAL.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace libreriaApp.DAL.Entities
{
    
    public class Publisher : Location
    {

        [Key]
        public  int pub_id { get; set; }
        public string? pub_name { get; set; }
        public string? country { get; set; }

    }
}
