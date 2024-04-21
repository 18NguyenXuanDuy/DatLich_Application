using DatLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DatLich.Controllers
{
    public class ThongBaoController : Controller
    {
        // GET: ThongBao
        private DLKB db=new DLKB();
        public ActionResult Index()
        {
            return View();
        }



        public static double MaOTP()
        {
            Random random = new Random();
            double OTP = random.Next(10000, 100000);
            return OTP;
        }
        [HttpPost]
        public ActionResult Index(string email)
        {
            Session.Clear();
            // Lấy email từ form
            email = Request.Form["email"];

            var checkemailCustomer = db.AppointmentSchedule_1.Where(c => c.Customer_Email == email).FirstOrDefault();
            var checkemailEmployee = db.Employee.Where(c => c.Employee_Email == email).FirstOrDefault();
            var checkemailDentist = db.Dentist.Where(c => c.Dentist_Email == email).FirstOrDefault();

            if(checkemailCustomer == null &&  checkemailEmployee == null && checkemailDentist==null && email != "duyn061102@gmail.com")
            {
                ViewBag.Loi = "Email không tồn tại. Vui lòng nhập lại";
                return View();

            }
            //if(checkemailCustomer == email)
            //{
            //    return RedirectToAction();
            //}
            //if (checkemailEmployee == email)
            //{
            //    return RedirectToAction();

            //}
            //if (checkemailDentist == email)
            //{
            //    return RedirectToAction();
            //}
            //if (checkemail == null && email != "duyn061102@gmail.com")
            //{
            //    ViewBag.Loi = "Email không tồn tại. Vui lòng nhập lại";
            //    return Json(new { success = false });
            //}
            else
            {

                var fromAddress = new MailAddress("lenamtung88@gmail.com");
                var toAddress = new MailAddress(email.ToString());
                const string frompass = "rcynpmiarsxpjjju";
                const string subject = "Mã xác nhận";
                double OTP = MaOTP();
                string body = "Mã xác nhận của bạn là: " + OTP;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, frompass),
                    Timeout = 200000
                };
                using (var mes = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                //{
                //    smtp.Send(mes);
                //}
                TempData["Ma"] = OTP;
                TempData["Email"] = email;

                //Session["Ma"] = OTP;
                Session["Ma"] = "12345";
                Session["Email"] = email;
                //return Json(new { success = true });
                    return RedirectToAction("XacNhanOTP");
            }
                return View();

        }
        public ActionResult XacNhanOTP()
        {

            return View();
        }


        [HttpPost]
        public ActionResult XacNhanOTP(double otp)
        {

            otp = double.Parse(Request.Form["otp"]);
            //string email1 = TempData["Email"] as string;
            string email1 = Session["Email"] as string;
            //double MaDaGui = (double)Session["Ma"];
            double MaDaGui = double.Parse(Session["Ma"] as string);

            var user = db.AppointmentSchedule_1.FirstOrDefault(x => x.Customer_Email == email1);
            var dentist = db.Dentist.FirstOrDefault(x => x.Dentist_Email == email1);
            var employee=db.Employee.FirstOrDefault(x=>x.Employee_Email == email1);
            if (email1 != null)
            {
                if (MaDaGui == otp)
                {
                    Session["Login"] = email1;

                    if (email1 == "duyn061102@gmail.com")
                    {
                        ViewBag.ThongBao = "Admin";
                        //return RedirectToAction("Index", "LichKhams");
                        return RedirectToAction("Index","HomeAdmin", new { area = "Admin" });
                        //return Json(new { success = true, data = "Admin" });
                    }
                    else if (user != null)
                    {
                        return RedirectToAction("HienThi", "User");
                    }else if (dentist != null)
                    {
                        return RedirectToAction("Confirm", "Dentist");
                    }else
                    {
                        return RedirectToAction("Confirm", "Employee");
                    }

                }
                else
                {
                    ViewBag.ThongBao = "Mã OTP không chính xác!";
                    return Json(new { success = false });
                }
            }
            else
            {
                ViewBag.ThongBao = "Giá trị email null";
            }

            return View();


        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}