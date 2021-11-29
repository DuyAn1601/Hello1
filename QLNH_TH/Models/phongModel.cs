using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLNH_TH.Models
{
    public class phongModel
    {
        [Key]
        [Display(Name = "Mã Phòng")]
        public string maphong { get; set; }
        [Display(Name = "Tên Phòng")]
        [StringLength(40, ErrorMessage = "Tên phòng phải < 40 kí tự")]
        public string tenphong { get; set; }
        [Display(Name = "Sức chứa")]
        public int succhua { get; set; }
        [Display(Name = "Loại Phòng")]
        [StringLength(40, ErrorMessage = "Loại phòng phải < 40 kí tự")]
        public string loaiphong { get; set; }
        [Display(Name = "Mã Sảnh")]
        public string masanh { get; set; }
        [ForeignKey("masanh")]
        public sanhModel sanh { get; set; }
        public List<bookphongModel> bookphongs { get; set; }

    }
}
