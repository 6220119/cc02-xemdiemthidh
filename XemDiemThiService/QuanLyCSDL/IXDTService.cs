using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using QuanLyCSDL.Models;

namespace QuanLyCSDL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IXemDiemThiService" in both code and config file together.
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
