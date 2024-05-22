using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatLich.Models
{
    public class ComentViewModel
    {
        public int CommentCustomer_ID { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string CommentCustomer_TimeOrder { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Img {  get; set; }
    }
}