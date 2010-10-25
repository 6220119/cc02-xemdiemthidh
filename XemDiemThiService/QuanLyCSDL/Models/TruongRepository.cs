using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using QuanLyCSDL.DAL;

namespace QuanLyCSDL.Models
{
    public class TruongRepository
    {
        DiemThiDHEntities _db = new DiemThiDHEntities();

        public TruongDetails[] GetAllTruong()
        {
            var listTruong = from tr in _db.Truongs
                             select new TruongDetails
                             {
                                 MaTruong = tr.MaTruong,
                                 TenTruong = tr.TenTruong
                             };

            return listTruong.ToArray();
        }

        public IQueryable<Truong> FindAllTruong()
        {
            return from tr in _db.Truongs
                   orderby tr.MaTruong
                   select tr;
        }

        public Truong GetTruongByMaTruong(string maTruong)
        {
            return _db.Truongs.FirstOrDefault(tr => tr.MaTruong == maTruong);
        }

        public void Add(Truong truong)
        {
            _db.Truongs.AddObject(truong);
        }

        public void Delete(Truong truong)
        {
            _db.Truongs.DeleteObject(truong);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}