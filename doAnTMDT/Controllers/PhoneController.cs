using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using doAnTMDT.Models;

namespace doAnTMDT.Controllers
{
    public class PhoneController : Controller
    {
        private PhoneDbContext db = new PhoneDbContext();

        // GET: Phone
        public ActionResult Index()
        {
            var phone = db.Phone.Include(p => p.Category);
            return View(phone.ToList());
        }

        // GET: Phone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phone.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // GET: Phone/Create
        public ActionResult Create()
        {
            ViewBag.CateID = new SelectList(db.Category, "CateID", "CateName");
            return View();
        }

        // POST: Phone/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhoneID,PhoneName,PhonePrice,PhoneDescription,PublisherDate,Image,CateID")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Phone.Add(phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CateID = new SelectList(db.Category, "CateID", "CateName", phone.CateID);
            return View(phone);
        }

        // GET: Phone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phone.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            ViewBag.CateID = new SelectList(db.Category, "CateID", "CateName", phone.CateID);
            return View(phone);
        }

        // POST: Phone/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhoneID,PhoneName,PhonePrice,PhoneDescription,PublisherDate,Image,CateID")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CateID = new SelectList(db.Category, "CateID", "CateName", phone.CateID);
            return View(phone);
        }

        // GET: Phone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phone phone = db.Phone.Find(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        // POST: Phone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phone phone = db.Phone.Find(id);
            db.Phone.Remove(phone);
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
