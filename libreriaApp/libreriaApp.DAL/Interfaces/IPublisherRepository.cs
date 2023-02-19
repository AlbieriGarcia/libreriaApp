using libreriaApp.DAL.Entities;
using System.Collections.Generic;

namespace libreriaApp.DAL.Interfaces
{
    public interface IPublisherRepository
    {
        void Save(publishers publishers);
        void Update(publishers publishers);
        void Remove(publishers publishers);
        publishers GetById(int publishersId);
        List<publishers> GetAll();
        bool Exists(string name);

    }
}
