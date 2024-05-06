namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MedicalHistory")]
    public partial class MedicalHistory
    {
        [Key]
        public int MedicalHistory_ID { get; set; }
        [DisplayName("Khách hàng")]
        public int? Customer_ID { get; set; }
        [DisplayName("Nha sĩ")]
        public int? Dentist_ID { get; set; }

        [StringLength(20)]
        [DisplayName("Ngày lập")]
        public string MedicalHistory_Date { get; set; }

        [StringLength(255)]
        [DisplayName("Triệu chứng")]
        public string MedicalHistory_Symptoms { get; set; }

        [StringLength(255)]
        [DisplayName("Chuẩn đoán")]
        public string MedicalHistory_Diagnosis { get; set; }
        [DisplayName("Đơn thuốc")]
        public int? Prescription_ID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Dentist Dentist { get; set; }

        public virtual Prescription Prescription { get; set; }
    }
}
