using libreriaApp.DAL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace libreriaApp.DAL.Entities
{
    [Table("authors",Schema ="dbo")]
    public class Authors : Location
    {
        [Key]
        public string au_id { get; set; }
        public string au_fname { get; set; }
        public string au_lname { get; set; }
        public string phone { get; set; }
        public string? address { get; set; }
        public string? zip { get; set; }
        public char contact { get; set; }
    }

}

