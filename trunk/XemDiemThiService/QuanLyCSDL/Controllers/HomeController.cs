using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCSDL.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Bạn đang ở trang quản lý CSDL !";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            ViewData["Message"] = "Bạn đang ở trang quản lý CSDL ! [POST] " + form["txt"];
            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
