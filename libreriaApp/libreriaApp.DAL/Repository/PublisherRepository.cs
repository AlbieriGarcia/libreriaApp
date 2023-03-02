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
        private readonly LibreriaContext context;
        private readonly ILogger<PublisherRepository> logger;
        public PublisherRepository(LibreriaContext context, ILogger<PublisherRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public bool Exists(string name)
        {
            return this.context.publishers.Any(st => st.pub_name == name);
        }

        public List<Publisher> GetAll()
        {
            return this.context.publishers.ToList();
        }

        public Publisher GetById(string publisher)
        {
            return this.context.publishers.Find(publisher);
        }

        public void Remove(Publisher publisher)
        {
            try
            {
                Publisher publisherToRemove = this.GetById(publisher.pub_id);

                publisherToRemove.Deleted = 1;
                publisherToRemove.DeletedDate = DateTime.Now;
                publisherToRemove.UserDeleted = 1;
                
                this.context.publishers.Remove(publisherToRemove);
                this.context.SaveChanges();

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
                    state = publisher.state,
                    city= publisher.city,
                };

                this.context.publishers.Add(publisherToAdd);
                this.context.SaveChanges();
            }
            catch (Exception ex)

            {
                this.logger.LogError($"Error agregar la editora", ex.ToString());

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
                publisherToUpdate.city = publisher.city;
                publisherToUpdate.state = publisher.state;

                this.context.publishers.Update(publisherToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex) 
            {
                this.logger.LogError($"Error actualizando la editora", ex.ToString());

            }
        }
    }
}
