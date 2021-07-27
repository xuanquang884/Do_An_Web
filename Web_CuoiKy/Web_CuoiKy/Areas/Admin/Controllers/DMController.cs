using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_CuoiKy.Areas.Admin.Data;
using Web_CuoiKy.Models;

namespace Web_CuoiKy.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DMController : Controller
    {
        // GET: Admin/DM
        public ActionResult Index()
        {
            var dao = new DM_DAO().getALLLoai();
            return View(dao);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Loai_SP dm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dao = new DM_DAO().Insert(dm);
                    if (dao)
                        return RedirectToAction("Index", "DM");
                    else
                        ModelState.AddModelError("", "Loi");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Loi try catch");
                }
            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            var dao = new DM_DAO().Detail(id);
            return View(dao);
        }

        [HttpPost]
        public ActionResult Edit(Loai_SP dm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dao = new DM_DAO().Update(dm);
                    if (dao)
                        return RedirectToAction("Index", "DM");
                    else
                        ModelState.AddModelError("", "Loi");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Loi try catch");
                }
            }
            return View();
        }
        public ActionResult Delete(string id)
        {
            var dao = new DM_DAO().Detail(id);
            return View(dao);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            new DM_DAO().Delete(id);
            return RedirectToAction("Index", "DM");
        }
    }
}