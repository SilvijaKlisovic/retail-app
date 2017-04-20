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
    public class ItemController : Controller
    {
        private RetailAppContext db = new RetailAppContext();

        // GET: Item
        public ActionResult Index()
        {
            var artikli = db.Items.Include(a => a.Measure);
            return View(artikli.ToList());
        }

        // GET: Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item artikal = db.Items.Find(id);
            if (artikal == null)
            {
                return HttpNotFound();
            }
            return View(artikal);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            ViewBag.MeasureID = new SelectList(db.Measures, "MeasureID", "Naziv");
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,Naziv,Cijena,Kolicina,MeasureID")] Item artikal)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(artikal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeasureID = new SelectList(db.Measures, "MeasureID", "Naziv", artikal.MeasureID);
            return View(artikal);
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item artikal = db.Items.Find(id);
            if (artikal == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeasureID = new SelectList(db.Measures, "MeasureID", "Naziv", artikal.MeasureID);
            return View(artikal);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,Naziv,Cijena,Kolicina,MeasureID")] Item artikal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artikal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeasureID = new SelectList(db.Measures, "MeasureID", "Naziv", artikal.MeasureID);
            return View(artikal);
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item artikal = db.Items.Find(id);
            if (artikal == null)
            {
                return HttpNotFound();
            }
            return View(artikal);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item artikal = db.Items.Find(id);
            db.Items.Remove(artikal);
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
