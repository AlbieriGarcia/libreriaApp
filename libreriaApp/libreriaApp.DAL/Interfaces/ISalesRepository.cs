using libreriaApp.DAL.Entities;
using System.Collections.Generic;
using System.Dynamic;

namespace libreriaApp.DAL.Interfaces
{
    public interface ISalesRepository
    {
        void Save(Sales sales);
        void Update(Sales sales);
        void Remove(Sales sales);
        Sales GetById(string Sales);
        List<Sales> GetAll();
        bool Exists(string name);

    }
}
