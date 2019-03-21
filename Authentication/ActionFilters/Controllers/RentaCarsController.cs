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
    public class RentaCarsController : Controller
    {
        private RentACarEntities1 db = new RentACarEntities1();

        // GET: RentaCars
        public ActionResult Index()
        {
            return View(db.RentaCars.ToList());
        }

        // GET: RentaCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentaCar rentaCar = db.RentaCars.Find(id);
            if (rentaCar == null)
            {
                return HttpNotFound();
            }
            return View(rentaCar);
        }

        // GET: RentaCars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentaCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rentACarID,firstName,LastName,Age,hireDate,CarID,duration,emailAddress,phoneNumber")] RentaCar rentaCar)
        {
            if (ModelState.IsValid)
            {
                db.RentaCars.Add(rentaCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentaCar);
        }

        // GET: RentaCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentaCar rentaCar = db.RentaCars.Find(id);
            if (rentaCar == null)
            {
                return HttpNotFound();
            }
            return View(rentaCar);
        }

        // POST: RentaCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rentACarID,firstName,LastName,Age,hireDate,CarID,duration,emailAddress,phoneNumber")] RentaCar rentaCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentaCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentaCar);
        }

        // GET: RentaCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentaCar rentaCar = db.RentaCars.Find(id);
            if (rentaCar == null)
            {
                return HttpNotFound();
            }
            return View(rentaCar);
        }

        // POST: RentaCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentaCar rentaCar = db.RentaCars.Find(id);
            db.RentaCars.Remove(rentaCar);
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
