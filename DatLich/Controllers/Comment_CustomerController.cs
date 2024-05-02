using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatLich.Models;

namespace DatLich.Controllers
{
    public class Comment_CustomerController : Controller
    {
        private DLKB db = new DLKB();

        // GET: Comment_Customer
        public ActionResult Index()
        {
            var comment_Customer = db.Comment_Customer.Include(c => c.Customer);
            return View(comment_Customer.ToList());
        }

        // GET: Comment_Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment_Customer comment_Customer = db.Comment_Customer.Find(id);
            if (comment_Customer == null)
            {
                return HttpNotFound();
            }
            return View(comment_Customer);
        }

        // GET: Comment_Customer/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name");
            return View();
        }

        // POST: Comment_Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentCustomer_ID,CommentCustomer_Content,CommentCustomer_TimeOrder,Customer_ID")] Comment_Customer comment_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Comment_Customer.Add(comment_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name", comment_Customer.Customer_ID);
            return View(comment_Customer);
        }

        // GET: Comment_Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment_Customer comment_Customer = db.Comment_Customer.Find(id);
            if (comment_Customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name", comment_Customer.Customer_ID);
            return View(comment_Customer);
        }

        // POST: Comment_Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentCustomer_ID,CommentCustomer_Content,CommentCustomer_TimeOrder,Customer_ID")] Comment_Customer comment_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name", comment_Customer.Customer_ID);
            return View(comment_Customer);
        }

        // GET: Comment_Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment_Customer comment_Customer = db.Comment_Customer.Find(id);
            if (comment_Customer == null)
            {
                return HttpNotFound();
            }
            return View(comment_Customer);
        }

        // POST: Comment_Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment_Customer comment_Customer = db.Comment_Customer.Find(id);
            db.Comment_Customer.Remove(comment_Customer);
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
