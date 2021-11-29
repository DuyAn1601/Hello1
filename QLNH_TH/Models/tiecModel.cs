using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_TH.Models
{
    public class tiecModel
    {
        [Key]
        [Display(Name ="Mã Phòng")]
        public string matiec { get; set; }
        [Display(Name = "Tên Tiệc")]
        [StringLength(40,ErrorMessage ="Tên tiệc phải < 40 kí tự")]
        public string tentiec { get; set; }
        [Display(Name = "Ngày Đặt")]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime ngaydat { get; set; }
        [Display(Name = "Mã Khách Hàng")]
        public string makh { get; set; }
        [ForeignKey("makh")]
        public khachhangModel khachhang { get; set; }
        public List<bookphongModel> bookphongs { get; set; }
    }
}
