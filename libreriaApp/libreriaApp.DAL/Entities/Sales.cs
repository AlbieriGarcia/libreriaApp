using libreriaApp.DAL.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace libreriaApp.DAL.Entities
{
    public class Sales : AuditEntity
    {
        [Key]
        public string stor_id { get; set; }
        public string ord_num { get; set; }
        public DateTime ord_date { get; set; }
        public int qty { get; set; }
        public string payterms { get; set; }
        public string title_id { get; set; }

    }
}
