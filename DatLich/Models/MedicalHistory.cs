namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MedicalHistory")]
    public partial class MedicalHistory
    {
        [Key]
        public int MedicalHistory_ID { get; set; }

        public int? Customer_ID { get; set; }

        public int? Dentist_ID { get; set; }

        [StringLength(20)]
        public string MedicalHistory_Date { get; set; }

        [StringLength(255)]
        public string MedicalHistory_Symptoms { get; set; }

        [StringLength(255)]
        public string MedicalHistory_Diagnosis { get; set; }

        public int? Prescription_ID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Dentist Dentist { get; set; }

        public virtual Prescription Prescription { get; set; }
    }
}
