using DatLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatLich.Controllers
{
    public class HomeController : Controller
    {
        private DLKB db = new DLKB();

        public ActionResult Index()
        {
            ViewBag.Dentist_ID = new SelectList(db.Dentist, "Dentist_ID", "Dentist_Name");
            ViewBag.ShiftWork_ID = new SelectList(db.ShiftWork, "ShiftWork_ID", "ShiftWork_Name");
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}