namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        [Key]
        public int Invoice_ID { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [StringLength(50)]
        public string Invoice_Status { get; set; }

        [Column(TypeName = "money")]
        public decimal? Total_Price { get; set; }

        public int? AppointmentSchedule_ID { get; set; }

        public int? ServiceCustomer_ID { get; set; }

        public int? PrescriptionMedicine_ID { get; set; }

        public virtual Service_Customer Service_Customer { get; set; }
    }
}
