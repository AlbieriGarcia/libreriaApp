using System;
using System.ComponentModel.DataAnnotations;

namespace libreriaApp.BLL.Models
{
    public class PublisherModel
    {
        [Key]
        public string pub_id { get; set; }
        public string pub_name { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string? state { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string StartDateDisplay 
        { 
            
            get { return this.StartDate.ToString("dd/MM/yyyy"); }
            
          }
        public string CreationDateDisplay
        { 
            get { return this.StartDate.ToString("dd/MM/yyyy"); }
        
        }


    }
}
