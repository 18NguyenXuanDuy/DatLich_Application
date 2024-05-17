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
    public class ShiftWork_AppointController : Controller
    {
        private DLKB db = new DLKB();

        // GET: ShiftWork_Appoint
        public ActionResult Index()
        {
            var shiftWork_Appoint = db.ShiftWork_Appoint.Include(s => s.AppointmentSchedule).Include(s => s.ShiftWork);
            return View(shiftWork_Appoint.ToList());
        }

        // GET: ShiftWork_Appoint/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftWork_Appoint shiftWork_Appoint = db.ShiftWork_Appoint.Find(id);
            if (shiftWork_Appoint == null)
            {
                return HttpNotFound();
            }
            return View(shiftWork_Appoint);
        }

        // GET: ShiftWork_Appoint/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentSchedule_ID = new SelectList(db.AppointmentSchedule, "AppointmentSchedule_ID", "AppointmentSchedule_Date");
            ViewBag.ShiftWork_ID = new SelectList(db.ShiftWork, "ShiftWork_ID", "ShiftWork_Name");
            return View();
        }

        // POST: ShiftWork_Appoint/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShiftWorkAppoint_ID,ShiftWorkAppoint_Date,Current_Quantity,Maximum_Quantity,ShiftWork_ID,AppointmentSchedule_ID")] ShiftWork_Appoint shiftWork_Appoint)
        {
            if (ModelState.IsValid)
            {
                db.ShiftWork_Appoint.Add(shiftWork_Appoint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentSchedule_ID = new SelectList(db.AppointmentSchedule, "AppointmentSchedule_ID", "AppointmentSchedule_Date", shiftWork_Appoint.AppointmentSchedule_ID);
            ViewBag.ShiftWork_ID = new SelectList(db.ShiftWork, "ShiftWork_ID", "ShiftWork_Name", shiftWork_Appoint.ShiftWork_ID);
            return View(shiftWork_Appoint);
        }

        // GET: ShiftWork_Appoint/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftWork_Appoint shiftWork_Appoint = db.ShiftWork_Appoint.Find(id);
            if (shiftWork_Appoint == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentSchedule_ID = new SelectList(db.AppointmentSchedule, "AppointmentSchedule_ID", "AppointmentSchedule_Date", shiftWork_Appoint.AppointmentSchedule_ID);
            ViewBag.ShiftWork_ID = new SelectList(db.ShiftWork, "ShiftWork_ID", "ShiftWork_Name", shiftWork_Appoint.ShiftWork_ID);
            return View(shiftWork_Appoint);
        }

        // POST: ShiftWork_Appoint/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShiftWorkAppoint_ID,ShiftWorkAppoint_Date,Current_Quantity,Maximum_Quantity,ShiftWork_ID,AppointmentSchedule_ID")] ShiftWork_Appoint shiftWork_Appoint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shiftWork_Appoint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentSchedule_ID = new SelectList(db.AppointmentSchedule, "AppointmentSchedule_ID", "AppointmentSchedule_Date", shiftWork_Appoint.AppointmentSchedule_ID);
            ViewBag.ShiftWork_ID = new SelectList(db.ShiftWork, "ShiftWork_ID", "ShiftWork_Name", shiftWork_Appoint.ShiftWork_ID);
            return View(shiftWork_Appoint);
        }

        // GET: ShiftWork_Appoint/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftWork_Appoint shiftWork_Appoint = db.ShiftWork_Appoint.Find(id);
            if (shiftWork_Appoint == null)
            {
                return HttpNotFound();
            }
            return View(shiftWork_Appoint);
        }

        // POST: ShiftWork_Appoint/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShiftWork_Appoint shiftWork_Appoint = db.ShiftWork_Appoint.Find(id);
            db.ShiftWork_Appoint.Remove(shiftWork_Appoint);
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
