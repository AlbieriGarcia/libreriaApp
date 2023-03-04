using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Context;
using Microsoft.Extensions.Logging;
using libreriaApp.DAL.Interfaces;

namespace libreriaApp.DAL.Repository
{
    public class PublisherRepository : Core.RepositoryBase<Publisher>, IPublisherRepository
    {
        private readonly LibreriaContext context;
        private readonly ILogger<PublisherRepository> logger;
        public PublisherRepository(LibreriaContext context,
                                    ILogger<PublisherRepository> logger): base(context)
        {
            this.context = context;
            this.logger = logger;
        }

    }
}
