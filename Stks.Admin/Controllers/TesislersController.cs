using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Stks.Admin;

namespace Stks.Admin.Controllers
{
    public class TesislersController : Controller
    {
        private adminEntities db = new adminEntities();

        // GET: Tesislers
        public ActionResult Index()
        {
            return View(db.Tesisler.ToList());
        }

        // GET: Tesislers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tesisler tesisler = db.Tesisler.Find(id);
            if (tesisler == null)
            {
                return HttpNotFound();
            }
            return View(tesisler);
        }

        // GET: Tesislers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tesislers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,tesisAdi,sahaAdi,sporTuru,il,ilce,adres,telNo,servis,resim,saatDilimi,acilisSaati,kapanisSaati,ucret")] Tesisler tesisler)
        {
            if (ModelState.IsValid)
            {
                db.Tesisler.Add(tesisler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tesisler);
        }

        // GET: Tesislers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tesisler tesisler = db.Tesisler.Find(id);
            if (tesisler == null)
            {
                return HttpNotFound();
            }
            return View(tesisler);
        }

        // POST: Tesislers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,tesisAdi,sahaAdi,sporTuru,il,ilce,adres,telNo,servis,resim,saatDilimi,acilisSaati,kapanisSaati,ucret")] Tesisler tesisler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tesisler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tesisler);
        }

        // GET: Tesislers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tesisler tesisler = db.Tesisler.Find(id);
            if (tesisler == null)
            {
                return HttpNotFound();
            }
            return View(tesisler);
        }

        // POST: Tesislers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tesisler tesisler = db.Tesisler.Find(id);
            db.Tesisler.Remove(tesisler);
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
