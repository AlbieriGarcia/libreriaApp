using libreriaApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using libreriaApp.DAL.Context;
using Microsoft.Extensions.Logging;
using System.Linq;
using libreriaApp.DAL.Interfaces;

namespace libreriaApp.DAL.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly LibreriaContext context;
        private readonly ILogger<AuthorsRepository> ilogger;
        public AuthorsRepository(LibreriaContext context, 
                                ILogger<AuthorsRepository> ilogger)
        {
            this.context = context;
            this.ilogger = ilogger;
        }  

        public bool Exists(string name)
        {
            return this.context.Authors.Any(st => st.au_fname == name);
        }

        public List<Authors> GetAll()
        {
            return this.context.Authors.ToList();
        }

        public Authors GetById(string authorsid)
        {
            return this.context.Authors.Find(authorsid);
        }

        public void Remove(Authors authors)
        {
            try
            {
                Authors authorsToRemove = this.GetById(authors.au_id);
                authorsToRemove.DeletedDate = DateTime.Now;
                authorsToRemove.UserDeletd = 1;
                authorsToRemove.Deleted = 1;

                this.context.Authors.Remove(authorsToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.ilogger.LogError($"Error removiendo el autor {ex.Message}", ex.ToString());
                
            }
        }

        public void Save(Authors authors)
        {
            try 
            {
                Authors authorsToAdd = new Authors()
                {
                    CreationDate = DateTime.Now,
                    CreationUser = authors.CreationUser,
                    au_id = authors.au_id,
                    au_lname = authors.au_lname,
                    au_fname = authors.au_fname,
                    phone = authors.phone,
                    address = authors.address,
                    city = authors.city,
                    state = authors.state,
                    zip = authors.zip,
                    contract = authors.contract,
                };
                this.context.Authors.Add(authorsToAdd);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.ilogger.LogError($"Error al agregar el autor{ex.Message}", ex.ToString());

            }
        }

        public void Update(Authors authors)
        {
            try 
            {
                Authors authorsToUpdate = this.GetById(authors.au_id);
                authorsToUpdate.au_id = authors.au_id;
                authorsToUpdate.au_lname = authors.au_lname;
                authorsToUpdate.au_fname = authors.au_fname;
                authorsToUpdate.phone = authors.phone;
                authorsToUpdate.address = authors.address;
                authorsToUpdate.city = authors.city;
                authorsToUpdate.state = authors.state;
                authorsToUpdate.zip = authors.zip;
                authorsToUpdate.contract = authors.contract;
                authorsToUpdate.ModifyDate = DateTime.Now;
                authorsToUpdate.UserMod = authors.UserMod;
                
                this.context.Authors.Update(authorsToUpdate);
                this.context.SaveChanges();


            }
            catch (Exception ex)
            {
                this.ilogger.LogError($"Error al editar el autor{ex.Message}", ex.ToString());

            }
        }
    }
}
