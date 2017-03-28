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
    public class ArtikalController : Controller
    {
        private SkladisteContext db = new SkladisteContext();

        // GET: Artikal
        public ActionResult Index()
        {
            var artikli = db.Artikli.Include(a => a.Mjera);
            return View(artikli.ToList());
        }

        // GET: Artikal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikal artikal = db.Artikli.Find(id);
            if (artikal == null)
            {
                return HttpNotFound();
            }
            return View(artikal);
        }

        // GET: Artikal/Create
        public ActionResult Create()
        {
            ViewBag.MjeraID = new SelectList(db.Mjere, "MjeraID", "Naziv");
            return View();
        }

        // POST: Artikal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtikalID,Naziv,Cijena,Kolicina,MjeraID")] Artikal artikal)
        {
            if (ModelState.IsValid)
            {
                db.Artikli.Add(artikal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MjeraID = new SelectList(db.Mjere, "MjeraID", "Naziv", artikal.MjeraID);
            return View(artikal);
        }

        // GET: Artikal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikal artikal = db.Artikli.Find(id);
            if (artikal == null)
            {
                return HttpNotFound();
            }
            ViewBag.MjeraID = new SelectList(db.Mjere, "MjeraID", "Naziv", artikal.MjeraID);
            return View(artikal);
        }

        // POST: Artikal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtikalID,Naziv,Cijena,Kolicina,MjeraID")] Artikal artikal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artikal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MjeraID = new SelectList(db.Mjere, "MjeraID", "Naziv", artikal.MjeraID);
            return View(artikal);
        }

        // GET: Artikal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikal artikal = db.Artikli.Find(id);
            if (artikal == null)
            {
                return HttpNotFound();
            }
            return View(artikal);
        }

        // POST: Artikal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artikal artikal = db.Artikli.Find(id);
            db.Artikli.Remove(artikal);
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
