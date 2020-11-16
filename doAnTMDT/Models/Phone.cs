using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace doAnTMDT.Models
{
    public class Phone
    {
        public Phone()
        {
            Image = "~/Content/Images/add.png";
        }
        [Key]
        public int PhoneID { get; set; }
        [Display(Name = "Tên điện thoại")]
        [Required(ErrorMessage = "Tên điện thoại là bắt buộc")]
        public string PhoneName { get; set; }

        [Display(Name = "Giá")]
        public float PhonePrice { get; set; }
        [Display(Name = "Mô tả")]
        public string PhoneDescription { get; set; }

        [Display(Name = "Ngày sản xuất")]
        public DateTime? PublisherDate { get; set; }

        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpLoad { get; set; }


       
       

        [Display(Name = "Loại")]
        [ForeignKey("Category")]
        public int CateID { get; set; }
        public virtual Category Category { get; set; }
    }
}