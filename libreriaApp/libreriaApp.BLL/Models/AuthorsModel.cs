using System;

namespace libreriaApp.BLL.Models
{
    public class AuthorsModel
    {
        public string au_id { get; set; }
        public string au_lname { get; set; }
        public string au_fname { get; set; }
        public string phone { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? zip { get; set; }
        public bool contract { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string StarDateDisplay
        {
            get { return this.StartDate.ToString("dd/MM/yyyy"); }
        }
        public string CreateDateDisplay
        {
            get { return this.CreationDate.ToString("dd/MM/yyyy"); }
        }
    }
}
