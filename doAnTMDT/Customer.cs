using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace doAnTMDT.Models
{
    public class Customer
    {
        [Key]
        public int IDCus { get; set; }
        public int CodeCus { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "bắt buộc !")]
        public string Email { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "bắt buộc !")]
        public string Address { get; set; }
        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "bắt buộc !")]
        public int Phone_Cus { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}