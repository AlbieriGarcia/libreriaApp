using System;

namespace libreriaApp.Web.Models
{
    public class TitleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public DateTime PubDate { get; set; }
    }
}
