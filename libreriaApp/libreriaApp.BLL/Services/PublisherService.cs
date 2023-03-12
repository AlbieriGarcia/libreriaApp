using libreriaApp.BLL.Contract;
using libreriaApp.BLL.Core;
using libreriaApp.BLL.Dtos.Publisher;
using libreriaApp.BLL.Models;
using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;


namespace libreriaApp.BLL.Services
{
    public class PublisherService : Contract.IPublisherService

    {
        private readonly IPublisherRepository PublisherRepository;
        private readonly ILogger<PublisherService> logger;
        public PublisherService(IPublisherRepository PublisherRepository, 
                                    ILogger<PublisherService> logger)
        {
            this.PublisherRepository = PublisherRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try 
            {
                this.logger.LogInformation("Consultando las editoras");

                var publisher = this.PublisherRepository
                    .GetEntities()
                    .Select(pub => new PublisherModel()
                    {
                        pub_id = pub.pub_id,
                        pub_name = pub.pub_name,
                        city =  pub.city,
                        state = pub.state,
                        country = pub.country,
                        CreateDate = pub.CreationDate,
                        StartDate = pub.StartDate

                    }).ToList();

                result.Data = publisher;
         

                this.logger.LogInformation("Se han consultado correctamente las editoras");

            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Message = "Error obteniendo las Editoras";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult GetById(string id)
        {

            ServiceResult result = new ServiceResult();

            try
            {
                this.logger.LogInformation("Consultando la editora");

                var publisher = this.PublisherRepository.GetEntity(id);

                PublisherModel PublisherModel = new PublisherModel()

                {
                    pub_id = publisher.pub_id,
                    pub_name = publisher.pub_name,
                    city = publisher.city,
                    state = publisher.state,
                    country = publisher.country,
                    CreateDate = publisher.CreationDate,
                    StartDate = publisher.StartDate
                };

                result.Data = publisher;

                this.logger.LogInformation("Se ha consultado correctamente la editora");

            }

            catch (Exception ex) 
            
            {
                result.Success = false;
                result.Message = "Error obteniendo la Editora";
                this.logger.LogError($"{result.Message}", ex.ToString());
            
            }
            return result;
        }
        public ServiceResult SavePublisher(PublisherAddDto publisherAdd)
        {
            ServiceResult result = new ServiceResult();
            try 
            {
                Publisher publisher = new Publisher()
                {
                    
                    CreationDate = publisherAdd.CreationDate,
                    CreationUser = publisherAdd.CreationUser,
                    pub_id = publisherAdd.pub_id,
                    pub_name = publisherAdd.pub_name,
                    country = publisherAdd.country,
                    city = publisherAdd.city,
                    state = publisherAdd.state,                                     
                    StartDate= publisherAdd.StartDate

                };
                this.PublisherRepository.Save(publisher);
                this.PublisherRepository.SaveChanges();
                result.Message = "La auditora se agrego correctamente";

            }
            catch (DbUpdateException ex)
            {
                result.Message = "Error agregando la editora";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult UpdatePublisher(PublisherUpdateDto publisherUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Publisher publisher = this.PublisherRepository.GetEntity(publisherUpdate.pub_id);

                publisher.pub_id = publisherUpdate.pub_id;
                publisher.pub_name = publisherUpdate.pub_name;
                publisher.city = publisherUpdate.city;
                publisher.state = publisherUpdate.state;
                publisher.country = publisherUpdate.country;
                publisher.ModifyDate = publisherUpdate.ModifyDate;
                publisher.UserMod = publisherUpdate.UserMod;
                publisher.StartDate = publisherUpdate.StartDate;

                
                this.PublisherRepository.Update(publisher);
                this.PublisherRepository.SaveChanges();
                result.Message = "La auditora se modifico correctamente";
            }
            catch (Exception ex)
            {
                result.Message = "Error editando a la editora";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult RemoverPublisher(PublisherRemoveDto publisherRemove)
        {
            ServiceResult result = new ServiceResult();
          
            try
            {
                DAL.Entities.Publisher publisher = this.PublisherRepository.GetEntity(publisherRemove.pub_id);

                publisher.pub_id = publisherRemove.pub_id;
                publisher.Deleted = true;
                publisher.UserDeleted= publisherRemove.UserDeleted;
                publisher.DeletedDate= publisherRemove.DeletedDate;

                this.PublisherRepository.Update(publisher);
                this.PublisherRepository.SaveChanges();
                result.Message = "La auditora se elimino correctamente";


            }
            catch (Exception ex) 
            {
                result.Message = "Error removiendo la editora";
                result.Success=false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            
            }
            return result;
        }
    }
}
