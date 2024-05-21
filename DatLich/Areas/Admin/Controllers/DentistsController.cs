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

namespace DatLich.Areas.Admin.Controllers
{
    public class DentistsController : Controller
    {
        private DLKB db = new DLKB();

        // GET: Admin/Dentists
        public ActionResult Index()
        {
            return View(db.Dentist.ToList());
        }

        // GET: Admin/Dentists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dentist dentist = db.Dentist.Find(id);
            if (dentist == null)
            {
                return HttpNotFound();
            }
            return View(dentist);
        }

        // GET: Admin/Dentists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Dentists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dentist_ID,Dentist_Name,Dentist_Email,Dentist_Infor,Dentist_Img")] Dentist dentist, HttpPostedFileBase uploadhinh)
        {
            if (ModelState.IsValid)
            {
                db.Dentist.Add(dentist);

                if (uploadhinh != null && uploadhinh.ContentLength > 0)
                {
                    int id = dentist.Dentist_ID;

                    string _FileName = "";
                    int index = uploadhinh.FileName.IndexOf('.');
                    _FileName = "Dentist" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/Upload/Dentist"), _FileName);
                    uploadhinh.SaveAs(_path);
                    dentist.Dentist_Img = _FileName;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dentist);
        }

        // GET: Admin/Dentists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dentist dentist = db.Dentist.Find(id);
            if (dentist == null)
            {
                return HttpNotFound();
            }
            return View(dentist);
        }

        // POST: Admin/Dentists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dentist_ID,Dentist_Name,Dentist_Email,Dentist_Infor,Dentist_Img")] Dentist dentist, HttpPostedFileBase uploadhinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dentist).State = EntityState.Modified;
                if (uploadhinh != null && uploadhinh.ContentLength > 0)
                {
                    int id = dentist.Dentist_ID;

                    string _FileName = "";
                    int index = uploadhinh.FileName.IndexOf('.');
                    _FileName = "Dentist" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/Upload/Dentist"), _FileName);
                    uploadhinh.SaveAs(_path);
                    dentist.Dentist_Img = _FileName;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dentist);
        }

        // GET: Admin/Dentists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dentist dentist = db.Dentist.Find(id);
            if (dentist == null)
            {
                return HttpNotFound();
            }
            return View(dentist);
        }

        // POST: Admin/Dentists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dentist dentist = db.Dentist.Find(id);
            db.Dentist.Remove(dentist);
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
