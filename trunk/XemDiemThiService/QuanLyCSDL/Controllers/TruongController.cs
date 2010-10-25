using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyCSDL.Helpers;
using QuanLyCSDL.DAL;
using QuanLyCSDL.Models;

namespace QuanLyCSDL.Controllers
{
    public class TruongController : Controller
    {
        TruongRepository _truongRepository = new TruongRepository();

        //
        // GET: /Truong/Page/1

        public ActionResult Index(int page = 0)
        {
            const int pageSize = 20;
            var query = new TruongRepository().FindAllTruong();
            PaginatedList<Truong> list = new PaginatedList<Truong>(query, page, pageSize);
            return View(list);
        }

        //
        // GET: /Truong/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View( new Truong() );
        } 

        //
        // POST: /Truong/Create

        [HttpPost, Authorize(Roles="Administrator")]
        public ActionResult Create(Truong truong)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                _truongRepository.Add(truong);
                _truongRepository.Save();
                return RedirectToAction("Index");
            }

            return View(truong);
        }
        
        //
        // GET: /Truong/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(string id)
        {
            Truong tr = _truongRepository.GetTruongByMaTruong(id);
            return View(tr);
        }

        //
        // POST: /Truong/Edit/5

        [HttpPost, Authorize(Roles = "Administrator")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            Truong truong = _truongRepository.GetTruongByMaTruong(id);
            try
            {
                // TODO: Add update logic here
                UpdateModel(truong);
                _truongRepository.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(truong);
            }
        }

        //
        // GET: /Truong/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string id)
        {
            Truong tr = _truongRepository.GetTruongByMaTruong(id);

            return View(tr);
        }

        //
        // POST: /Truong/Delete/5

        [HttpPost, Authorize(Roles = "Administrator")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            Truong tr = _truongRepository.GetTruongByMaTruong(id);
            try
            {
                // TODO: Add delete logic here

                _truongRepository.Delete(tr);

                _truongRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(tr);
            }
        }
    }
}
