using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace libreriaApp.Web.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: AuthorsController
        public ActionResult Index()
        {
            List<Models.AuthorsModels> authors = new List<Models.AuthorsModels>()
            {
                new Models.AuthorsModels()
                {
                    au_id=1,au_lname="White",au_fname="Johson",phone="408-496-7223",address="10932 Bigge Rd.",city="Menlo Park",state="CA",zip="94025",contact=1
                },
                new Models.AuthorsModels()
                {
                    au_id=2,au_lname="Green",au_fname="Marjorie",phone="415-986-7020",address="309 63rd ST. #411",city="Oakland",state="CA",zip="94618",contact=1
                },
                new Models.AuthorsModels()
                {
                    au_id=3,au_lname="Carson",au_fname="Cheryl",phone="415-548-7723",address="589 Darwin Ln.",city="Berkely",state="CA",zip="94705",contact=1
                },
                new Models.AuthorsModels()
                {
                    au_id=4,au_lname="O'Leary",au_fname="Michael",phone="408-286-2428",address="22 Cleveland Av #14",city="San Jose",state="CA",zip="95128",contact=1
                }
                ,new Models.AuthorsModels()
                {
                    au_id=5,au_lname="Straight",au_fname="Dean",phone="415-834-2919",address="5420 College Av.",city="Oakland",state="CA",zip="94609",contact=1
                }
            };
            return View(authors);
        }

        // GET: AuthorsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorsController/Create
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

        // GET: AuthorsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthorsController/Edit/5
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

        // GET: AuthorsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthorsController/Delete/5
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
