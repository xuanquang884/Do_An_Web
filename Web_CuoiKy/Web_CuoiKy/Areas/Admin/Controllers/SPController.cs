using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_CuoiKy.Areas.Admin.Data;
using Web_CuoiKy.Models;

namespace Web_CuoiKy.Areas.Admin.Controllers
{
    public class SPController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/SP
        public ActionResult Index()
        {
            var dao = new SP_DAO().listALL();
            return View(dao);
        }
        public void set(string selected = null)
        {
            var dao = new DM_DAO();
            ViewBag.MALOAISP = new SelectList(dao.getALLLoai(), "MALOAI", "TENLOAI", selected);
        }
        public ActionResult Create()
        {
            set();
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase HINH, HttpPostedFileBase HINH1, HttpPostedFileBase HINH2,
            HttpPostedFileBase HINH3, HttpPostedFileBase HINH4,San_Pham s)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fineName = Path.GetFileName(HINH.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images"), fineName);
                    HINH.SaveAs(path);
                    s.HINH = fineName;

                    var fineName1 = Path.GetFileName(HINH1.FileName);
                    string path1 = Path.Combine(Server.MapPath("~/Images"), fineName1);
                    HINH1.SaveAs(path1);
                    s.HINH1 = fineName1;

                    var fineName2 = Path.GetFileName(HINH2.FileName);
                    string path2 = Path.Combine(Server.MapPath("~/Images"), fineName2);
                    HINH2.SaveAs(path2);
                    s.HINH2 = fineName2;

                    var fineName3 = Path.GetFileName(HINH3.FileName);
                    string path3 = Path.Combine(Server.MapPath("~/Images"), fineName3);
                    HINH3.SaveAs(path3);
                    s.HINH3 = fineName3;

                    var fineName4 = Path.GetFileName(HINH4.FileName);
                    string path4 = Path.Combine(Server.MapPath("~/Images"), fineName4);
                    HINH4.SaveAs(path4);
                    s.HINH4 = fineName4;

                    var dao = new SP_DAO().Insert(s);
                    if (dao)
                        return RedirectToAction("Index", "SP");
                    else
                        ModelState.AddModelError("", "Loi");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Loi trycatch");
                }
            }
            set();
            return View();
        }

        public ActionResult Edit(int id)
        {
            set();
            var dao = new SP_DAO().Detail(id);
            return View(dao);
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase HINH, HttpPostedFileBase HINH1, HttpPostedFileBase HINH2,
            HttpPostedFileBase HINH3, HttpPostedFileBase HINH4, San_Pham s)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(HINH != null)
                    {
                        var fineName = Path.GetFileName(HINH.FileName);
                        string path = Path.Combine(Server.MapPath("~/Images"), fineName);
                        HINH.SaveAs(path);
                        s.HINH = fineName;
                    }
                   

                    if (HINH1 != null)
                    {
                        var fineName1 = Path.GetFileName(HINH1.FileName);
                        string path1 = Path.Combine(Server.MapPath("~/Images"), fineName1);
                        HINH1.SaveAs(path1);
                        s.HINH1 = fineName1;
                    }
                    

                    if (HINH2 != null)
                    {
                        var fineName2 = Path.GetFileName(HINH2.FileName);
                        string path2 = Path.Combine(Server.MapPath("~/Images"), fineName2);
                        HINH2.SaveAs(path2);
                        s.HINH2 = fineName2;
                    }
                   

                    if (HINH3 != null)
                    {
                        var fineName3 = Path.GetFileName(HINH3.FileName);
                        string path3 = Path.Combine(Server.MapPath("~/Images"), fineName3);
                        HINH3.SaveAs(path3);
                        s.HINH3 = fineName3;
                    }
                        

                    if (HINH4 != null)
                    {
                        var fineName4 = Path.GetFileName(HINH4.FileName);
                        string path4 = Path.Combine(Server.MapPath("~/Images"), fineName4);
                        HINH4.SaveAs(path4);
                        s.HINH4 = fineName4;
                    }
                       
                    var dao = new SP_DAO().Update(s);
                    if (dao)
                        return RedirectToAction("Index", "SP");
                    else
                        ModelState.AddModelError("", "Loi");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Loi trycatch");
                }
            }
            set();
            return View();
        }
        public ActionResult Details(int id)
        {
            var dao = new SP_DAO().Detail(id);
            return View(dao);
        }
        public ActionResult Delete(int id)
        {
            var dao = new SP_DAO().Detail(id);
            return View(dao);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            new SP_DAO().Delete(id);
            return RedirectToAction("Index", "SP");
        }
    }
}