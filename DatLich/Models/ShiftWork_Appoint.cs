namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShiftWork_Appoint
    {
        [Key]
        public int ShiftWorkAppoint_ID { get; set; }

        [StringLength(20)]
        public string ShiftWorkAppoint_Date { get; set; }

        public int Current_Quantity { get; set; }

        public int? Maximum_Quantity { get; set; }

        public int? ShiftWork_ID { get; set; }

        public int? AppointmentSchedule_ID { get; set; }

        public virtual AppointmentSchedule AppointmentSchedule { get; set; }

        public virtual ShiftWork ShiftWork { get; set; }
    }
}
