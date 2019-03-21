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
    public class RentAVansController : Controller
    {
        private RentACarEntities1 db = new RentACarEntities1();

        // GET: RentAVans
        public ActionResult Index()
        {
            return View(db.RentAVans.ToList());
        }

        // GET: RentAVans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentAVan rentAVan = db.RentAVans.Find(id);
            if (rentAVan == null)
            {
                return HttpNotFound();
            }
            return View(rentAVan);
        }

        // GET: RentAVans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentAVans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentAVanID,vanID,firstName,lastName,duation,HireDate,EmailAddress,phoneNumber")] RentAVan rentAVan)
        {
            if (ModelState.IsValid)
            {
                db.RentAVans.Add(rentAVan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentAVan);
        }

        // GET: RentAVans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentAVan rentAVan = db.RentAVans.Find(id);
            if (rentAVan == null)
            {
                return HttpNotFound();
            }
            return View(rentAVan);
        }

        // POST: RentAVans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentAVanID,vanID,firstName,lastName,duation,HireDate,EmailAddress,phoneNumber")] RentAVan rentAVan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentAVan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentAVan);
        }

        // GET: RentAVans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentAVan rentAVan = db.RentAVans.Find(id);
            if (rentAVan == null)
            {
                return HttpNotFound();
            }
            return View(rentAVan);
        }

        // POST: RentAVans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentAVan rentAVan = db.RentAVans.Find(id);
            db.RentAVans.Remove(rentAVan);
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
