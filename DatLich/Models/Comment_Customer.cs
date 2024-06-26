﻿namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment_Customer
    {
        [Key]
        public int CommentCustomer_ID { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Nội dung")]
        public string CommentCustomer_Content { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Thời gian")]
        public string CommentCustomer_TimeOrder { get; set; }
        [DisplayName("Khách hàng")]
        public int? Customer_ID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
