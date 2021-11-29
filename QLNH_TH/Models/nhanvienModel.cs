using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_TH.Models
{
    public class nhanvienModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã Nhân Viên")]
        public int manv { get; set; }
        [Required]
        [Display(Name = "Tên Nhân Viên")]
        public string tennv { get; set; }
        [Required]
        [Display(Name ="Giới tính")]
        [Column("gioitinh")]
        public string gioitinh { get; set; }
        [Display(Name =" Ngày Sinh")]
        public DateTime ngaysinh { get; set; }

    }
}
