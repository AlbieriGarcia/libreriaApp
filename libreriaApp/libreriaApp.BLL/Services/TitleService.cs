using libreriaApp.BLL.Contracts;
using libreriaApp.BLL.Core;
using libreriaApp.BLL.Models;
using libreriaApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace libreriaApp.BLL.Services
{
    public class TitleService : Contracts.ITitleService
    {
        private readonly ITitleRepository titleRepository;
        private readonly ILogger<TitleService> logger;

        public TitleService(ITitleRepository titleRepository, ILogger<TitleService> logger) 
        {
            this.titleRepository = titleRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Colsuntando los títulos");

                var titles = this.titleRepository.GetEntities().Select(dep => new TitleModel()
                {
                    title_id = dep.title_id,
                    title = dep.title,
                    type = dep.type,
                    price = dep.price,
                    royalty = dep.royalty,
                    ytd_sales = dep.ytd_sales,
                    notes =dep.notes,
                    pubdate = dep.pubdate


                }).ToList();

                result.Data = titles;

                this.logger.LogInformation("Se consultaron los títulos");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los títulos";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(string id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Colsuntando el título");

                var title = this.titleRepository.GetEntity(id);

                TitleModel titleModel = new TitleModel() 
                {
                    title_id = title.title_id,
                    title = title.title,
                    type = title.type,
                    price = title.price,
                    royalty = title.royalty,
                    ytd_sales = title.ytd_sales,
                    notes = title.notes,
                    pubdate = title.pubdate
                };

                result.Data = titleModel;


                this.logger.LogInformation("Se consultó el título");
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el título";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
