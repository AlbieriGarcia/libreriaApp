using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Context;
using Microsoft.Extensions.Logging;
using libreriaApp.DAL.Interfaces;
using System.Linq;
using System.Collections.Generic;
using libreriaApp.DAL.Exceptions;

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

        public override void Save(Publisher entity)
        {
            if (this.Exists(cd => cd.pub_name == entity.pub_name))
            {
                throw new PublisherDataException("Esta auditora ya existe");
            }
            base.Save(entity);
            base.SaveChanges();
        }

        public override void Update(Publisher entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(Publisher entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }

        public override List<Publisher> GetEntities()
        {
            return this.context.publishers.Where(cd => !cd.Deleted).ToList(); 


        }

        public override Publisher GetEntity(string id)
        {
            return this.context.publishers.FirstOrDefault(cd => cd.pub_id== id && !cd.Deleted);
        }

    }
}
