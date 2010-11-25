using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using QuanLyCSDL.DAL;

namespace QuanLyCSDL.Models
{
    public class NganhRepository
    {
        DiemThiDHEntities _db = new DiemThiDHEntities();

        public IQueryable<Nganh> GetNganhByMaTruong(string maTruong)
        {
            return from ng in _db.Nganhs
                   where ng.MaTruong == maTruong
                   select ng;
        }

        public IQueryable<NganhJSON> GetNganhJSONByMaTruong(string maTruong)
        {
            return from ng in _db.Nganhs
                   where ng.MaTruong.Trim() == maTruong
                   select new NganhJSON { Id = ng.Id, TenNganh = ng.TenNganh };
        }

        public IQueryable<Nganh> FindAllNganh()
        {
            return from ng in _db.Nganhs
                   orderby ng.Id   
                   select ng;
        }

        public Nganh GetNganhById(int id)
        {
            return _db.Nganhs.FirstOrDefault(n => n.Id == id);
        }

        public void Add(Nganh nganh)
        {
            _db.Nganhs.AddObject(nganh);
        }

        public void Delete(Nganh nganh)
        {
            _db.Nganhs.DeleteObject(nganh);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }

    public class NganhJSON
    {
        public int Id {get; set;}
        public string TenNganh {get; set;}
    }
}