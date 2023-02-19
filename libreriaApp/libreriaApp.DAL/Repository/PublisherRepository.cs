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

        public PublisherRepository(LibreriaContext context, 
                                    ILogger <PublisherRepository> logger) 
        {
            this.context = context;
            this.logger = logger;
        }
        public bool Exists(string name)
        {
            return this.context.Publishers.Any(st => st.pub_name == name);
        }

        public List<publishers> GetAll()
        {
            return this.context.Publishers.ToList();
        }

        public publishers GetById(int publishersId)
        {
            return this.context.Publishers.Find(publishersId);
        }

        public void Remove(publishers publishers)
        {
            try
            {
                publishers publishersToRemove = this.GetById(publishers.pub_id);

                publishersToRemove.Deleted = true;
                publishersToRemove.DeletedDate = DateTime.Now;
                publishersToRemove.UserDeleted = 1;


                this.context.Publishers.Update(publishersToRemove);
                this.context.SaveChanges();

            }
            catch (Exception ex) 
            {
                this.logger.LogError($"Error removiendo a la editora", ex.ToString());
            }
        }

        public void Save(publishers publishers)
        {
            try
            {
                publishers publisherToAdd = new publishers()
                {
                    pub_name = publishers.pub_name,
                    country = publishers.country,
                    CreationDate = DateTime.Now,
                    CreationUser = publishers.CreationUser,
                };

                this.context.Publishers.Add(publisherToAdd);
                this.context.SaveChanges();
            }
            catch (Exception ex)

            {
                this.logger.LogError($"Error agrefar la editora", ex.ToString());

            }
        }

        public void Update(publishers publishers)
        {
            try
            {
                publishers publishersToUpdate = this.GetById(publishers.pub_id);

                publishersToUpdate.pub_id = publishers.pub_id;
                publishersToUpdate.pub_name = publishers.pub_name;
                publishersToUpdate.country = publishers.country;
                publishersToUpdate.ModifyDate = DateTime.Now;
                publishersToUpdate.UserMod = publishers.UserMod;

                this.context.Publishers.Update(publishersToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex) 
            {
                this.logger.LogError($"Error actualizando la editora", ex.ToString());

            }
        }
    }
}
