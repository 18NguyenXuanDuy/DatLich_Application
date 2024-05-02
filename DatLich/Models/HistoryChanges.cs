namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HistoryChanges
    {
        [Key]
        public int HistoryChange_ID { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Thông báo")]
        public string HistoryChange_Message { get; set; }
        [DisplayName("Thời gian thay đổi")]
        public DateTime HistoryChange_Time { get; set; }

        [StringLength(50)]
        [DisplayName("Hành động")]
        public string Activity_Change { get; set; }

        public int? AppointmentSchedule_ID { get; set; }

        public virtual AppointmentSchedule AppointmentSchedule { get; set; }
    }
}
