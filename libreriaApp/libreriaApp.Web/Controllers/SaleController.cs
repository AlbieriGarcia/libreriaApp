using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using libreriaApp.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace libreriaApp.Web.Controllers
{
    public class SaleController : Controller
    {
        // GET: SaleController

        public ActionResult Index()
        {
            List<SaleModel> sales = new List<SaleModel>() 
            { 
                new SaleModel() 
                {

                    Id = 1, 
                    ord_nom = "1",
                    title_id = "30",                  
                    qty = 70,
                    payterms = "net 60",
                    ord_date = System.DateTime.Now,
                },


                new SaleModel()
                {

                    Id = 2, 
                    ord_nom = "2",
                    title_id = "30",
                    qty = 43,
                    payterms = "net 60",
                    ord_date = System.DateTime.Now,
                },

                new SaleModel()
                {

                    Id = 3, 
                    ord_nom = "3",
                    title_id = "35",
                    qty = 30,
                    payterms = "60",
                    ord_date = System.DateTime.Now,
                },

                new SaleModel()
                {

                    Id = 4, 
                    ord_nom = "4",
                    title_id = "16",
                    qty = 25,
                    payterms = "50",
                    ord_date = System.DateTime.Now,
                }

            };
            return View(sales);
        }

        // GET: SaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
