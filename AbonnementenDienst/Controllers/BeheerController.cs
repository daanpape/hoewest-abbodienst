using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AbonnementenDienst.Models;

namespace AbonnementenDienst.Controllers
{
    public class BeheerController : Controller
    {
        private MagazineContext db = new MagazineContext();

        // GET: index overzicht
        public ActionResult Index()
        {
            var magazines = db.Magazines.ToList();
            return View(magazines);
        }

        // GET: Beheer
        public ActionResult Create()
        {
            return View();
        }
    }
}