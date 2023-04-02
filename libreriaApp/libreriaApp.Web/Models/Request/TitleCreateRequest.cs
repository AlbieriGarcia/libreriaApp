using System;

namespace libreriaApp.Web.Models.Request
{
    public class TitleCreateRequest
    {
        public string title_id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public decimal? price { get; set; }
        public decimal? advance { get; set; }
        public int? royalty { get; set; }
        public int? ytd_sales { get; set; }
        public string? notes { get; set; }
        public DateTime pubdate { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreationUser { get; set; }
    }
}
