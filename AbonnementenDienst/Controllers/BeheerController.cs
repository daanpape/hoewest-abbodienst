using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AbonnementenDienst.Models;
using System.Net;
using System.Data.Entity;

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
            ViewBag.publisherID = new SelectList(db.Publishers, "ID", "Name");
            ViewBag.categoryID = new SelectList(db.Categories, "ID", "Name");
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

            ViewBag.publisherID = new SelectList(db.Publishers, "ID", "Name");
            ViewBag.categoryID = new SelectList(db.Categories, "ID", "Name");

            /* Return partial view if it's an Ajax request */
            if (Request.IsAjaxRequest())
            {
                return PartialView("CreateFormPartial", magazine);
            }
            else
            {
                return View(magazine);
            }
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
            Magazine todel = db.Magazines.Find(magazine.ID);
            db.Magazines.Remove(todel);
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

            ViewBag.publisherID = new SelectList(db.Publishers, "ID", "Name");
            ViewBag.categoryID = new SelectList(db.Categories, "ID", "Name");
            return View(magazine);
        }

        // POST: Edit a magazine
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Magazine magazine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(magazine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.publisherID = new SelectList(db.Publishers, "ID", "Name");
            ViewBag.categoryID = new SelectList(db.Categories, "ID", "Name");
            return View(magazine);
        }

        // Create a new category
        [HttpGet]
        public ViewResult CreateCategory()
        {
            return View();
        }

        // Save a new category
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // Create a new publisher
        [HttpGet]
        public ViewResult CreatePublisher()
        {
            return View();
        }

        // Save a new publisher
        [HttpPost]
        public ActionResult CreatePublisher(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

    }
}