using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Context;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System;
using libreriaApp.DAL.Interfaces;

namespace libreriaApp.DAL.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly LibreriaContext libreriaContext;
        private readonly ILogger<PublisherRepository> logger;
        public PublisherRepository(LibreriaContext libreriaContext, ILogger<PublisherRepository> logger)
        {
            this.libreriaContext = libreriaContext;
            this.logger = logger;
        }
        public bool Exists(string name)
        {
            return this.libreriaContext.publishers.Any(st => st.pub_name == name);
        }

        public List<Publisher> GetAll()
        {
            return this.libreriaContext.publishers.Where(dep => !dep.Deleted).ToList();
        }

        public Publisher GetById(int publisher)
        {
            return this.libreriaContext.publishers.Find(publisher);
        }

        public void Remove(Publisher publisher)
        {
            try
            {
                Publisher publisherToRemove = this.GetById(publisher.pub_id);

                publisherToRemove.Deleted = true;
                publisherToRemove.DeletedDate = DateTime.Now;
                publisherToRemove.UserDeleted = 1;


                this.libreriaContext.publishers.Update(publisherToRemove);
                this.libreriaContext.SaveChanges();

            }
            catch (Exception ex) 
            {
                this.logger.LogError($"Error removiendo a la editora", ex.ToString());
            }
        }

        public void Save(Publisher publisher)
        {
            try
            {
                Publisher publisherToAdd = new Publisher()
                {
                    pub_name = publisher.pub_name,
                    country = publisher.country,
                    CreationDate = DateTime.Now,
                    CreationUser = publisher.CreationUser,
                };

                this.libreriaContext.publishers.Add(publisherToAdd);
                this.libreriaContext.SaveChanges();
            }
            catch (Exception ex)

            {
                this.logger.LogError($"Error agrefar la editora", ex.ToString());

            }
        }

        public void Update(Publisher publisher)
        {
            try
            {
                Publisher publisherToUpdate = this.GetById(publisher.pub_id);

                publisherToUpdate.pub_id = publisher.pub_id;
                publisherToUpdate.pub_name = publisher.pub_name;
                publisherToUpdate.country = publisher.country;
                publisherToUpdate.ModifyDate = DateTime.Now;
                publisherToUpdate.UserMod = publisher.UserMod;

                this.libreriaContext.publishers.Update(publisherToUpdate);
                this.libreriaContext.SaveChanges();
            }
            catch (Exception ex) 
            {
                this.logger.LogError($"Error actualizando la editora", ex.ToString());

            }
        }
    }
}
