using libreriaApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace libreriaApp.Web.Controllers
{
    public class PublisherController : Controller
    {
        // GET: PublisherController
        public ActionResult Index()
        {
            List<PublisherModel> publisher = new List<PublisherModel>()

            {
                new PublisherModel
                { Id = 1,
                Name = "Albert Whitman & Company",
                City = "New York",
                State = "MA",
                Country = "New York"
                },

                new PublisherModel
                { Id = 2,
                Name = "Bancroft Press",
                City = "New York",
                State = "DC",
                Country = "New York"
                },

                new PublisherModel
                { Id = 3,
                Name = "Regal House Publishing",
                City = "New York",
                State = "CA",
                Country = "New York"
                },

            };
            return View(publisher);

        }

        // GET: PublisherController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PublisherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublisherController/Create
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

        // GET: PublisherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PublisherController/Edit/5
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

        // GET: PublisherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PublisherController/Delete/5
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
