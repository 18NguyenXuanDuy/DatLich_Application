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
        public ActionResult Comment(string message, string email, string subject)
        {
            string email1 = Session["Login"] as string;
            string email2 = db.Customer.Where(x => x.Customer_Email == email).Select(x=>x.Customer_Email).FirstOrDefault();
            Comment_Customer comment_Customer = new Comment_Customer();
            if(email1==null && email2 == null)
            {
                ViewBag.Thongbaolienhe = "Bạn cần đặt lịch trước để sử dụng chức năng này";
            }
            else
            {
                comment_Customer.CommentCustomer_Content = subject + "/n" + message;
                DateTime currentDate = DateTime.Now;
                string formattedDate = currentDate.ToString("yyyy-MM-dd HH:mm:ss");
                comment_Customer.CommentCustomer_TimeOrder = formattedDate;
                var user1 = db.Customer.Where(x => x.Customer_Email == email1).FirstOrDefault();
                var user2 = db.Customer.Where(x => x.Customer_Email == email2).FirstOrDefault();
                if (user1 != null)
                {
                    comment_Customer.Customer_ID = user1.Customer_ID;

                }
                if (user2 != null)
                {
                    comment_Customer.Customer_ID = user2.Customer_ID;

                }
            }
            db.Comment_Customer.Add(comment_Customer);
            db.SaveChanges();

            return RedirectToAction("Index","Home");

        }
        public ActionResult PhanHoiCuaToi()
        {
            string email = Session["Login"] as string;
            int user = db.Customer.Where(x => x.Customer_Email == email).Select(x => x.Customer_ID).FirstOrDefault();
            var listcoment=db.Comment_Customer.Where(x=>x.Customer_ID == user).ToList();
            return View(listcoment);
        }
        public ActionResult Hienthilichsu()
        {
            string email = Session["Login"] as string;
            var user = db.Customer.FirstOrDefault(u => u.Customer_Email == email);
            var medicalHistory = db.MedicalHistory.Where(x=>x.Customer_ID==user.Customer_ID);
            return View(medicalHistory.ToList());
        }
        public ActionResult HienThi()
        {
            string email = Session["Login"] as string;
            var user = db.AppointmentSchedule_1.FirstOrDefault(u => u.Customer_Email == email);
            ViewBag.User=user.Customer_Name;
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