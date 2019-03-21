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
    public class RentAMiniBusController : Controller
    {
        private RentACarEntities1 db = new RentACarEntities1();

        // GET: RentAMiniBus
        public ActionResult Index()
        {
            return View(db.RentAMiniBus.ToList());
        }

        // GET: RentAMiniBus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentAMiniBu rentAMiniBu = db.RentAMiniBus.Find(id);
            if (rentAMiniBu == null)
            {
                return HttpNotFound();
            }
            return View(rentAMiniBu);
        }

        // GET: RentAMiniBus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentAMiniBus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentAMiniBusID,firstName,lastName,emailAddess,hireDate,phoneNumber,MinibusID")] RentAMiniBu rentAMiniBu)
        {
            if (ModelState.IsValid)
            {
                db.RentAMiniBus.Add(rentAMiniBu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentAMiniBu);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }

        // GET: RentAMiniBus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentAMiniBu rentAMiniBu = db.RentAMiniBus.Find(id);
            if (rentAMiniBu == null)
            {
                return HttpNotFound();
            }
            return View(rentAMiniBu);
        }

        // POST: RentAMiniBus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentAMiniBusID,firstName,lastName,emailAddess,hireDate,phoneNumber,MinibusID")] RentAMiniBu rentAMiniBu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentAMiniBu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentAMiniBu);
        }

        // GET: RentAMiniBus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentAMiniBu rentAMiniBu = db.RentAMiniBus.Find(id);
            if (rentAMiniBu == null)
            {
                return HttpNotFound();
            }
            return View(rentAMiniBu);
        }

        // POST: RentAMiniBus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentAMiniBu rentAMiniBu = db.RentAMiniBus.Find(id);
            db.RentAMiniBus.Remove(rentAMiniBu);
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
