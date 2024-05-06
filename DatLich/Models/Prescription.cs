namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prescription")]
    public partial class Prescription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prescription()
        {
            MedicalHistory = new HashSet<MedicalHistory>();
            PrescriptionMedicine = new HashSet<PrescriptionMedicine>();
        }

        [Key]
        public int Prescription_ID { get; set; }

        [StringLength(20)]
        [DisplayName("Ngày lập")]
        public string Prescription_Date { get; set; }

        [StringLength(500)]
        [DisplayName("Triệu chứng")]
        public string Prescription_Symptom { get; set; }

        [StringLength(500)]
        [DisplayName("Chuẩn đoán")]
        public string Prescription_Diagnostic { get; set; }
        [DisplayName("Lịch khám")]
        public int? AppointmentSchedule_ID { get; set; }

        public virtual AppointmentSchedule AppointmentSchedule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicalHistory> MedicalHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrescriptionMedicine> PrescriptionMedicine { get; set; }
    }
}
