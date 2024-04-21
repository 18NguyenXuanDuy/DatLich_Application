namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dentist")]
    public partial class Dentist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dentist()
        {
            AppointmentSchedule = new HashSet<AppointmentSchedule>();
            AppointmentSchedule_1 = new HashSet<AppointmentSchedule_1>();
            MedicalHistory = new HashSet<MedicalHistory>();
        }

        [Key]
        public int Dentist_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Dentist_Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Dentist_Email { get; set; }

        [Column(TypeName = "ntext")]
        public string Dentist_Infor { get; set; }

        [Column(TypeName = "ntext")]
        public string Dentist_Img { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppointmentSchedule> AppointmentSchedule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppointmentSchedule_1> AppointmentSchedule_1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicalHistory> MedicalHistory { get; set; }
    }
}
