namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AppointmentSchedule")]
    public partial class AppointmentSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AppointmentSchedule()
        {
            HistoryChanges = new HashSet<HistoryChanges>();
            Prescription = new HashSet<Prescription>();
            ShiftWork_Appoint = new HashSet<ShiftWork_Appoint>();
        }

        [Key]
        public int AppointmentSchedule_ID { get; set; }
        [DisplayName("Trạng thái")]
        public bool AppointmentSchedule_Status { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Ngày khám")]

        public string AppointmentSchedule_Date { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Mô tả")]

        public string Describe { get; set; }
        [DisplayName("Thời gian đặt")]
        public DateTime TimeOrder { get; set; }
        [DisplayName("Nha sĩ")]
        public int? Dentist_ID { get; set; }
        [DisplayName("Ca khám")]
        public int? ShiftWork_ID { get; set; }
        [DisplayName("Nhân viên")]
        public int? Employee_ID { get; set; }
        [DisplayName("Khách hàng")]
        public int? Customer_ID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Dentist Dentist { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ShiftWork ShiftWork { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryChanges> HistoryChanges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescription> Prescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShiftWork_Appoint> ShiftWork_Appoint { get; set; }
    }
}
