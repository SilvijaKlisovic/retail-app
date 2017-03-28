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
    public class NormativController : Controller
    {
        private SkladisteContext db = new SkladisteContext();

        // GET: Normativ
        public ActionResult Index()
        {
            var normativi = db.Normativi.Include(n => n.Artikal).Include(n => n.Proizvod);
            return View(normativi.ToList());
        }

        // GET: Normativ/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Normativ normativ = db.Normativi.Find(id);
            if (normativ == null)
            {
                return HttpNotFound();
            }
            return View(normativ);
        }

        // GET: Normativ/Create
        public ActionResult Create()
        {
            ViewBag.ArtikalID = new SelectList(db.Artikli, "ArtikalID", "Naziv");
            ViewBag.MjeraID = new SelectList(db.Mjere, "MjeraID", "Naziv");
            ViewBag.ProizvodID = new SelectList(db.Proizvodi, "ProizvodID", "Naziv");
            return View();
        }

        // POST: Normativ/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NormativID,ArtikalID,ProizvodID,Koeficijent,MjeraID")] Normativ normativ)
        {
            if (ModelState.IsValid)
            {
                db.Normativi.Add(normativ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtikalID = new SelectList(db.Artikli, "ArtikalID", "Naziv", normativ.ArtikalID);
            ViewBag.ProizvodID = new SelectList(db.Proizvodi, "ProizvodID", "Naziv", normativ.ProizvodID);
            return View(normativ);
        }

        // GET: Normativ/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Normativ normativ = db.Normativi.Find(id);
            if (normativ == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtikalID = new SelectList(db.Artikli, "ArtikalID", "Naziv", normativ.ArtikalID);
            ViewBag.ProizvodID = new SelectList(db.Proizvodi, "ProizvodID", "Naziv", normativ.ProizvodID);
            return View(normativ);
        }

        // POST: Normativ/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NormativID,ArtikalID,ProizvodID,Koeficijent,MjeraID")] Normativ normativ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(normativ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtikalID = new SelectList(db.Artikli, "ArtikalID", "Naziv", normativ.ArtikalID);
            ViewBag.ProizvodID = new SelectList(db.Proizvodi, "ProizvodID", "Naziv", normativ.ProizvodID);
            return View(normativ);
        }

        // GET: Normativ/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Normativ normativ = db.Normativi.Find(id);
            if (normativ == null)
            {
                return HttpNotFound();
            }
            return View(normativ);
        }

        // POST: Normativ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Normativ normativ = db.Normativi.Find(id);
            db.Normativi.Remove(normativ);
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
