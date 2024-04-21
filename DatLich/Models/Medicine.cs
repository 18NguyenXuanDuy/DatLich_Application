namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
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
        public string Medicine_Name { get; set; }

        public int Medicine_Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal Medicine_Price { get; set; }

        [Required]
        [StringLength(20)]
        public string Medicine_Unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrescriptionMedicine> PrescriptionMedicine { get; set; }
    }
}
