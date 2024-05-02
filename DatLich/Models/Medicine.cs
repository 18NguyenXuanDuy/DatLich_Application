namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medicine")]
    public partial class Medicine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicine()
        {
            PrescriptionMedicine = new HashSet<PrescriptionMedicine>();
        }

        [Key]
        public int Medicine_ID { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên thuốc")]
        public string Medicine_Name { get; set; }
        [DisplayName("Số lượng ")]
        public int Medicine_Quantity { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá tiền")]
        public decimal Medicine_Price { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Đơn vị tính")]
        public string Medicine_Unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrescriptionMedicine> PrescriptionMedicine { get; set; }
    }
}
