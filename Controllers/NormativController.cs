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
    public class NormativController : Controller
    {
        private RetailAppContext db = new RetailAppContext();

        // GET: Normative
        public ActionResult Index()
        {
            var normativi = db.Normatives.Include(n => n.Item).Include(n => n.Product);
            return View(normativi.ToList());
        }

        // GET: Normative/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Normative normativ = db.Normatives.Find(id);
            if (normativ == null)
            {
                return HttpNotFound();
            }
            return View(normativ);
        }

        // GET: Normative/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Naziv");
            ViewBag.MeasureID = new SelectList(db.Measures, "MeasureID", "Naziv");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Naziv");
            return View();
        }

        // POST: Normative/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NormativeID,ItemID,ProductID,Koeficijent,MeasureID")] Normative normativ)
        {
            if (ModelState.IsValid)
            {
                db.Normatives.Add(normativ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Naziv", normativ.ItemID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Naziv", normativ.ProductID);
            return View(normativ);
        }

        // GET: Normative/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Normative normativ = db.Normatives.Find(id);
            if (normativ == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Naziv", normativ.ItemID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Naziv", normativ.ProductID);
            return View(normativ);
        }

        // POST: Normative/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NormativeID,ItemID,ProductID,Koeficijent,MeasureID")] Normative normativ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(normativ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Naziv", normativ.ItemID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Naziv", normativ.ProductID);
            return View(normativ);
        }

        // GET: Normative/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Normative normativ = db.Normatives.Find(id);
            if (normativ == null)
            {
                return HttpNotFound();
            }
            return View(normativ);
        }

        // POST: Normative/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Normative normativ = db.Normatives.Find(id);
            db.Normatives.Remove(normativ);
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
