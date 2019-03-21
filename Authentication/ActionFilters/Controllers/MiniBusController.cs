using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ActionFilters.Models;

namespace ActionFilters.Controllers
{
    public class MiniBusController : Controller
    {
        private RentACarEntities1 db = new RentACarEntities1();

        // GET: MiniBus
        public ActionResult Index()
        {
            var miniBus = db.MiniBus.Include(m => m.RentAMiniBu);
            return View(miniBus.ToList());
        }

        // GET: MiniBus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiniBu miniBu = db.MiniBus.Find(id);
            if (miniBu == null)
            {
                return HttpNotFound();
            }
            return View(miniBu);
        }

        // GET: MiniBus/Create
        public ActionResult Create()
        {
            ViewBag.RentAMiniBus_RentAMiniBusID = new SelectList(db.RentAMiniBus, "RentAMiniBusID", "firstName");
            return View();
        }

        // POST: MiniBus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MinibusID,regNumber,MiniBusColour,miniBusManufacturer,numberOfSeats,miniBusSize,RentAMiniBus_RentAMiniBusID")] MiniBu miniBu)
        {
            if (ModelState.IsValid)
            {
                db.MiniBus.Add(miniBu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RentAMiniBus_RentAMiniBusID = new SelectList(db.RentAMiniBus, "RentAMiniBusID", "firstName", miniBu.RentAMiniBus_RentAMiniBusID);
            return View(miniBu);
        }

        // GET: MiniBus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiniBu miniBu = db.MiniBus.Find(id);
            if (miniBu == null)
            {
                return HttpNotFound();
            }
            ViewBag.RentAMiniBus_RentAMiniBusID = new SelectList(db.RentAMiniBus, "RentAMiniBusID", "firstName", miniBu.RentAMiniBus_RentAMiniBusID);
            return View(miniBu);
        }

        // POST: MiniBus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MinibusID,regNumber,MiniBusColour,miniBusManufacturer,numberOfSeats,miniBusSize,RentAMiniBus_RentAMiniBusID")] MiniBu miniBu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miniBu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RentAMiniBus_RentAMiniBusID = new SelectList(db.RentAMiniBus, "RentAMiniBusID", "firstName", miniBu.RentAMiniBus_RentAMiniBusID);
            return View(miniBu);
        }

        // GET: MiniBus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiniBu miniBu = db.MiniBus.Find(id);
            if (miniBu == null)
            {
                return HttpNotFound();
            }
            return View(miniBu);
        }

        // POST: MiniBus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MiniBu miniBu = db.MiniBus.Find(id);
            db.MiniBus.Remove(miniBu);
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
