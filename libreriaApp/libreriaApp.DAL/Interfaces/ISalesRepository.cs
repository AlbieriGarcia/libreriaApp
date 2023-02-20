using libreriaApp.DAL.Entities;
using System.Collections.Generic;
using System.Dynamic;

namespace libreriaApp.DAL.Interfaces
{
    public interface ISalesRepository
    {
        Sales GetById(string Sale);
        List<Sales> GetAll();
        void Save(Sales Sale);
        void Update(Sales  Sale);
        void Remove(Sales Sale);
        bool Exists(string name);

    }
}
