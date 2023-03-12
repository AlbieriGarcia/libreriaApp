using libreriaApp.BLL.Contracts;
using libreriaApp.BLL.Core;
using libreriaApp.BLL.Dtos.Title;
using libreriaApp.BLL.Models;
using libreriaApp.DAL.Entities;
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
                this.logger.LogInformation("Colsuntando los títulos.");

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

                this.logger.LogInformation("Se consultaron los títulos.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los títulos.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(string id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Colsuntando el título.");

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


                this.logger.LogInformation("Se consultó el título.");
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el título";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveTitle(TitleRemoveDto titleRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Title title = this.titleRepository.GetEntity(titleRemove.title_id);

                title.title_id = titleRemove.title_id;
                title.DeletedDate = titleRemove.DeletedDate;
                title.Deleted = true;
                title.UserDeleted = titleRemove.UserDeleted;
               
                this.titleRepository.Update(title);
                this.titleRepository.SaveChanges();
                result.Message = "El título fue removido correctamente.";
            }
            catch (Exception ex)
            {
                result.Message = "Error Removiendo el título.";
                result.Success=false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveTitle(TitleAddDto titleAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Title title = new Title()
                {
                    title_id = titleAdd.title_id,
                    title = titleAdd.title,
                    type = titleAdd.type,
                    price = titleAdd.price,
                    advance = titleAdd.advance,
                    royalty = titleAdd.royalty,
                    ytd_sales = titleAdd.ytd_sales,
                    notes = titleAdd.notes,
                    pubdate = titleAdd.pubdate,
                    CreationDate = titleAdd.CreationDate,
                    CreationUser = titleAdd.CreationUser

                };
                this.titleRepository.Save(title);
                this.titleRepository.SaveChanges();
                result.Message = "El título fue guardado correctamente.";
            }
            catch (Exception ex)
            {
                result.Message = "Error Guardando el título.";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateTitle(TitleUpdateDto titleUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Title title = this.titleRepository.GetEntity(titleUpdate.title_id);

                title.title_id = titleUpdate.title_id;
                title.title = titleUpdate.title;
                title.type = titleUpdate.type; 
                title.price = titleUpdate.price;
                title.advance = titleUpdate.advance;
                title.royalty = titleUpdate.royalty;
                title.ytd_sales = titleUpdate.ytd_sales;
                title.notes = titleUpdate.notes;
                title.pubdate = titleUpdate.pubdate;
                title.ModifyDate = titleUpdate.ModifyDate;
                title.UserMod = titleUpdate.UserMod;

                
                this.titleRepository.Update(title);
                this.titleRepository.SaveChanges();
                result.Message = "El título fue modificado correctamente.";
            }
            catch (Exception ex)
            {
                result.Message = "Error Guardando el título.";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
