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
    public class ShiftWorksController : Controller
    {
        private DLKB db = new DLKB();

        // GET: Admin/ShiftWorks
        public ActionResult Index()
        {
            return View(db.ShiftWork.ToList());
        }

        // GET: Admin/ShiftWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftWork shiftWork = db.ShiftWork.Find(id);
            if (shiftWork == null)
            {
                return HttpNotFound();
            }
            return View(shiftWork);
        }

        // GET: Admin/ShiftWorks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ShiftWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShiftWork_ID,ShiftWork_Name,ShiftWork_Date,ShiftWork_Start,ShiftWork_END")] ShiftWork shiftWork)
        {
            if (ModelState.IsValid)
            {
                db.ShiftWork.Add(shiftWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shiftWork);
        }

        // GET: Admin/ShiftWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftWork shiftWork = db.ShiftWork.Find(id);
            if (shiftWork == null)
            {
                return HttpNotFound();
            }
            return View(shiftWork);
        }

        // POST: Admin/ShiftWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShiftWork_ID,ShiftWork_Name,ShiftWork_Date,ShiftWork_Start,ShiftWork_END")] ShiftWork shiftWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shiftWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shiftWork);
        }

        // GET: Admin/ShiftWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftWork shiftWork = db.ShiftWork.Find(id);
            if (shiftWork == null)
            {
                return HttpNotFound();
            }
            return View(shiftWork);
        }

        // POST: Admin/ShiftWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShiftWork shiftWork = db.ShiftWork.Find(id);
            db.ShiftWork.Remove(shiftWork);
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
