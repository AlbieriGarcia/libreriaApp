using System.Collections.Generic;
using libreriaApp.DAL.Entities;
using libreriaApp.DAL.Context;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Diagnostics;

namespace libreriaApp.DAL.Repositories
{
    public class TitleRepository : Interfaces.ITitleRepository    
    {
        private readonly LibreriaContext libreriaContext;
        private readonly ILogger<TitleRepository> logger;
        public TitleRepository(LibreriaContext libreriaContext, ILogger<TitleRepository> logger) 
        {
            this.libreriaContext = libreriaContext;
            this.logger = logger;
        }
        
        public bool Exists(string name) 
        {
            return this.libreriaContext.titles.Any(st => st.title == name);
        }
        public List<Title> GetAll() 
        {
            return this.libreriaContext.titles.Where(dep => !dep.Deleted).ToList();
        }

        public Title GetById(string title)
        {
            return this.libreriaContext.titles.Find(title);
        }

        public void Remove(Title title)
        {
            try
            {
                Title titleToRemove = this.GetById(title.title_id);

                titleToRemove.Deleted = true;
                titleToRemove.DeletedDate = DateTime.Now;
                titleToRemove.UserDeleted = title.UserDeleted;

                this.libreriaContext.titles.Update(titleToRemove);
                this.libreriaContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error Removiendo el Título", ex.ToString());
            }
        }

        public void Save(Title title)
        {
            try
            {
                Title titleToAdd = new Title()
                {
                    title_id = title.title_id,
                    title = title.title,
                    type = title.type,
                    price = title.price,
                    advance = title.advance,
                    royalty = title.royalty,
                    ytd_sales = title.ytd_sales,
                    notes = title.notes,
                    pubdate = title.pubdate,
                    CreationDate = DateTime.Now,
                    CreationUser= title.CreationUser,

                };

                this.libreriaContext.titles.Add(titleToAdd);
                this.libreriaContext.SaveChanges();

            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error al guardar el Título", ex.ToString());
            }
        }
        public void Update(Title title)
        {
            try
            {
                Title titleToUpdate = this.GetById(title.title_id);

                titleToUpdate.title_id= title.title_id;
                titleToUpdate.title = title.title;
                titleToUpdate.type = title.type;
                titleToUpdate.price = title.price;
                titleToUpdate.advance = title.advance;
                titleToUpdate.royalty = title.royalty;
                titleToUpdate.ytd_sales = title.ytd_sales;
                titleToUpdate.notes = title.notes;
                titleToUpdate.pubdate = title.pubdate;
                titleToUpdate.ModifyDate = DateTime.Now;
                titleToUpdate.UserMod = title.UserMod;

                this.libreriaContext.titles.Update(titleToUpdate);
                this.libreriaContext.SaveChanges();

            }
            catch  (Exception ex)
            {
                this.logger.LogError($"Error al actualizar el Título", ex.ToString());
            }
        }
    }
}
