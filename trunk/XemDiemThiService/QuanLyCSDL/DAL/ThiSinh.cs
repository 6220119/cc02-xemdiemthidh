using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace QuanLyCSDL.DAL
{
    [MetadataType(typeof(ThiSinh_Validation))]
    public partial class ThiSinh
    {

    }

    [Bind(Exclude = "Id,SoBaoDanh")]
    public class ThiSinh_Validation
    {
        [Required(ErrorMessage = "Họ Tên không được rỗng !")]
        [StringLength(50, ErrorMessage = "Họ Tên không được dài hơn 50 ký tự")]
        [DisplayName("Họ Tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Quê Quán không được rỗng !")]
        [StringLength(50, ErrorMessage = "Quê Quán không được dài hơn 50 ký tự")]
        [DisplayName("Quê Quán")]
        public string QueQuan { get; set; }

        [Range(0, 10, ErrorMessage = "Điểm 1 là số thực nằm trong [0, 10] !")]
        [Required(ErrorMessage = "Điểm 1 không được rỗng !")]
        [DisplayName("Điểm 1")]
        public double Diem1 {get; set;}

        [Range(0, 10, ErrorMessage = "Điểm 2 là số thực nằm trong [0, 10] !")]
        [Required(ErrorMessage = "Điểm 2 không được rỗng !")]
        [DisplayName("Điểm 2")]
        public double Diem2 { get; set; }

        [Range(0, 10, ErrorMessage = "Điểm 3 là số thực nằm trong [0, 10] !")]
        [Required(ErrorMessage = "Điểm 3 không được rỗng !")]
        [DisplayName("Điểm 3")]
        public double Diem3 { get; set; }

        [DisplayName("Ngày Sinh")]
        public DateTime NgaySinh {get; set;}

        [DisplayName("Số Báo Danh")]
        public string SoBaoDanh{get; set;}

        [DisplayName("Giới Tính")]
        public bool GioiTinh {get; set;}
    }
}