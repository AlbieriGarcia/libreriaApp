using System;

namespace libreriaApp.Web.Models
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
        public DateTime creationDateDisplay { get; set; }
    }
}
