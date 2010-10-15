using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using XemDiemThiService.DAL;
using XemDiemThiService.Model;
using System.Diagnostics;

namespace XemDiemThiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class XDTService : IXDTService
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
