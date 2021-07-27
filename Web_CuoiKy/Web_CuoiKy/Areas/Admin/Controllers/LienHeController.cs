using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_CuoiKy.Areas.Admin.Data;

namespace Web_CuoiKy.Areas.Admin.Controllers
{
    public class LienHeController : Controller
    {
        // GET: Admin/LienHe
        public ActionResult Index()
        {
            var dao = new LienHeDAO().getAll();
            return View(dao);
        }
    }
}