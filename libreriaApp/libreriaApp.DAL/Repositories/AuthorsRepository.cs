using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Context;
using Microsoft.Extensions.Logging;
using libreriaApp.DAL.Interfaces;
using libreriaApp.DAL.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace libreriaApp.DAL.Repositories
{
    public class AuthorsRepository : Core.RepositoryBase<Authors>, IAuthorsRepository
    {
        private readonly LibreriaContext context;
        private readonly ILogger<AuthorsRepository> ilogger;
        public AuthorsRepository(LibreriaContext context,
                                ILogger<AuthorsRepository> ilogger) : base(context)
        {
            this.context = context;
            this.ilogger = ilogger;
        }

        public override void Save(Authors entity)
        {
            if (this.Exists(cd => cd.au_fname == entity.au_fname))
            {
                throw new AuthorsDataException("Este estudiante ya existe");
            }

            
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(Authors entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(Authors entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override List<Authors> GetEntities()
        {
            return this.context.Authors.Where(cd => !cd.Deleted).ToList();
        }

        public override Authors GetEntity(string id)
        {
            return this.context.Authors.FirstOrDefault(cd => cd.au_id == id && !cd.Deleted);
        }
    }
}
