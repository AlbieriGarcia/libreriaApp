using libreriaApp.BLL.Contract;
using libreriaApp.BLL.Core;
using libreriaApp.BLL.Models;
using libreriaApp.DAL.Interfaces;
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
    }
}
