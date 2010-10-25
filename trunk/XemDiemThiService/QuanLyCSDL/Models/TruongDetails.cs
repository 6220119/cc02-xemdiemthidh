using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace QuanLyCSDL.Models
{
    [DataContract]
    public class TruongDetails
    {
        [DataMember]
        public string MaTruong { get; set; }

        [DataMember]
        public string TenTruong { get; set; }
    }
}