using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Context;
using Microsoft.Extensions.Logging;
using libreriaApp.DAL.Interfaces;

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

    }
}
