namespace DatLich.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AppointmentSchedule_1
    {
        [Key]
        public int AppointmentSchedule1_ID { get; set; }

        [Required(ErrorMessage = "Tên khách hàng là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên khách hàng không được quá 100 ký tự.")]
        [DisplayName("Tên khách hàng")]
        public string Customer_Name { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")] 
        [DisplayName("Email")]
        public string Customer_Email { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [StringLength(12, ErrorMessage = "Số điện thoại không được quá 12 ký tự.")]
        [DisplayName("Số điện thoại")]
        public string Customer_Phone { get; set; }
        [DisplayName("Trạng thái")]
        public bool AppointmentSchedule_Status { get; set; }

        
        [StringLength(20)]
        [DisplayName("Ngày khám")]
        public string AppointmentSchedule_Date { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Mô tả")]
        public string Describe { get; set; }
        [DisplayName("Thời gian đặt")]
        public DateTime TimeOrder { get; set; }
        [DisplayName("Nha sĩ")]
        public int? Dentist_ID { get; set; }
        [DisplayName("Ca khám")]
        public int? ShiftWork_ID { get; set; }
        [DisplayName("Nhân viên")]
        public int? Employee_ID { get; set; }

        public virtual Dentist Dentist { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ShiftWork ShiftWork { get; set; }
    }
}
