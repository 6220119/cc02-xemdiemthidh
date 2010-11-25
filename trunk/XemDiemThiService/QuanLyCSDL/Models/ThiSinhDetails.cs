using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace QuanLyCSDL.Models
{
    [DataContract]
    public class ThiSinhDetails
    {
        [DataMember]
        public string SoBaoDanh {get; set;}

        [DataMember]
        public string TenTruong { get; set; }

        [DataMember]
        public string TenNganh { get; set; }

        [DataMember]
        public string HoTen { get; set; }

        [DataMember]
        public DateTime NgaySinh { get; set; }

        [DataMember]
        public string QueQuan { get; set; }

        [DataMember]
        public string GioiTinh { get; set; }

        [DataMember]
        public double Diem1 { get; set; }

        [DataMember]
        public double Diem2 { get; set; }

        [DataMember]
        public double Diem3 { get; set; }
    }
}