using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RetailApp.DAL;
using RetailApp.Models;

namespace RetailApp.Controllers
{
    [Authorize]
    public class InvoiceLineController : Controller
    {
        private RetailAppContext db = new RetailAppContext();

        // GET: Stavkas
        public ActionResult Index()
        {
            var stavke = db.InvoiceLines
                .Where(s => s.InvoiceID == null)
                .Include(s => s.Invoice)   
                .Include(s => s.Product);
            return View(stavke.ToList());
        }

        // GET: Stavkas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceLine stavka = db.InvoiceLines.Find(id);
            if (stavka == null)
            {
                return HttpNotFound();
            }
            return View(stavka);
        }

        // GET: Stavkas/Create
        public ActionResult Create()
        {
            var model = new InvoiceLine();
            model.RedniBroj = db.InvoiceLines.Count() + 1;

            var listaProizvoda = db.Products
                .Select(proizvod => new
                {
                    ProductID = proizvod.ProductID,
                    SifraINaziv = proizvod.Sifra + " - " + proizvod.Naziv,
                    CijenaProizvoda = proizvod.Cijena
                });

            ViewBag.ProductID = new SelectList(listaProizvoda, "ProductID", "SifraINaziv");
            return View(model);
        }

        // POST: Stavkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceLineID,RedniBroj,ProductID,Kolicina,Cijena,Ukupno")] InvoiceLine stavka)
        {
            if (ModelState.IsValid)
            {
                stavka.RedniBroj = db.InvoiceLines.Count() + 1;
                db.InvoiceLines.Add(stavka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Naziv", stavka.ProductID);
            return View(stavka);
        }

        // GET: Stavkas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceLine stavka = db.InvoiceLines.Find(id);
            if (stavka == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Naziv", stavka.ProductID);
            return View(stavka);
        }

        // POST: Stavkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceLineID,RedniBroj,ProductID,Kolicina,Cijena,Ukupno")] InvoiceLine stavka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stavka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Naziv", stavka.ProductID);
            return View(stavka);
        }

        // GET: Stavkas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceLine stavka = db.InvoiceLines.Find(id);
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
            InvoiceLine stavka = db.InvoiceLines.Find(id);
            db.InvoiceLines.Remove(stavka);
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
