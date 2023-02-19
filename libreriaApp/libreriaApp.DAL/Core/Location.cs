using System;
using System.Collections.Generic;
using System.Text;

namespace libreriaApp.DAL.Core
{
    public abstract class Location : AuditEntity
    { 
        public string? city { get; set; }
        public string? state { get; set; }
    }
}
