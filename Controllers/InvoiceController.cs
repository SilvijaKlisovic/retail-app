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
using RetailApp.Misc;

namespace RetailApp.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        private Logger logger = new Logger();
        private RetailAppContext db = new RetailAppContext();

        // GET: Invoice
        public ActionResult Zakljuci()
        {
            var racun = new Invoice();

            var stavke = db.InvoiceLines.Where(stavka => stavka.InvoiceID == null).ToList();
            foreach (var item in stavke)
            {
                item.InvoiceID = racun.InvoiceID;
                racun.UkupnoZaPlatiti += item.Ukupno;
                db.Entry(item).State = EntityState.Modified;
            }

            racun.Fiskaliziraj();
            db.Invoices.Add(racun);

            db.SaveChanges();
            try
            {
                logger.Loggs.InsertOne(new Loog { type = "info",
                    Message = "Created Invoice: " + racun.InvoiceID +
                    " JIR:" + racun.JIRRacuna +
                    " Total:" + racun.UkupnoZaPlatiti +
                    " Time:" + racun.Vrijeme
                    , dateTime = DateTime.UtcNow.ToString() });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return RedirectToAction("Details", new
            {
                id = racun.InvoiceID
            });
        }

        // GET: Invoice
        public ActionResult Index()
        {
            return View(db.Invoices.ToList());
        }

        // GET: Invoice/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice racun = db.Invoices.Find(id);
            racun.InvoiceLines = db.InvoiceLines.Where(item => item.InvoiceID == id.Value).ToList();
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            var racun = new Invoice { InvoiceLines = new List<InvoiceLine>() };
            return View(racun);
        }

        // POST: Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceID,Vrijeme,UkupnoZaPlatiti")] Invoice racun)
        {
            if (ModelState.IsValid)
            {
                racun.InvoiceID = Guid.NewGuid();
                db.Invoices.Add(racun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(racun);
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice racun = db.Invoices.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // POST: Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceID,Vrijeme,UkupnoZaPlatiti")] Invoice racun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(racun);
        }

        // GET: Invoice/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice racun = db.Invoices.Find(id);
            racun.InvoiceLines = db.InvoiceLines.Where(item => item.InvoiceID == id.Value).ToList();
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Invoice racun = db.Invoices.Find(id);
            db.Invoices.Remove(racun);
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
