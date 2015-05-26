using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AbonnementenDienst.Models;
using System.Net;

namespace AbonnementenDienst.Controllers
{
    public class BeheerController : Controller
    {
        private MagazineContext db = new MagazineContext();

        // GET: index overview
        [HttpGet]
        public ActionResult Index()
        {
            var magazines = db.Magazines.ToList();
            return View(magazines);
        }

        // GET: detail view for a magazine
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Magazine magazine = db.Magazines.Find(id);
            if (magazine == null)
            {
                return HttpNotFound();
            }

            return View(magazine);
        }

        // GET: show the create view to the user
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create a new magazine
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Magazine magazine)
        {
            if (ModelState.IsValid)
            {
                db.Magazines.Add(magazine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(magazine);
        }

        // GET: show the delete view for a magazine 
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Magazine magazine = db.Magazines.Find(id);
            if (magazine == null)
            {
                return HttpNotFound();
            }

            return View(magazine);
        }

        // POST: Delete a magazine
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Magazine magazine)
        {
            db.Magazines.Remove(magazine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: show the edit view for a magazine 
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Magazine magazine = db.Magazines.Find(id);
            if (magazine == null)
            {
                return HttpNotFound();
            }

            return View(magazine);
        }

        // POST: Edit a magazine
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Magazine magazine)
        {
            //TODO
            return RedirectToAction("Index");
        }
    }
}