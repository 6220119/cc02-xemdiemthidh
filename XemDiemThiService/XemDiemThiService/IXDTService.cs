using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using XemDiemThiService.DAL;
using XemDiemThiService.Model;

namespace XemDiemThiService
{
    [ServiceContract]
    public interface IXDTService
    {
        [OperationContract]
        ThiSinhDetails GetThiSinhDetails(string soBaoDanh);

        [OperationContract]
        ThiSinhDetails[] GetTop100ThiSinhDetailsByMaTruong(string maTruong);

        [OperationContract]
        TruongDetails[] GetAllTruong();
    }
}
