using System;
using System.Collections.Generic;
using System.Text;

namespace libreriaApp.BLL.Core
{
    public interface IBaseService
    {
        ServiceResult GetAll();
        ServiceResult GetById(string id);

    }
}
