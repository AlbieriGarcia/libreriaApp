using System;

namespace libreriaApp.BLL.Dtos.Title
{
    public class TitleAddDto
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
        public int CreationUser { get; set; }
        public DateTime StartDate { get; set; }
    }
}
