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
    public class RacunController : Controller
    {
        private SkladisteContext db = new SkladisteContext();

        // GET: Racun
        public ActionResult Zakljuci()
        {
            var racun = new Racun();
            racun.RacunID = Guid.NewGuid();
            racun.Vrijeme = DateTime.Now;
            
            var stavke = db.Stavke.Where(stavka => stavka.RacunID == Guid.Empty).ToList();
            foreach (var item in stavke)
            {
                item.RacunID = racun.RacunID;
                racun.UkupnoZaPlatiti += item.Ukupno;
                db.Entry(item).State = EntityState.Modified;
            }
            db.Racuni.Add(racun);

            db.SaveChanges();

            return RedirectToAction("Details", new
            {
                id = racun.RacunID
            });
        }

        // GET: Racun
        public ActionResult Index()
        {
            return View(db.Racuni.ToList());
        }

        // GET: Racun/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racuni.Find(id);
            racun.Stavke = db.Stavke.Where(item => item.RacunID == id.Value).ToList();
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // GET: Racun/Create
        public ActionResult Create()
        {
            var racun = new Racun { Stavke = new List<Stavka>() };
            return View(racun);
        }

        // POST: Racun/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RacunID,Vrijeme,UkupnoZaPlatiti")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                racun.RacunID = Guid.NewGuid();
                db.Racuni.Add(racun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(racun);
        }

        // GET: Racun/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racuni.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // POST: Racun/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RacunID,Vrijeme,UkupnoZaPlatiti")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(racun);
        }

        // GET: Racun/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racuni.Find(id);
            racun.Stavke = db.Stavke.Where(item => item.RacunID == id.Value).ToList();
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // POST: Racun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Racun racun = db.Racuni.Find(id);
            db.Racuni.Remove(racun);
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
