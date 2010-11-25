using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace QuanLyCSDL.DAL
{
    [MetadataType(typeof(Nganh_Validation))]
    public partial class Nganh
    {

    }

    public class Nganh_Validation
    {
        [Required(ErrorMessage = "Tên Ngành không được rỗng !")]
        [StringLength(50, ErrorMessage = "Tên Ngành không được dài hơn 50 ký tự")]
        [DisplayName("Tên Ngành")]
        public string TenNganh { get; set; }
    }
}