namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShiftWork_Appoint
    {
        [Key]
        public int ShiftWorkAppoint_ID { get; set; }

        [StringLength(20)]
        [DisplayName("Ngày")]
        public string ShiftWorkAppoint_Date { get; set; }
        [DisplayName("Số lượng hiện tại")]
        public int Current_Quantity { get; set; }
        [DisplayName("Số lượng tối đa")]

        public int? Maximum_Quantity { get; set; }
        [DisplayName("Ca khám")]

        public int? ShiftWork_ID { get; set; }
        [DisplayName("Lịch khám")]
        public int? AppointmentSchedule_ID { get; set; }

        public virtual AppointmentSchedule AppointmentSchedule { get; set; }

        public virtual ShiftWork ShiftWork { get; set; }
    }
}
