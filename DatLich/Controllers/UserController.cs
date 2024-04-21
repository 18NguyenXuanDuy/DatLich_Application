using DatLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatLich.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private DLKB db=new DLKB();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ls()
        {
            string email = Session["Login"] as string;

            return View();
        }
        public ActionResult HienThi()
        {
            string email = Session["Login"] as string;
            var user = db.AppointmentSchedule_1.FirstOrDefault(u => u.Customer_Email == email);
            if (user == null)
            {
                return RedirectToAction("Create", "AppointmentSchedule_1");
            }
            else
            {
                var Nguoidung = db.AppointmentSchedule_1.Where(s => s.Customer_Email == user.Customer_Email).ToList();

                List<AppointmentViewModel> list = new List<AppointmentViewModel>();

                foreach (var bn in Nguoidung)
                {
                    var shiwork = db.ShiftWork.FirstOrDefault(p => p.ShiftWork_ID == bn.ShiftWork_ID);
                    string shifworkName = shiwork != null ? shiwork.ShiftWork_Name : "";

                    var dentist = db.Dentist.FirstOrDefault(b => b.Dentist_ID == bn.Dentist_ID);
                    string dentistName = dentist != null ? dentist.Dentist_Name : "";

                    //var employee = db.Employee.FirstOrDefault(b => b.Employee_ID == bn.Employee_ID);
                    //string employeeName = employee != null ? employee.Employee_Name : "";

                    list.Add(new AppointmentViewModel()
                    {
                         AppointmentSchedule_ID=bn.AppointmentSchedule1_ID,
                         Customer_Name=bn.Customer_Name,
                        Customer_Email=bn.Customer_Email,
                        Customer_Phone=bn.Customer_Phone,
                        AppointmentSchedule_Status=bn.AppointmentSchedule_Status,
                        AppointmentSchedule_Date =bn.AppointmentSchedule_Date,
                        Describe   =bn.Describe,
                        TimeOrder=bn.TimeOrder,
                        Dentist_Name=dentistName,
                        ShiftWork_Name=shifworkName,
                        //Employee_Name=employeeName
                    });
                }
                if (list.Count > 0)
                {
                    ViewData["LichKhamViewModels"] = list;
                    return View();
                }
                else
                    return RedirectToAction("Create", "AppointmentSchedule_1");
            }
        }

    }
}