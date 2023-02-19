using libreriaApp.DAL.Entities;
using System;
using System.Collections.Generic;
using libreriaApp.DAL.Context;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Linq;
using libreriaApp.DAL.Interfaces;

namespace libreriaApp.DAL.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly LibreriaContext LibreriaContext;
        private readonly ILogger<SalesRepository> Logger;

        public SalesRepository(LibreriaContext LibreriaContext, ILogger<SalesRepository> logger)
        {
            this.LibreriaContext = LibreriaContext;
        }

        public object This { get; private set; }

        public bool Exists(string name)
        {
            return this.LibreriaContext.sales.Any(st => st.ord_num == name);
        }

        public List<Sales> GetAll()
        {
            return this.LibreriaContext.sales.ToList();

        }

        public Sales GetById(string Sale)
        {
            return this.LibreriaContext.sales.Find(Sale);
        }

        public void Remove(Sales Sale)
        {
            try
            {
                Sales salesToRemove = this.GetById(Sale.stor_id);

                salesToRemove.Deleted = true;
                salesToRemove.DeletedDate = DateTime.Now;
                salesToRemove.UserDeleted = Sale.UserDeleted;


                this.LibreriaContext.sales.Update(salesToRemove);
                this.LibreriaContext.SaveChanges();


            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Error removiendo", ex.ToString());

            }
        }

        public void Save(Sales Sale)
        {
            try
            {
                Sales salesToAdd = new Sales()
                {
                    stor_id = Sale.stor_id,
                    ord_num = Sale.ord_num,
                    ord_date = DateTime.Now,
                    qty = Sale.qty,
                    payterms = Sale.payterms,
                    title_id = Sale.title_id
                };


                this.LibreriaContext.sales.Add(salesToAdd);
                this.LibreriaContext.SaveChanges();

            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Error de guardando {ex.Message}", ex.ToString());
            }
        }

        public void Update(Sales Sale)
        {
            try
            {
                Sales salesToUpdate = this.GetById(Sale.stor_id);

                salesToUpdate.stor_id = Sale.stor_id;
                salesToUpdate.title_id = Sale.title_id;
                salesToUpdate.payterms = Sale.payterms;
                salesToUpdate.qty = Sale.qty;
                salesToUpdate.ord_date = DateTime.Now;
                salesToUpdate.ord_num = Sale.ord_num;


                this.LibreriaContext.sales.Update(salesToUpdate);
                this.LibreriaContext.SaveChanges();
            }
            catch (Exception ex)
            {

                this.Logger.LogError($"Error al actualizando {ex.Message}", ex.ToString());
            }
        }

    }

}