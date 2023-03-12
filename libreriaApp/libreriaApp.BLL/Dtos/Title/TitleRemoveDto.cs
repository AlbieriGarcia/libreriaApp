
using System;

namespace libreriaApp.BLL.Dtos.Title
{
    public class TitleRemoveDto
    {
        public string title_id { get; set; }
        public DateTime DeletedDate { get; set; }
        public int UserDeleted { get; set; }
    }
}
