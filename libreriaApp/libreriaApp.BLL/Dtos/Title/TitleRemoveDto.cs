
using System;

namespace libreriaApp.BLL.Dtos.Title
{
    public class TitleRemoveDto
    {
        public string title_id { get; set; }
        public bool Removed { get; set; }
        public DateTime RemoveDate { get; set; }
        public int RemoveUser { get; set; }
    }
}
