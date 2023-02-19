using System;

namespace libreriaApp.API.Requests
{
    public abstract class RequestAddBase
    {
        public DateTime CreateDate { get; set; }
        public int CreationUser { get; set; }
    }
}
