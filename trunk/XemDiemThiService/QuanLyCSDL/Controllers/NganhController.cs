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
    public class NganhController : Controller
    {
        NganhRepository _nganhRepository = new NganhRepository();

        //
        // GET: /Nganh/

        public ActionResult Index(int page = 0)
        {
            const int pageSize = 20;
            var list = new PaginatedList<Nganh>(_nganhRepository.FindAllNganh(), page, pageSize);
            return View(list);
        }

        //
        // GET: /Nganh/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            var nganh = new Nganh();
            NganhViewModel viewModel = new NganhViewModel(nganh);

            return View(viewModel);
        } 

        //
        // POST: /Nganh/Create

        [HttpPost, Authorize(Roles = "Administrator")]
        public ActionResult Create(Nganh nganh, FormCollection collection)
        {
            if(ModelState.IsValid)
            {
                // TODO: Add insert logic here
                _nganhRepository.Add(nganh);
                _nganhRepository.Save();

                return RedirectToAction("Index");
            }
            else
            {
                return View(new NganhViewModel(nganh));
            }
        }
        
        //
        // GET: /Nganh/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var nganh = _nganhRepository.GetNganhById(id);
            NganhViewModel viewModel = new NganhViewModel(nganh);

            return View(viewModel);
        }

        //
        // POST: /Nganh/Edit/5

        [HttpPost, Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var nganh = _nganhRepository.GetNganhById(id);
            NganhViewModel viewModel = new NganhViewModel(nganh);

            try
            {
                // TODO: Add update logic here
                UpdateModel(viewModel);
                _nganhRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }

        //
        // GET: /Nganh/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Nganh nganh = _nganhRepository.GetNganhById(id);

            return View(nganh);
        }

        //
        // POST: /Nganh/Delete/5

        [HttpPost, Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Nganh nganh = _nganhRepository.GetNganhById(id);
            try
            {
                // TODO: Add delete logic here
                
                _nganhRepository.Delete(nganh);
                _nganhRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(nganh);
            }
        }

        //
        // POST: /Nganh/GetNganhByMaTruong/GTS

        //[AcceptVerbs(HttpVerbs.Get)]
        [HttpPost]
        public ActionResult GetNganhByMaTruong(string maTruong)
        {
            var lstNganh = _nganhRepository.GetNganhJSONByMaTruong(maTruong).ToList();
            return Json(lstNganh);//, JsonRequestBehavior.AllowGet);
        }
    }
}
