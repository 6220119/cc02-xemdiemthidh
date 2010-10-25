using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects.DataClasses;
using System.Data;

using QuanLyCSDL.DAL;
using System.Diagnostics;

namespace QuanLyCSDL.Models
{
    public class ThiSinhRepository
    {
        DiemThiDHEntities _db = new DiemThiDHEntities();

        public string GenerateSBD(string maTruong)
        {
            int max = 0;
            try
            {
                string str = (from t in _db.ThiSinhs
                              where t.Nganh.Truong.MaTruong == maTruong
                              orderby t.SoBaoDanh descending
                              select t).First().SoBaoDanh.Substring(3, 5);

                Debug.WriteLine(str);

                max = Int32.Parse(str);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            return maTruong + string.Format("{0:00000}", (max + 1));
        }

        public ThiSinhDetails[] GetTop100ThiSinhDetailsByMaTruong(string maTruong)
        {
            var query = from ts in _db.ThiSinhs
                        where ts.Nganh.MaTruong == maTruong
                        orderby ts.Diem1 + ts.Diem2 + ts.Diem3 descending
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

        public IQueryable<ThiSinh> FindAllThiSinh()
        {
            return from ts in _db.ThiSinhs
                   orderby ts.SoBaoDanh
                   select ts;
        }

        public ThiSinh GetThiSinh(int id)
        {
            return _db.ThiSinhs.FirstOrDefault(ts => ts.Id == id);
        }

        public void Add(ThiSinh thiSinh)
        {
            _db.ThiSinhs.AddObject(thiSinh);
        }

        public void Delete(ThiSinh thiSinh)
        {
            _db.ThiSinhs.DeleteObject(thiSinh);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}