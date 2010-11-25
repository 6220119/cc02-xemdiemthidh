using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using XemDiemThiService.DAL;

namespace XemDiemThiService.Model
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
    }
}