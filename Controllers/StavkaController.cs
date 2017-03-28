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
    public class StavkaController : Controller
    {
        private SkladisteContext db = new SkladisteContext();

        // GET: Stavkas
        public ActionResult Index()
        {
            var stavke = db.Stavke
                .Where(s => s.RacunID == Guid.Empty)
                .Include(s => s.Racun)   
                .Include(s => s.Proizvod);
            return View(stavke.ToList());
        }

        // GET: Stavkas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stavka stavka = db.Stavke.Find(id);
            if (stavka == null)
            {
                return HttpNotFound();
            }
            return View(stavka);
        }

        // GET: Stavkas/Create
        public ActionResult Create()
        {
            var model = new Stavka();
            model.RedniBroj = db.Stavke.Count() + 1;

            var listaProizvoda = db.Proizvodi
                .Select(proizvod => new
                {
                    ProizvodID = proizvod.ProizvodID,
                    SifraINaziv = proizvod.Sifra + " - " + proizvod.Naziv,
                    CijenaProizvoda = proizvod.Cijena
                });

            ViewBag.ProizvodID = new SelectList(listaProizvoda, "ProizvodID", "SifraINaziv");
            return View(model);
        }

        // POST: Stavkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StavkaID,RedniBroj,ProizvodID,Kolicina,Cijena,Ukupno")] Stavka stavka)
        {
            if (ModelState.IsValid)
            {
                stavka.RedniBroj = db.Stavke.Count() + 1;
                db.Stavke.Add(stavka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProizvodID = new SelectList(db.Proizvodi, "ProizvodID", "Naziv", stavka.ProizvodID);
            return View(stavka);
        }

        // GET: Stavkas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stavka stavka = db.Stavke.Find(id);
            if (stavka == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProizvodID = new SelectList(db.Proizvodi, "ProizvodID", "Naziv", stavka.ProizvodID);
            return View(stavka);
        }

        // POST: Stavkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StavkaID,RedniBroj,ProizvodID,Kolicina,Cijena,Ukupno")] Stavka stavka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stavka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProizvodID = new SelectList(db.Proizvodi, "ProizvodID", "Naziv", stavka.ProizvodID);
            return View(stavka);
        }

        // GET: Stavkas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stavka stavka = db.Stavke.Find(id);
            if (stavka == null)
            {
                return HttpNotFound();
            }
            return View(stavka);
        }

        // POST: Stavkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stavka stavka = db.Stavke.Find(id);
            db.Stavke.Remove(stavka);
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
