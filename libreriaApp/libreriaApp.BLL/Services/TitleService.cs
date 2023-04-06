using libreriaApp.BLL.Contracts;
using libreriaApp.BLL.Core;
using libreriaApp.BLL.Dtos.Title;
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
                    pubdate = dep.pubdate,
                    CreateDate = dep.CreationDate,
                    StartDate = dep.StartDate,


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
                    pubdate = title.pubdate,
                    CreateDate = title.CreationDate,
                    StartDate = title.StartDate
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

        public ServiceResult SaveTitle(TitleAddDto addDto)
        {
            
            ServiceResult result = new ServiceResult();

            try
            {
                result = TitleValidation.IsValidTitleAdd(addDto);

            }
            catch (TitleDataException ex)
            {
                result.Message = ex.Message;
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }


            try
            {

                Title title = addDto.GetTitleEntityFromDtoSave();
                this.titleRepository.Save(title);
                this.titleRepository.SaveChanges();
                result.Success = true;
                result.Message = "El Titulo ha sido agregado correctamente.";

                this.logger.LogInformation(result.Message, result);

            }
            catch (DbUpdateException ex)
            {
               
                result.Message = "Error Guardando el título.";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateTitle(TitleUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                result = TitleValidation.IsValidTitleUpd(updateDto);

                Title title = this.titleRepository.GetEntity(updateDto.title_id);

                title.title_id = updateDto.title_id;
                title.title = updateDto.title;
                title.type = updateDto.type;
                title.price = updateDto.price;
                title.advance = updateDto.advance;
                title.royalty = updateDto.royalty;
                title.ytd_sales = updateDto.ytd_sales;
                title.notes = updateDto.notes;
                title.pubdate = updateDto.pubdate;
                title.ModifyDate = updateDto.ModifyDate;
                title.UserMod = updateDto.UserMod;


                this.titleRepository.Update(title);
                this.titleRepository.SaveChanges();
                result.Message = "El título fue modificado correctamente.";
            }
            catch (TitleDataException sdex)
            {
                result.Message = sdex.Message;
                result.Success = false;
                this.logger.LogError($"{result.Message}", sdex.ToString());
            }
            
            catch (Exception ex)
            {
                result.Message = "Error Editando el título.";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult RemoveTitle(TitleRemoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Title titleToRemove = this.titleRepository.GetEntity(removeDto.title_id);

                titleToRemove.title_id = removeDto.title_id;
                titleToRemove.DeletedDate = removeDto.RemoveDate;
                titleToRemove.Deleted = removeDto.Removed;
                titleToRemove.UserDeleted = removeDto.RemoveUser;

                this.titleRepository.Update(titleToRemove);
                result.Success = true;
                result.Message = "El título fue removido correctamente.";
            }
            catch (Exception ex)
            {
                result.Message = "Error Removiendo el título.";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
