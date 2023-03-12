using libreriaApp.BLL.Contract;
using libreriaApp.BLL.Core;
using libreriaApp.BLL.Dtos.Publisher;
using libreriaApp.BLL.Extentions;
using libreriaApp.BLL.Models;
using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Exceptions;
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


            if (string.IsNullOrEmpty(publisherAdd.pub_id))
            {
                result.Success = false;
                result.Message = "El id es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(publisherAdd.pub_name))
            {
                result.Success = false;
                result.Message = "El pub_name es requerido";
            }
            if (publisherAdd.pub_name.Length > 40)
            {
                result.Success = false;
                result.Message = "La longitud del nombre es invalida(max40)";
                return result;
            }
            if (string.IsNullOrEmpty(publisherAdd.city))
            {
                result.Success = false;
                result.Message = "La ciudad es requerida";
                return result;
            }
            if (publisherAdd.city.Length > 20)
            {
                result.Success = false;
                result.Message = "La longitud de la ciudad es invalidad(max20)";
                return result;
            }
            if (publisherAdd.state?.Length > 2)
            {
                result.Success = false;
                result.Message = "La longitud de state es invalidad(max2)";
                return result;
            }
            try
            {
                Publisher publisher = publisherAdd.GetPublisherEntityFromDtoSave();
                this.PublisherRepository.Save(publisher);
                result.Success = true;
                result.Message = "La Editorial a sido agregada correctamente";
            }
            catch (PublisherDataException sdex)
            {
                result.Message = sdex.Message;
                result.Success = false;
                this.logger.LogError($"{result.Message}", sdex.ToString());
            }
            catch (Exception ex) 
            {
                result.Message = "A sucedido un error agregando la Editorial";
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

                if (string.IsNullOrEmpty(publisherUpdate.pub_id))
                {
                    result.Success = false;
                    result.Message = "El id es requerido";
                    return result;
                }
                if (string.IsNullOrEmpty(publisherUpdate.pub_name))
                {
                    result.Success = false;
                    result.Message = "El pub_name es requerido";
                }
                if (publisherUpdate.pub_name.Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud del nombre es invalida(max40)";
                    return result;
                }
                if (string.IsNullOrEmpty(publisherUpdate.city))
                {
                    result.Success = false;
                    result.Message = "La ciudad es requerida";
                    return result;
                }
                if (publisherUpdate.city.Length > 20)
                {
                    result.Success = false;
                    result.Message = "La longitud de la ciudad es invalidad(max20)";
                    return result;
                }
                if (publisherUpdate.state?.Length > 2)
                {
                    result.Success = false;
                    result.Message = "La longitud de state es invalidad(max2)";
                    return result;
                }

                Publisher publisher = this.PublisherRepository.GetEntity(publisherUpdate.pub_id);
                publisher.ModifyDate = publisherUpdate.ModifyDate;
                publisher.UserMod = publisherUpdate.UserMod;
                publisher.pub_id= publisherUpdate.pub_id;
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
                result.Message = "Ocurrio un error editando el registro";
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            
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
