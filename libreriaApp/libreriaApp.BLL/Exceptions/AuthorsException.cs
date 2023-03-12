using System;
using System.Collections.Generic;
using System.Text;

namespace libreriaApp.BLL.Exceptions
{
    public class AuthorsException : Exception
    {
        public AuthorsException(string message) : base(message) 
        {
            //usted agregar x logica : enviar una notificacion,persistir local file system,bd,etc. //
        }
    }
}
