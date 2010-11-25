using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using QuanLyCSDL.DAL;
using System.Web.Mvc;

namespace QuanLyCSDL.Models
{
    public class ThiSinhViewModel
    {
        public SelectList ListTruongs { get; private set; }

        public SelectList ListNganhs { get; set; }

        public ThiSinh ThiSinh {get; private set; }

        public ThiSinhViewModel(ThiSinh ts)
        {
            string maTruong = null;
            try
            {
                maTruong = new NganhRepository().GetNganhById(ts.IdNganh).MaTruong;
            }
            catch { }

            if(maTruong == null)
                maTruong = new NganhRepository().FindAllNganh().First().MaTruong; 

            ThiSinh = ts;

            ListTruongs = 
                new SelectList(
                    new TruongRepository().FindAllTruong().ToArray(), 
                    "MaTruong", 
                    "TenTruong", maTruong);

            ListNganhs =
                new SelectList(
                    new NganhRepository().GetNganhByMaTruong(maTruong).ToArray(),
                    "Id",
                    "TenNganh");
        }
    }
}