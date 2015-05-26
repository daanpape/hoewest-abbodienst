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
            if (TempData.Peek("subscriber") == null)
            {
                ViewBag.subscriber = new Subscriber { salutation = "Dhr", name = "Janssens", firstname = "Jan" };
            }
            else
            {
                ViewBag.subscriber = (Subscriber) TempData.Peek("subscriber");
            }

            /* Fetch list of all magazines */
            var magazines = db.Magazines.ToList();
            ViewBag.magazines = magazines;

            return View();
        }

        // GET: The result 
        [HttpGet]
        public ViewResult Result()
        {
            Subscription subscription = (Subscription) TempData["subscription"];
            Subscriber subscriber = (Subscriber)TempData["subscriber"];
            var magazine = db.Magazines.Find(subscription.magazineID);

            /* Pass data to view */
            ViewBag.subscription = subscription;
            ViewBag.subscriber = subscriber;
            ViewBag.magazine = magazine;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Overview(Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                TempData["subscription"] = subscription;
                return RedirectToAction("Result");
            }

            return View(subscription);
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