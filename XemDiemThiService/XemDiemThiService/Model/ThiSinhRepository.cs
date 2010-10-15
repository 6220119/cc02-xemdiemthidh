using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects.DataClasses;
using System.Data;

using XemDiemThiService.DAL;

namespace XemDiemThiService.Model
{
    public class ThiSinhRepository
    {
        DiemThiDHEntities _db = new DiemThiDHEntities();

        public ThiSinhDetails[] GetTop100ThiSinhDetailsByMaTruong(string maTruong)
        {
            var query = from ts in _db.ThiSinhs
                        where ts.Nganh.MaTruong == maTruong
                        orderby ts.Diem1 + ts.Diem2 + ts.Diem3
                        select new ThiSinhDetails
                        {
                            Diem1 = ts.Diem1,
                            Diem2 = ts.Diem2,
                            Diem3 = ts.Diem3,
                            GioiTinh = ts.GioiTinh == true ? "Nam" : "Nữ",
                            HoTen = ts.HoTen,
                            NgaySinh = ts.NgaySinh,
                            QueQuan = ts.QueQuan,
                            SoBaoDanh = ts.SoBaoDanh,
                            TenNganh = ts.Nganh.TenNganh,
                            TenTruong = ts.Nganh.Truong.TenTruong
                        };

            /*string error = "SUCCESS";

            try
            {
                ThiSinhDetails[] arr = query.ToArray();
            }
            catch (System.Exception ex)
            {
                error = ex.Message;
            }*/

            return query.ToArray();//error; 
        }

        public ThiSinhDetails FindThiSinhBySBD(string soBaoDanh)
        {
            return GetDetailsFromThiSinh(
                _db.ThiSinhs.SingleOrDefault(t => t.SoBaoDanh == soBaoDanh));
        }

        public ThiSinhDetails GetDetailsFromThiSinh(ThiSinh ts)
        {
            if (ts == null)
                return null;

            return new ThiSinhDetails
            {
                Diem1 = ts.Diem1,
                Diem2 = ts.Diem2,
                Diem3 = ts.Diem3,
                GioiTinh = ts.GioiTinh == true ? "Nam" : "Nữ",
                HoTen = ts.HoTen,
                NgaySinh = ts.NgaySinh,
                QueQuan = ts.QueQuan,
                SoBaoDanh = ts.SoBaoDanh,
                TenNganh = ts.Nganh.TenNganh,
                TenTruong = ts.Nganh.Truong.TenTruong
            };
        }
    }
}