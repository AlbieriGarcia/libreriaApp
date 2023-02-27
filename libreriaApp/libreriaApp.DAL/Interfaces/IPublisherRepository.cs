using libreriaApp.DAL.Entities;
using System.Collections.Generic;

namespace libreriaApp.DAL.Interfaces
{
    public interface IPublisherRepository
    {
        void Save(Publisher publisher);
        void Update(Publisher publisher);
        void Remove(Publisher publisher);
        Publisher GetById(string publisher);
        List<Publisher> GetAll();
        bool Exists(string name);

    }
}
