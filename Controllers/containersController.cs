using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lucky.Models;

namespace lucky.Controllers
{
    [Authorize]
    public class containersController : Controller
    {
        
        private databaseEntities db = new databaseEntities();

        // GET: containers
        public ActionResult Index()
        {
            return View(db.containers.ToList());
        }

        // GET: containers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            container container = db.containers.Find(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // GET: containers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: containers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ConName")] container container)
        {
            if (ModelState.IsValid)
            {
                db.containers.Add(container);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(container);
        }

        // GET: containers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            container container = db.containers.Find(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // POST: containers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ConName")] container container)
        {
            if (ModelState.IsValid)
            {
                db.Entry(container).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(container);
        }

        // GET: containers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            container container = db.containers.Find(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // POST: containers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            container container = db.containers.Find(id);
            db.containers.Remove(container);
            db.SaveChanges();
            return RedirectToAction("Index");
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
