namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AppointmentSchedule_1
    {
        [Key]
        public int AppointmentSchedule1_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Customer_Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Customer_Email { get; set; }

        [Required]
        [StringLength(12)]
        public string Customer_Phone { get; set; }

        public bool AppointmentSchedule_Status { get; set; }

        [Required]
        [StringLength(20)]
        public string AppointmentSchedule_Date { get; set; }

        [Column(TypeName = "ntext")]
        public string Describe { get; set; }

        public DateTime TimeOrder { get; set; }

        public int? Dentist_ID { get; set; }

        public int? ShiftWork_ID { get; set; }

        public int? Employee_ID { get; set; }

        public virtual Dentist Dentist { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ShiftWork ShiftWork { get; set; }
    }
}
