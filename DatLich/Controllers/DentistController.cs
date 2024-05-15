using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatLich.Controllers
{
    public class DentistController : Controller
    {
        // GET: Dentist
        public ActionResult Index()
        {
            return View();
        }
    }
}