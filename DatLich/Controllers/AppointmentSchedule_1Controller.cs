﻿using System;
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
    public class AppointmentSchedule_1Controller : Controller
    {
        private DLKB db = new DLKB();

        // GET: AppointmentSchedule_1
        public ActionResult Index()
        {
            var appointmentSchedule_1 = db.AppointmentSchedule_1.Include(a => a.Dentist).Include(a => a.Employee).Include(a => a.ShiftWork);
            return View(appointmentSchedule_1.ToList());
        }

        // GET: AppointmentSchedule_1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentSchedule_1 appointmentSchedule_1 = db.AppointmentSchedule_1.Find(id);
            if (appointmentSchedule_1 == null)
            {
                return HttpNotFound();
            }
            return View(appointmentSchedule_1);
        }
        public ActionResult Thanhcong()
        {
            return View();
        }
        public ActionResult ThatBai()
        {
            ViewBag.date = TempData["Ngay1"] as string;
            ViewBag.Cakham = TempData["CaKham1"] as string;
            return View();
        }
        // GET: AppointmentSchedule_1/Create
        public ActionResult Create()
        {
            ViewBag.Dentist_ID = new SelectList(db.Dentist, "Dentist_ID", "Dentist_Name");
            ViewBag.Employee_ID = new SelectList(db.Employee, "Employee_ID", "Employee_Name");
            ViewBag.ShiftWork_ID = new SelectList(db.ShiftWork, "ShiftWork_ID", "ShiftWork_Name");
            return View();
        }

        // POST: AppointmentSchedule_1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentSchedule1_ID,Customer_Name,Customer_Email,Customer_Phone,Describe,ShiftWork_ID")] AppointmentSchedule_1 appointmentSchedule_1,string date)
        {
            if (ModelState.IsValid)
            {
                appointmentSchedule_1.TimeOrder = DateTime.Now;
                TempData["Ngay1"] = date.ToString();
               
                appointmentSchedule_1.AppointmentSchedule_Date=date.ToString();
                db.AppointmentSchedule_1.Add(appointmentSchedule_1);
                db.SaveChanges();
                int shitID = appointmentSchedule_1.ShiftWork_ID??0;
                var shift = db.ShiftWork.Where(x => x.ShiftWork_ID == shitID).Select(x => x.ShiftWork_Name);
                TempData["CaKham1"] = shift;
                int? CustomerId = db.Customer
                     .Where(customers => customers.Customer_Name == appointmentSchedule_1.Customer_Name &&
                                       customers.Customer_Email == appointmentSchedule_1.Customer_Email &&
                                       customers.Customer_Phone == appointmentSchedule_1.Customer_Phone)
                     .Select(a => (int?)a.Customer_ID)
                     .FirstOrDefault();
                if (CustomerId == null)
                {
                    Customer newCustomer= new Customer();
                    newCustomer.Customer_Name = appointmentSchedule_1.Customer_Name;
                    newCustomer.Customer_Phone = appointmentSchedule_1.Customer_Phone;
                    newCustomer.Customer_Email= appointmentSchedule_1.Customer_Email;
                    db.Customer.Add(newCustomer);
                    db.SaveChanges();
                    CustomerId = newCustomer.Customer_ID;

                }
               
                    //int CustomerId1 = db.Customer
                    // .Where(customers => customers.Customer_Name == appointmentSchedule_1.Customer_Name &&
                    //                   customers.Customer_Email == appointmentSchedule_1.Customer_Email &&
                    //                   customers.Customer_Phone == appointmentSchedule_1.Customer_Phone)
                    // .Select(a => a.Customer_ID)
                    // .FirstOrDefault();
                    AppointmentSchedule appointmentSchedule = new AppointmentSchedule();
                    appointmentSchedule.AppointmentSchedule_Status = false;
                    appointmentSchedule.AppointmentSchedule_Date =  date.ToString();
                appointmentSchedule.Customer_ID= CustomerId.Value;
                    appointmentSchedule.TimeOrder = DateTime.Now;
                    appointmentSchedule.Describe = appointmentSchedule_1.Describe;
                    appointmentSchedule.ShiftWork_ID= appointmentSchedule_1.ShiftWork_ID;
               
                    appointmentSchedule.Dentist_ID = null;
                    appointmentSchedule.Employee_ID = null;
                    db.AppointmentSchedule.Add(appointmentSchedule);
                db.SaveChanges();
                var notification = new HistoryChanges
                {

                    HistoryChange_Message = $"Lịch khám của {appointmentSchedule_1.Customer_Name} đã được thêm mới vào ngày {DateTime.Now.ToString("dd/MM/yyyy")} lúc {DateTime.Now.ToString("HH:mm")}.",
                    HistoryChange_Time = DateTime.Now,
                    Activity_Change = "ADD",
                    //AppointmentSchedule_ID = appoiment
                };

                db.HistoryChanges.Add(notification);

                ShiftWork_Appoint shiftWork_Appoint = new ShiftWork_Appoint();

                int? shiftworkId = db.ShiftWork_Appoint
                    .Where(s => s.ShiftWorkAppoint_Date==appointmentSchedule_1.AppointmentSchedule_Date &&
                                s.ShiftWork_ID==appointmentSchedule_1.ShiftWork_ID)
                    .Select(a => (int?)a.ShiftWorkAppoint_ID)
                    .FirstOrDefault();
                if(shiftworkId == null)
                {
                    //shiftWork_Appoint.AppointmentSchedule_ID = appointmentSchedule_1.AppointmentSchedule1_ID;
                    shiftWork_Appoint.ShiftWorkAppoint_Date = date.ToString();
                    shiftWork_Appoint.ShiftWork_ID = appointmentSchedule_1.ShiftWork_ID;
                    shiftWork_Appoint.Current_Quantity = 1;
                    shiftWork_Appoint.Maximum_Quantity = 4;
                    db.ShiftWork_Appoint.Add(shiftWork_Appoint);
                }
                else
                {
                  shiftWork_Appoint = db.ShiftWork_Appoint.Find(shiftworkId);
                    if (shiftWork_Appoint.Current_Quantity == 4)
                    {
                        db.AppointmentSchedule_1.Remove(appointmentSchedule_1);
                       return RedirectToAction("ThatBai", "AppointmentSchedule_1");
                    }
                    else
                    {
                        shiftWork_Appoint.Current_Quantity += 1;
                    }
                }
                db.SaveChanges();

                return RedirectToAction("ThanhCong", "AppointmentSchedule_1");
            }

            ViewBag.Dentist_ID = new SelectList(db.Dentist, "Dentist_ID", "Dentist_Name", appointmentSchedule_1.Dentist_ID);
            ViewBag.Employee_ID = new SelectList(db.Employee, "Employee_ID", "Employee_Name", appointmentSchedule_1.Employee_ID);
            ViewBag.ShiftWork_ID = new SelectList(db.ShiftWork, "ShiftWork_ID", "ShiftWork_Name", appointmentSchedule_1.ShiftWork_ID);
            return View(appointmentSchedule_1);
        }

        // GET: AppointmentSchedule_1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentSchedule_1 appointmentSchedule_1 = db.AppointmentSchedule_1.Find(id);
            if (appointmentSchedule_1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dentist_ID = new SelectList(db.Dentist, "Dentist_ID", "Dentist_Name", appointmentSchedule_1.Dentist_ID);
            ViewBag.Employee_ID = new SelectList(db.Employee, "Employee_ID", "Employee_Name", appointmentSchedule_1.Employee_ID);
            ViewBag.ShiftWork_ID = new SelectList(db.ShiftWork, "ShiftWork_ID", "ShiftWork_Name", appointmentSchedule_1.ShiftWork_ID);
            return View(appointmentSchedule_1);
        }

        // POST: AppointmentSchedule_1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentSchedule1_ID,Customer_Name,Customer_Email,Customer_Phone,AppointmentSchedule_Status,AppointmentSchedule_Date,Describe,TimeOrder,Dentist_ID,ShiftWork_ID,Employee_ID")] AppointmentSchedule_1 appointmentSchedule_1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointmentSchedule_1).State = EntityState.Modified;
                db.SaveChanges();

                var notification = new HistoryChanges
                {

                    HistoryChange_Message = $"Lịch khám của {appointmentSchedule_1.Customer_Name} đã được sửa đổi vào ngày {DateTime.Now.ToString("dd/MM/yyyy")} lúc {DateTime.Now.ToString("HH:mm")}.",
                    HistoryChange_Time = DateTime.Now,
                    Activity_Change = "EDIT",
                   // AppointmentSchedule_ID = appointmentSchedule_1.AppointmentSchedule1_ID

                };

                db.HistoryChanges.Add(notification);
                db.SaveChanges();
                string login = Session["Login"] as string;
                if (login == null)
                {
                    return RedirectToAction("HienThi", "User");
                }
                else {
                 var employee = db.Employee.Where(x => x.Employee_Email == login);
                var dentist = db.Dentist.Where(x => x.Dentist_Email == login);

                    if (employee != null)
                        return RedirectToAction("Index", "Employee");
                    if(dentist != null)
                        return RedirectToAction("Index", "Dentist");
                }
                
            }
            ViewBag.Dentist_ID = new SelectList(db.Dentist, "Dentist_ID", "Dentist_Name", appointmentSchedule_1.Dentist_ID);
            ViewBag.Employee_ID = new SelectList(db.Employee, "Employee_ID", "Employee_Name", appointmentSchedule_1.Employee_ID);
            ViewBag.ShiftWork_ID = new SelectList(db.ShiftWork, "ShiftWork_ID", "ShiftWork_Name", appointmentSchedule_1.ShiftWork_ID);
            return View(appointmentSchedule_1);
        }

        // GET: AppointmentSchedule_1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentSchedule_1 appointmentSchedule_1 = db.AppointmentSchedule_1.Find(id);
            if (appointmentSchedule_1 == null)
            {
                return HttpNotFound();
            }
            return View(appointmentSchedule_1);
        }

        // POST: AppointmentSchedule_1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppointmentSchedule_1 appointmentSchedule = db.AppointmentSchedule_1.Find(id);
            db.AppointmentSchedule_1.Remove(appointmentSchedule);
            db.SaveChanges();

            var notification = new HistoryChanges
            {

                HistoryChange_Message = $"Lịch khám của {appointmentSchedule.Customer_Name} đã được xóa vào ngày {DateTime.Now.ToString("dd/MM/yyyy")} lúc {DateTime.Now.ToString("HH:mm")}.",
                HistoryChange_Time = DateTime.Now,
                Activity_Change = "DELETE",
                //AppointmentSchedule_ID = appointmentSchedule.AppointmentSchedule1_ID

            };

            db.HistoryChanges.Add(notification);
            db.SaveChanges();
            return RedirectToAction("HienThi", "User");
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
