using libreriaApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using libreriaApp.Web.Models;

namespace libreriaApp.Web.Controllers
{
    public class TitleController : Controller
    {
        // GET: TitleController
        public ActionResult Index()
        {
            List<TitleModel> titles = new List<TitleModel>()
            {
                new TitleModel()
                {
                    Id = 1,
                    Title = "Harry Potter and philosopher's stone",
                    Type = "Fantasy",
                    Price = 13.99,
                    PubDate = System.DateTime.Now
                },
                new TitleModel()
                {
                    Id = 2,
                    Title = "The Shining",
                    Type = "Horror",
                    Price = 19.99,
                    PubDate = System.DateTime.Now
                },
                new TitleModel()
                {
                    Id = 3,
                    Title = "Morning Glory",
                    Type = "Romance",
                    Price = 7.99,
                    PubDate = System.DateTime.Now
                },

            };

            return View(titles);
        }

        // GET: TitleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TitleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TitleController/Create
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

        // GET: TitleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TitleController/Edit/5
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

        // GET: TitleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TitleController/Delete/5
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
