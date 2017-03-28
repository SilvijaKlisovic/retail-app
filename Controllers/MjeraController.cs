using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrvaAplikacija.DAL;
using PrvaAplikacija.Models;

namespace PrvaAplikacija.Controllers
{
    public class MjeraController : Controller
    {
        private SkladisteContext db = new SkladisteContext();

        // GET: Mjera
        public ActionResult Index()
        {
            return View(db.Mjere.ToList());
        }

        // GET: Mjera/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mjera mjera = db.Mjere.Find(id);
            if (mjera == null)
            {
                return HttpNotFound();
            }
            return View(mjera);
        }

        // GET: Mjera/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mjera/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MjeraID,Naziv")] Mjera mjera)
        {
            if (ModelState.IsValid)
            {
                db.Mjere.Add(mjera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mjera);
        }

        // GET: Mjera/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mjera mjera = db.Mjere.Find(id);
            if (mjera == null)
            {
                return HttpNotFound();
            }
            return View(mjera);
        }

        // POST: Mjera/Edit/5
        // To protect from overposting attacks, please enable the specific properties 
        // you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MjeraID,Naziv")] Mjera mjera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mjera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mjera);
        }

        // GET: Mjera/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mjera mjera = db.Mjere.Find(id);
            if (mjera == null)
            {
                return HttpNotFound();
            }
            return View(mjera);
        }

        // POST: Mjera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mjera mjera = db.Mjere.Find(id);
            db.Mjere.Remove(mjera);
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
