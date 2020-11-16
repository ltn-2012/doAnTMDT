using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace doAnTMDT.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        [Display(Name = "Hoá đơn")]
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }


        [Display(Name = "Điện Thoại")]
        [ForeignKey("Phone")]
        public int PhoneID { get; set; }
        public Phone Phone { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Đơn giá")]
        public float UnitPriceSale { get; set; }
    }
}