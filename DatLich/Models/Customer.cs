namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            AppointmentSchedule = new HashSet<AppointmentSchedule>();
            Comment_Customer = new HashSet<Comment_Customer>();
            MedicalHistory = new HashSet<MedicalHistory>();
        }

        [Key]
        public int Customer_ID { get; set; }

        [StringLength(100)]
        [DisplayName("Họ tên")]
        public string Customer_Name { get; set; }

        [StringLength(100)]
        [DisplayName("Email")]
        public string Customer_Email { get; set; }
        [DisplayName("Tuổi")]
        public int? Customer_Age { get; set; }

        [StringLength(12)]
        [DisplayName("Số điện thoại")]
        public string Customer_Phone { get; set; }

        [StringLength(10)]
        [DisplayName("Giới tính")]
        public string Customer_Gender { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Ảnh")]
        public string Customer_Img { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppointmentSchedule> AppointmentSchedule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment_Customer> Comment_Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicalHistory> MedicalHistory { get; set; }
    }
}
