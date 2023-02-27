using libreriaApp.DAL.Entities;
using System.Collections.Generic;

namespace libreriaApp.DAL.Interfaces
{
    public interface IAuthorsRepository
    {
        void Save(Authors authors);
        void Update(Authors authors);
        void Remove(Authors authors);
        Authors GetById(string authorsid);
        List<Authors> GetAll();
        bool Exists(string au_fname);

    }
}
