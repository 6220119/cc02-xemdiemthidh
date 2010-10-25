using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;
using QuanLyCSDL.DAL;

namespace QuanLyCSDL.DAL
{
    [MetadataType(typeof(Truong_Validation))]
    public partial class Truong { }

    public class Truong_Validation
    {
        [Required(ErrorMessage = "Mã Trường không được rỗng !")]
        [StringLength(3, ErrorMessage = "Mã trường không được dài hơn 3 ký tự")]
        [DisplayName("Mã Trường")]
        public string MaTruong { get; set; }

        [Required(ErrorMessage = "Tên trường không được rỗng !")]
        [StringLength(50, ErrorMessage = "Tên trường không được dài hơn 50 ký tự")]
        [DisplayName("Tên Trường")]
        public string TenTruong { get; set; }
    }
}