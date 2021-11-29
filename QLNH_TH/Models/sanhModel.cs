using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_TH.Models
{
    public class sanhModel
    {
        [Key]
        [Display(Name = "Mã Sảnh")]
        public string masanh { get; set; }
        [Display(Name = "Tên Sảnh")]
        [StringLength(40, ErrorMessage = "Tên sảnh phải < 40 kí tự")]
        public string tenSanh { get; set; }
        public List<phongModel> phongs { get; set; }
    }
}
