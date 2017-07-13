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
    public class yardsController : Controller
    {
        private databaseEntities db = new databaseEntities();

        // GET: yards
        public ActionResult Index()
        {
            return View(db.yards.ToList());
        }

        // GET: yards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yard yard = db.yards.Find(id);
            if (yard == null)
            {
                return HttpNotFound();
            }
            return View(yard);
        }

        // GET: yards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: yards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,yardName")] yard yard)
        {
            if (ModelState.IsValid)
            {
                db.yards.Add(yard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yard);
        }

        // GET: yards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yard yard = db.yards.Find(id);
            if (yard == null)
            {
                return HttpNotFound();
            }
            return View(yard);
        }

        // POST: yards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,yardName")] yard yard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yard);
        }

        // GET: yards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yard yard = db.yards.Find(id);
            if (yard == null)
            {
                return HttpNotFound();
            }
            return View(yard);
        }

        // POST: yards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            yard yard = db.yards.Find(id);
            db.yards.Remove(yard);
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
