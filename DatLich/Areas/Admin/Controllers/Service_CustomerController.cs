using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatLich.Models;

namespace DatLich.Areas.Admin.Controllers
{
    public class Service_CustomerController : Controller
    {
        private DLKB db = new DLKB();

        // GET: Admin/Service_Customer
        public ActionResult Index()
        {
            return View(db.Service_Customer.ToList());
        }

        // GET: Admin/Service_Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_Customer service_Customer = db.Service_Customer.Find(id);
            if (service_Customer == null)
            {
                return HttpNotFound();
            }
            return View(service_Customer);
        }

        // GET: Admin/Service_Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Service_Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceCustomer_ID,ServiceCustomer_Name,ServiceCustomer_Price,ServiceCustomer_Unit,ServiceCustomer_Infor")] Service_Customer service_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Service_Customer.Add(service_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service_Customer);
        }

        // GET: Admin/Service_Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_Customer service_Customer = db.Service_Customer.Find(id);
            if (service_Customer == null)
            {
                return HttpNotFound();
            }
            return View(service_Customer);
        }

        // POST: Admin/Service_Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceCustomer_ID,ServiceCustomer_Name,ServiceCustomer_Price,ServiceCustomer_Unit,ServiceCustomer_Infor")] Service_Customer service_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service_Customer);
        }

        // GET: Admin/Service_Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_Customer service_Customer = db.Service_Customer.Find(id);
            if (service_Customer == null)
            {
                return HttpNotFound();
            }
            return View(service_Customer);
        }

        // POST: Admin/Service_Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service_Customer service_Customer = db.Service_Customer.Find(id);
            db.Service_Customer.Remove(service_Customer);
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
