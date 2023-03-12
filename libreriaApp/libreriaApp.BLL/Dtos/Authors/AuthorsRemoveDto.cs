using System;

namespace libreriaApp.BLL.Dtos.Authors
{
    public class AuthorsRemoveDto
    {
        public string au_id { get; set; }
        public string au_lname { get; set; }
        public string au_fname { get; set; }
        public string phone { get; set; }
        public DateTime DeletedDate { get; set; }
        public int UserDeleted { get; set; }
    }
}
