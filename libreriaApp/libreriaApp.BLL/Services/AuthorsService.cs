﻿using libreriaApp.BLL.Contract;
using libreriaApp.BLL.Core;
using libreriaApp.BLL.Dtos.Authors;
using libreriaApp.BLL.Extentions;
using libreriaApp.BLL.Models;
using libreriaApp.BLL.Validations;
using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Exceptions;
using libreriaApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace libreriaApp.BLL.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository authorsRepository;
        private readonly ILogger<AuthorsService> logger;
        public AuthorsService(IAuthorsRepository authorsRepository,
                               ILogger<AuthorsService> logger)
        
        {
            this.authorsRepository = authorsRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando los authors");
                var authors = this.authorsRepository.GetEntities()
                                                    .Select(aut => new AuthorsModel()
                                                    {
                                                        au_id = aut.au_id,
                                                        au_lname = aut.au_lname,
                                                        au_fname = aut.au_fname,
                                                        phone = aut.phone,
                                                        address = aut.address,
                                                        city = aut.city,
                                                        state = aut.state,
                                                        zip = aut.zip,
                                                        contract = aut.contract,
                                                        CreationDate = aut.CreationDate,
                                                        StartDate = aut.StartDate
                                                    }).ToList();
                result.Data = authors;
                this.logger.LogInformation("Se consulto los authors");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los authors";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(string id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultadno los authors");

                var authors = this.authorsRepository.GetEntity(id);

                AuthorsModel authorsModel = new AuthorsModel()
                {
                    au_id = authors.au_id,
                    au_lname = authors.au_lname,
                    au_fname = authors.au_fname,
                    phone = authors.phone,
                    address = authors.address,
                    city = authors.city,
                    state = authors.state,
                    zip = authors.zip,
                    contract = authors.contract,
                    CreationDate = authors.CreationDate,
                    StartDate = authors.StartDate

                };
                result.Data = authorsModel;

                this.logger.LogInformation("Se consulto el author");
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los authors";
                this.logger.LogError($"{result.Message}", ex.ToString()); 
            }
            return result;
        }

        public ServiceResult SaveAuthors(AuthorsAddDto authorsAdd)
        {
            ServiceResult result = new ServiceResult();
            try
            {

                result = ValidationAuthors.IsValidAuthorsAdd(authorsAdd);
            }
            catch (AuthorsDataException adex)
            {
                result.Message = adex.Message;
                result.Success = false;
                this.logger.LogError($"{result.Message}", adex.ToString());
            }
            try
            {
                Authors authors = authorsAdd.GetAuthorsEntityFromDtoSave();
                this.authorsRepository.Save(authors);
                this.authorsRepository.SaveChanges();
                result.Message = "El autor fue insertado correctamente";
            }


            

            catch (Exception ex)
            {
                result.Message = "Error guardando los autores";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return (result);
        }

        public ServiceResult UpdateAuthors(AuthorsUpdateDto authorsUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {

                result = ValidationAuthors.IsValidAuthorsUpd(authorsUpdate);

                Authors authors = this.authorsRepository.GetEntity(authorsUpdate.au_id);

                authors.au_id = authorsUpdate.au_id;
                authors.au_lname = authorsUpdate.au_lname;
                authors.au_fname = authorsUpdate.au_fname;
                authors.phone = authorsUpdate.phone;
                authors.address = authorsUpdate.address;
                authors.city = authorsUpdate.city;
                authors.state = authorsUpdate.state;
                authors.zip = authorsUpdate.zip;
                authors.contract = authorsUpdate.contract;
                authors.StartDate = authorsUpdate.StartDate;
                authors.ModifyDate = authorsUpdate.ModifyDate;
                authors.UserMod = authorsUpdate.UserMod;

                this.authorsRepository.Update(authors);
                this.authorsRepository.SaveChanges();
                result.Message = "El autor fue modificado correctamente";
            }
           
            catch(AuthorsDataException adex)
            {
                result.Message = adex.Message;
                result.Success = false;
                this.logger.LogError(result.Message, adex.ToString());
            }

            catch (Exception ex)
            {
                result.Message = "Error modificando los autores";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return (result);
        }

        public ServiceResult RemoveAuthors(AuthorsRemoveDto authorsRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.Authors authors = this.authorsRepository.GetEntity(authorsRemove.au_id);

                    authors.au_id = authorsRemove.au_id;
                    authors.DeletedDate = authorsRemove.DeletedDate;
                    authors.UserDeletd = authorsRemove.UserDeleted;
                    authors.Deleted = true;
                    
                
                this.authorsRepository.Update(authors);
                this.authorsRepository.SaveChanges();
                result.Message = "El autor fue removido correctamente";

            }
            catch (Exception ex)
            {
                result.Message = "Error borrando los autores";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            
            return (result);
        }

    }
}
