namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Service_Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service_Customer()
        {
            Invoice = new HashSet<Invoice>();
        }

        [Key]
        public int ServiceCustomer_ID { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên dịch vụ")]
        public string ServiceCustomer_Name { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá")]
        public decimal ServiceCustomer_Price { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Đơn vị tính")]
        public string ServiceCustomer_Unit { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Thông tin")]
        public string ServiceCustomer_Infor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
