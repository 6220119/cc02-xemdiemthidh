using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyCSDL.Models;
using QuanLyCSDL.Helpers;
using QuanLyCSDL.DAL;

namespace QuanLyCSDL.Controllers
{
    public class ThiSinhController : Controller
    {
        ThiSinhRepository _thiSinhRepository = new ThiSinhRepository();

        //
        // GET: /ThiSinh/

        public ActionResult Index(int page = 0)
        {
            const int pageSize = 20;
            var source = _thiSinhRepository.FindAllThiSinh();
            var model = new PaginatedList<ThiSinh>(source, page, pageSize);

            return View(model);
        }

        //
        // GET: /ThiSinh/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ThiSinh ts = new ThiSinh
            {
                NgaySinh = DateTime.Today
            };

            return View(new ThiSinhViewModel(ts));
        } 

        //
        // POST: /ThiSinh/Create

        [HttpPost, Authorize(Roles = "Administrator")]
        public ActionResult Create(ThiSinh ts, FormCollection form)
        {
            /*if(ModelState.IsValid)
            {
                // TODO: Add insert logic here
                ts.SoBaoDanh = _thiSinhRepository.GenerateSBD(form["MaTruong"]);
                _thiSinhRepository.Add(ts);
                _thiSinhRepository.Save();
                return RedirectToAction("Index");
            }
            else*/
            try
            {
                int idNganh = Int32.Parse(form["ThiSinh.IdNganh"]);
                ts.Diem1 = Double.Parse(form["ThiSinh.Diem1"]);
                ts.Diem2 = Double.Parse(form["ThiSinh.Diem2"]);
                ts.Diem3 = Double.Parse(form["ThiSinh.Diem3"]);
                if(form["ThiSinh.GioiTinh"] == "false" || form["ThiSinh.GioiTinh"] == "false,false")
                    ts.GioiTinh = false;
                else
                    ts.GioiTinh = true;
                ts.HoTen = form["ThiSinh.HoTen"];
                ts.QueQuan = form["ThiSinh.QueQuan"];
                ts.NgaySinh = DateTime.Parse(form["ThiSinh_NgaySinh"]);
                ts.IdNganh = idNganh;

                ts.SoBaoDanh = _thiSinhRepository.GenerateSBD(form["MaTruong"]);

                _thiSinhRepository.Add(ts);
                _thiSinhRepository.Save();

                return RedirectToAction("Index");//View(new ThiSinhViewModel(ts));
                //return View(new ThiSinhViewModel(ts));
            }
            catch
            {
                ModelState.AddModelError("ThiSinh.Diem1", "Lỗi input !");
                return View(new ThiSinhViewModel(ts));
            }
        }
        
        //
        // GET: /ThiSinh/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            ThiSinh ts = _thiSinhRepository.GetThiSinh(id);
            var model = new ThiSinhViewModel(ts);
            return View(model);
        }

        //
        // POST: /ThiSinh/Edit/5

        [HttpPost, Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            ThiSinh ts = _thiSinhRepository.GetThiSinh(id);
            ThiSinhViewModel model = new ThiSinhViewModel(ts);
            string oldTruong = ts.Nganh.Truong.MaTruong;
            try
            {
                // TODO: Add update logic here
                UpdateModel(model);

                DateTime result;
                if (DateTime.TryParse(collection["ThiSinh_NgaySinh"], out result))
                    model.ThiSinh.NgaySinh = result;
                else
                {
                    ModelState.AddModelError("ThiSinh_NgaySinh", "Ngay Sinh sai dinh dang !");
                    return View(model);
                }
                
                if (model.ThiSinh.Nganh.Truong.MaTruong != oldTruong)
                    model.ThiSinh.SoBaoDanh = _thiSinhRepository.GenerateSBD(model.ThiSinh.Nganh.Truong.MaTruong);
                _thiSinhRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /ThiSinh/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            ThiSinh ts = _thiSinhRepository.GetThiSinh(id);

            return View(ts);
        }

        //
        // POST: /ThiSinh/Delete/5

        [HttpPost, Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ThiSinh ts = _thiSinhRepository.GetThiSinh(id);

            try
            {
                // TODO: Add delete logic here    
                _thiSinhRepository.Delete(ts);
                _thiSinhRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(ts);
            }
        }
    }
}
