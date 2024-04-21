namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShiftWork")]
    public partial class ShiftWork
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShiftWork()
        {
            AppointmentSchedule = new HashSet<AppointmentSchedule>();
            AppointmentSchedule_1 = new HashSet<AppointmentSchedule_1>();
            ShiftWork_Appoint = new HashSet<ShiftWork_Appoint>();
        }

        [Key]
        public int ShiftWork_ID { get; set; }

        [StringLength(20)]
        public string ShiftWork_Name { get; set; }

        [StringLength(20)]
        public string ShiftWork_Date { get; set; }

        public TimeSpan ShiftWork_Start { get; set; }

        public TimeSpan ShiftWork_END { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppointmentSchedule> AppointmentSchedule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppointmentSchedule_1> AppointmentSchedule_1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShiftWork_Appoint> ShiftWork_Appoint { get; set; }
    }
}
