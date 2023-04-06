using libreriaApp.BLL.Contract;
using libreriaApp.BLL.Core;
using libreriaApp.BLL.Dtos.Publisher;
using libreriaApp.BLL.Extentions;
using libreriaApp.BLL.Models;
using libreriaApp.BLL.Validations;
using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Exceptions;
using libreriaApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;


namespace libreriaApp.BLL.Services
{
    public class PublisherService : IPublisherService

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
                result = PublisherValidation.IsValidPublisherAdd(publisherAdd);

            }
            catch (PublisherDataException adex)
            {
                result.Message = adex.Message;
                result.Success = false;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            try
            {
                Publisher publisher = publisherAdd.GetPublisherEntityFromDtoSave();
                this.PublisherRepository.Save(publisher);
                this.PublisherRepository.SaveChanges();
                result.Message = "El autor fue insertado correctamente";
            }
            catch (Exception ex)
            {
                result.Message = "Error guardando las editoras";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return (result);
        }


        public ServiceResult UpdatePublisher(PublisherUpdateDto publisherUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = PublisherValidation.IsValidPublisherUpd(publisherUpdate);

                Publisher publisher = this.PublisherRepository.GetEntity(publisherUpdate.pub_id);

                publisher.pub_id = publisherUpdate.pub_id;
                publisher.ModifyDate = publisherUpdate.ModifyDate;
                publisher.UserMod = publisherUpdate.UserMod;
                publisher.pub_name = publisherUpdate.pub_name;
                publisher.city = publisherUpdate.city;
                publisher.country = publisherUpdate.country;
                publisher.state = publisherUpdate.state;

                this.PublisherRepository.Update(publisher);
                result.Success = true;
                result.Message = "La Editorial fue editada satisfactoriamente";
            }
            catch (PublisherDataException sdex)
            {
                result.Message = sdex.Message;
                result.Success = false;
                this.logger.LogError($"{result.Message}", sdex.ToString());
            }
            catch (Exception ex) 
            {
                result.Message = "Ocurrio un error editando a la editorial";
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            
            }
            return (result);
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
                result.Message = "La auditora fue removida correctamente";


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
