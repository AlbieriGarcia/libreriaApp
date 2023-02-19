using libreriaApp.DAL.Entities;
using System.Collections.Generic;

namespace libreriaApp.DAL.Interfaces
{
    public interface ITitleRepository
    {
        void Save(Title title);
        void Update(Title title);
        void Remove(Title title);
        Title GetById(string title);
        List<Title> GetAll();
        bool Exists(string name);
    }
}
