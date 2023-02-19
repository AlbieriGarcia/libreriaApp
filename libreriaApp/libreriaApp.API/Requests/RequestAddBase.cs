using System;

namespace libreriaApp.API.Requests
{
    public abstract class RequestAddBase
    {
        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }
    }
}
