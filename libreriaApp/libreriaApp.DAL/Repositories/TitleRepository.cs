using System.Collections.Generic;
using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Context;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Diagnostics;
using libreriaApp.DAL.Interfaces;
using libreriaApp.DAL.Exceptions;

namespace libreriaApp.DAL.Repositories
{
    public class TitleRepository : Core.RepositoryBase<Title>, ITitleRepository    
    {
        private readonly LibreriaContext libreriaContext;
        private readonly ILogger<TitleRepository> logger;
        public TitleRepository(LibreriaContext libreriaContext, ILogger<TitleRepository> logger) : base(libreriaContext) 
        {
            this.libreriaContext = libreriaContext;
            this.logger = logger;
        }
        public override void Save(Title entity)
        {
            if (this.Exists(cd => cd.title == entity.title))
            {
                throw new TitleDataException("Este título ya existe");
            }

            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(Title entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(Title entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }

        public override List<Title> GetEntities()
        {
            return this.libreriaContext.titles.Where(cd => !cd.Deleted).ToList();
        }
        public override Title GetEntity(string id)
        {
            return this.libreriaContext.titles.FirstOrDefault(cd => cd.title_id == id && !cd.Deleted);
        }


    }
}
