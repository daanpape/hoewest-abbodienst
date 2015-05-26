using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AbonnementenDienst.Models;

namespace AbonnementenDienst.Controllers
{
    public class AbonnementController : Controller
    {
        private MagazineContext db = new MagazineContext();

        // GET: Starpagina abonneren 
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        // GET: overzichtpagina van de magazines
        [HttpGet]
        public ViewResult Overview()
        {
            if (TempData["subscriber"] == null)
            {
                ViewBag.Subscriber = new Subscriber { salutation = "Dhr", name = "Janssens", firstname = "Jan" };
            }
            else
            {
                ViewBag.Subscriber = (Subscriber)TempData["subscriber"];
            }

            /* Fetch list of all magazines */
            var magazines = db.Magazines.ToList();
            ViewBag.magazines = magazines;

            return View();
        }

        // GET: 
        [HttpGet]
        public ViewResult Result()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                TempData["subscriber"] = subscriber;
                return RedirectToAction("Overview");
            }

            return View(subscriber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}