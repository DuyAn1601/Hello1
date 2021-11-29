using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_TH.Models
{
    public class bookphongModel
    {
        [Key]
        [Display(Name = "Mã Tiệc")]
        public string matiec { get; set; }
        [Key]
        [Display(Name = "Mã Phòng")]
        public string maphong { get; set; }
        [Display(Name = "Số lượng nước uống")]
        public int slnuocuong { get; set; }
        [ForeignKey("maphong")]
        public phongModel phong { get; set; }
        [ForeignKey("matiec")]
        public tiecModel tiec { get; set; }
    }
}
