using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatLich.Models
{
    public class AppointmentViewModel
    {
        public int AppointmentSchedule_ID { get; set; }


        public string Customer_Name { get; set; }


        public string Customer_Email { get; set; }

        public string Customer_Phone { get; set; }

        public bool AppointmentSchedule_Status {  get; set; }

        public string AppointmentSchedule_Date { get; set; }

        public string Describe { get; set; }

        public DateTime TimeOrder { get; set; }

        public string Dentist_Name { get; set; }

        public string ShiftWork_Name { get; set; }
        public string Employee_Name { get; set; }


    }
}