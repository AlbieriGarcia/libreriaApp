using Microsoft.VisualBasic;
using System;

namespace libreriaApp.Web.Models
{
    public class SaleModel
    {
        public int Id { get; set; }
        public string ord_nom { get; set; }
        public DateTime ord_date { get; set;}
        public int qty { get; set;}
        public string payterms { get; set; }
        public string title_id { get; set; }


    }
}
