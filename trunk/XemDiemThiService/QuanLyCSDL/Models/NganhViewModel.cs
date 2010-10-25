using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyCSDL.DAL;

namespace QuanLyCSDL.Models
{
    public class NganhViewModel
    {
        public SelectList ListTruongs {get; private set;}

        public Nganh Nganh {get; private set;}

        public NganhViewModel(Nganh nganh)
        {
            Nganh = nganh;

            ListTruongs =
                new SelectList(
                    new TruongRepository().FindAllTruong().ToArray(),
                    "MaTruong",
                    "TenTruong");
        }
    }
}