namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            AppointmentSchedule = new HashSet<AppointmentSchedule>();
            AppointmentSchedule_1 = new HashSet<AppointmentSchedule_1>();
        }

        [Key]
        public int Employee_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Employee_Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Employee_Email { get; set; }

        [Column(TypeName = "ntext")]
        public string Employee_Infor { get; set; }

        [Column(TypeName = "ntext")]
        public string Employee_Img { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppointmentSchedule> AppointmentSchedule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppointmentSchedule_1> AppointmentSchedule_1 { get; set; }
    }
}
