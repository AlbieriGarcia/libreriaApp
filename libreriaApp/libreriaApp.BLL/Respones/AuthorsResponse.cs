using libreriaApp.BLL.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace libreriaApp.BLL.Respones
{
    public class AuthorsResponse : ServiceResult
    {
        public string au_id { get; set; }
    }
}
