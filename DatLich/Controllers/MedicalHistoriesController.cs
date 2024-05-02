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
    public class MedicalHistoriesController : Controller
    {
        private DLKB db = new DLKB();

        // GET: MedicalHistories
        public ActionResult Index()
        {
            var medicalHistory = db.MedicalHistory.Include(m => m.Customer).Include(m => m.Dentist).Include(m => m.Prescription);
            return View(medicalHistory.ToList());
        }

        // GET: MedicalHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalHistory medicalHistory = db.MedicalHistory.Find(id);
            if (medicalHistory == null)
            {
                return HttpNotFound();
            }
            return View(medicalHistory);
        }

        // GET: MedicalHistories/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name");
            ViewBag.Dentist_ID = new SelectList(db.Dentist, "Dentist_ID", "Dentist_Name");
            ViewBag.Prescription_ID = new SelectList(db.Prescription, "Prescription_ID", "Prescription_Date");
            return View();
        }

        // POST: MedicalHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicalHistory_ID,Customer_ID,Dentist_ID,MedicalHistory_Date,MedicalHistory_Symptoms,MedicalHistory_Diagnosis,Prescription_ID")] MedicalHistory medicalHistory)
        {
            if (ModelState.IsValid)
            {
                db.MedicalHistory.Add(medicalHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name", medicalHistory.Customer_ID);
            ViewBag.Dentist_ID = new SelectList(db.Dentist, "Dentist_ID", "Dentist_Name", medicalHistory.Dentist_ID);
            ViewBag.Prescription_ID = new SelectList(db.Prescription, "Prescription_ID", "Prescription_Date", medicalHistory.Prescription_ID);
            return View(medicalHistory);
        }

        // GET: MedicalHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalHistory medicalHistory = db.MedicalHistory.Find(id);
            if (medicalHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name", medicalHistory.Customer_ID);
            ViewBag.Dentist_ID = new SelectList(db.Dentist, "Dentist_ID", "Dentist_Name", medicalHistory.Dentist_ID);
            ViewBag.Prescription_ID = new SelectList(db.Prescription, "Prescription_ID", "Prescription_Date", medicalHistory.Prescription_ID);
            return View(medicalHistory);
        }

        // POST: MedicalHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicalHistory_ID,Customer_ID,Dentist_ID,MedicalHistory_Date,MedicalHistory_Symptoms,MedicalHistory_Diagnosis,Prescription_ID")] MedicalHistory medicalHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.Customer, "Customer_ID", "Customer_Name", medicalHistory.Customer_ID);
            ViewBag.Dentist_ID = new SelectList(db.Dentist, "Dentist_ID", "Dentist_Name", medicalHistory.Dentist_ID);
            ViewBag.Prescription_ID = new SelectList(db.Prescription, "Prescription_ID", "Prescription_Date", medicalHistory.Prescription_ID);
            return View(medicalHistory);
        }

        // GET: MedicalHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalHistory medicalHistory = db.MedicalHistory.Find(id);
            if (medicalHistory == null)
            {
                return HttpNotFound();
            }
            return View(medicalHistory);
        }

        // POST: MedicalHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalHistory medicalHistory = db.MedicalHistory.Find(id);
            db.MedicalHistory.Remove(medicalHistory);
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
