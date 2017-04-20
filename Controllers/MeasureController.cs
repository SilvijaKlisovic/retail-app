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
    public class MeasureController : Controller
    {
        private RetailAppContext db = new RetailAppContext();

        // GET: Measure
        public ActionResult Index()
        {
            return View(db.Measures.ToList());
        }

        // GET: Measure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure mjera = db.Measures.Find(id);
            if (mjera == null)
            {
                return HttpNotFound();
            }
            return View(mjera);
        }

        // GET: Measure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Measure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeasureID,Naziv")] Measure mjera)
        {
            if (ModelState.IsValid)
            {
                db.Measures.Add(mjera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mjera);
        }

        // GET: Measure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure mjera = db.Measures.Find(id);
            if (mjera == null)
            {
                return HttpNotFound();
            }
            return View(mjera);
        }

        // POST: Measure/Edit/5
        // To protect from overposting attacks, please enable the specific properties 
        // you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeasureID,Naziv")] Measure mjera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mjera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mjera);
        }

        // GET: Measure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure mjera = db.Measures.Find(id);
            if (mjera == null)
            {
                return HttpNotFound();
            }
            return View(mjera);
        }

        // POST: Measure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Measure mjera = db.Measures.Find(id);
            db.Measures.Remove(mjera);
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
