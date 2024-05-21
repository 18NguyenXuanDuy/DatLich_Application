using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatLich.Models;

namespace DatLich.Controllers
{
    public class CustomersController : Controller
    {
        private DLKB db = new DLKB();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customer.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            string email = Session["Login"] as string;
            var user = db.Customer.FirstOrDefault(u => u.Customer_Email == email);
            id = user.Customer_ID;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customer_ID,Customer_Name,Customer_Email,Customer_Age,Customer_Phone,Customer_Gender,Customer_Img")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Customer_ID,Customer_Name,Customer_Email,Customer_Age,Customer_Phone,Customer_Gender,Customer_Img")] Customer customer, HttpPostedFileBase uploadhinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;

                string email = Session["Login"] as string;
                var user = db.Customer.FirstOrDefault(u => u.Customer_Email == email);
                if (user == null)
                {
                    RedirectToAction("Index", "Home");
                }
                else
                {

                    if (uploadhinh != null && uploadhinh.ContentLength > 0)
                    {
                        int id = customer.Customer_ID;

                        string _FileName = "";
                        int index = uploadhinh.FileName.IndexOf('.');
                        _FileName = "Customer_" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                        string _path = Path.Combine(Server.MapPath("~/Upload/Customer"), _FileName);
                        uploadhinh.SaveAs(_path);
                        customer.Customer_Img = _FileName;
                    }

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
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
