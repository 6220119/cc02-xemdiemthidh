using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using QuanLyCSDL.Models;

namespace QuanLyCSDL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "XemDiemThiService" in code, svc and config file together.
    public class XemDiemThiService : IXDTService
    {
        public ThiSinhDetails GetThiSinhDetails(string soBaoDanh)
        {
            ThiSinhRepository repo = new ThiSinhRepository();
            return repo.FindThiSinhBySBD(soBaoDanh);
        }

        public ThiSinhDetails[] GetTop100ThiSinhDetailsByMaTruong(string maTruong)
        {
            ThiSinhDetails[] lst = null;
            //string error = "";
            try
            {
                lst = new ThiSinhRepository().GetTop100ThiSinhDetailsByMaTruong(maTruong);
            }
            catch { }

            return lst;//error;
        }

        public TruongDetails[] GetAllTruong()
        {
            TruongDetails[] lstTruong = null;
            try
            {
                lstTruong = new TruongRepository().GetAllTruong();
            }
            catch { }

            return lstTruong;
        }
    }
}
