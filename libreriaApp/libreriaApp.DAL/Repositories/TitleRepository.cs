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
        public override List<Title> GetEntities()
        {
            return this.libreriaContext.titles.Where(de => !de.Deleted).OrderByDescending(cd => cd.CreationDate).ToList();
        }

    }
}
