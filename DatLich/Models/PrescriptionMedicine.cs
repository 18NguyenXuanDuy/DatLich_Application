namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrescriptionMedicine")]
    public partial class PrescriptionMedicine
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Prescription_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Medicine_ID { get; set; }
        [DisplayName("Số lượng")]
        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá tiền")]
        public decimal? Price { get; set; }

        public virtual Medicine Medicine { get; set; }

        public virtual Prescription Prescription { get; set; }
    }
}
