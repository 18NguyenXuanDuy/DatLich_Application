using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatLich.Models;
using Microsoft.Reporting.WebForms;

namespace DatLich.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        private DLKB db = new DLKB();

        public void SettoFalse()
        {
            var currentTime = DateTime.Now;

            var rowsToUpdate = db.AppointmentSchedule_1.ToList();

            foreach (var row in rowsToUpdate)
            {
                DateTime ngayKham = DateTime.ParseExact(row.AppointmentSchedule_Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            }



        }

        public ActionResult Index()
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            SettoFalse();

            var lichKhamList = db.AppointmentSchedule_1.ToList();

            // Order the fetched data in memory
            lichKhamList = lichKhamList.OrderByDescending(x => DateTime.ParseExact(x.AppointmentSchedule_Date, "yyyy-MM-dd", CultureInfo.InvariantCulture).Date)
            .ThenBy(x => x.AppointmentSchedule1_ID).ToList();
            return View(lichKhamList);
        }
        [HttpPost]
        public JsonResult getdataCharBar(int? year)
        {
            var allData = db.AppointmentSchedule_1.ToList(); // Fetch all data from the database

            var monthlyCounts = allData
                .Where(x => DateTime.ParseExact(x.AppointmentSchedule_Date, "yyyy-MM-dd", CultureInfo.InvariantCulture).Year == year) // Filter by year
                .Select(x => new
                {
                    Month = DateTime.ParseExact(x.AppointmentSchedule_Date, "yyyy-MM-dd", CultureInfo.InvariantCulture).Month,
                })
                .GroupBy(x => new { x.Month })
                .Select(g => new { Month = g.Key.Month, Count = g.Count() })
                .ToList();

            return Json(new { success = true, datachart = monthlyCounts });
        }



        [HttpPost]
        public JsonResult getLastUpdate()
        {
            var lastRow = db.HistoryChanges.OrderByDescending(x => x.HistoryChange_ID).FirstOrDefault();
            return Json(new { success = true, updatedTime = lastRow });
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult Report(string ReportType)
        {
            int STTi;
            for (int i = 0; i < db.AppointmentSchedule.Count(); i++)
            {
                STTi = i + 1;
            }

            LocalReport localreport = new LocalReport();
            localreport.ReportPath = Server.MapPath("~/Report/Appoint.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();

            reportDataSource.Name = "DataSet1";

            var lichKhamsList = db.AppointmentSchedule_1
            .Include(l=>l.Dentist)
            .Include(l => l.ShiftWork)
            .Include(l=>l.Employee)
            .ToList();

            var lichKhams = lichKhamsList.Select((l, index) => new
            {
                //STT = index + 1,
                // Include other properties
                Customer_Name = l.Customer_Name,
                //Customer_Email = l.Customer_Email,
                //Customer_Phone = l.Customer_Phone,
                Dentist_Name = l.Dentist.Dentist_Name,
                ShiftWork_Name = l.ShiftWork.ShiftWork_Name,
                Employee_Name=l.Employee.Employee_Name,
                AppointmentSchedule_Date = l.AppointmentSchedule_Date,
                TimeOder=l.TimeOrder,
                AppointmentSchedule_Status = l.AppointmentSchedule_Status ? "Hoàn thành" : "Chưa hoàn thành",
            }).ToList();
            reportDataSource.Value = lichKhams;
            localreport.DataSources.Add(reportDataSource);

            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension;
            if (reportType == "Excel")
            {
                fileNameExtension = "xlsx";
            }
            if (reportType == "PDF")
            {
                fileNameExtension = "pdf";
            }
            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;
            renderedByte = localreport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment; filename=Baocao." + fileNameExtension);
            return File(renderedByte, fileNameExtension);

        }
    }
}