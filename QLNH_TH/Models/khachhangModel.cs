using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_TH.Models
{
    public class khachhangModel
    {
        [Key]
        [Display(Name = "Mã Khách Hàng")]
        public string makh { get; set; }
        [Display(Name = "Tên Khách Hàng")]
        /*[Column("tenk")]*/
        public string tenk { get; set; }
        [Display(Name = "Ngày Sinh")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ngaysinh { get; set; }
        [Display(Name = "Địa Chỉ")]
        public string diachi { get; set; }
        public ICollection<tiecModel> tiecs { get; set; }
    }
}
