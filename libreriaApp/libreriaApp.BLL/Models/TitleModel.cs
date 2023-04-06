using System;

namespace libreriaApp.BLL.Models
{
    public class TitleModel
    {
        public string title_id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public Decimal? price { get; set; }
        public Decimal? advance { get; set; }
        public int? royalty { get; set; }
        public int? ytd_sales { get; set; }
        public string? notes { get; set; }
        public DateTime pubdate { get; set; }
        public DateTime CreationDate { get; set; }
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
