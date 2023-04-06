using libreriaApp.BLL.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace libreriaApp.BLL.Responses
{
    internal class TitleResponse : ServiceResult
    {
        public string title_id { get; set; }
    }
}
