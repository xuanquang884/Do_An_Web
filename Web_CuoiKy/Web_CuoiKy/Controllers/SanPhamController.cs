using System.Linq;
using System.Net;
using System.Web.Mvc;
using Web_CuoiKy.Models;
using PagedList.Mvc;
using PagedList;

namespace Web_CuoiKy.Controllers
{
    public class SanPhamController : Controller
    {
        Model_SP db = new Model_SP();
        // GET: SanPham
        public ActionResult Index(string seachBy, string seach)
        {
            if (seachBy == "NameProduct")
                return View(db.San_Pham.Where(s => s.TENSP.StartsWith(seach)).ToList());
            else if (seachBy == "Category")
                return View(db.San_Pham.Where(s => s.MALOAISP.StartsWith(seach)).ToList());
            else
                return View(db.San_Pham.ToList());

        }
        int pageSize = 9;
        public ActionResult SanPham(int pageNo = 1)
        {
            var listsanpham = db.San_Pham.ToList().ToPagedList(pageNo, pageSize);
            return View(listsanpham);
        }
        public ActionResult Ao_Khoac(int pageNo = 1)
        {
            var listsanpham = db.San_Pham.Where(p => p.MALOAISP == "AK01").ToList().ToPagedList(pageNo, pageSize);
            return View(listsanpham);
        }
        public ActionResult Ao_SoMi(int pageNo = 1)
        {
            var listsanpham = db.San_Pham.Where(p => p.MALOAISP == "ASM01").ToList().ToPagedList(pageNo, pageSize);
            return View(listsanpham);
        }
        public ActionResult Quan_Jeans(int pageNo = 1)
        {
            var listsanpham = db.San_Pham.Where(p => p.MALOAISP == "QJ01").ToList().ToPagedList(pageNo, pageSize);
            return View(listsanpham);
        }
        public ActionResult Quan_Tay(int pageNo = 1)
        {
            var listsanpham = db.San_Pham.Where(p => p.MALOAISP == "QT01").ToList().ToPagedList(pageNo, pageSize);
            return View(listsanpham);
        }
        public ActionResult Phu_Kien(int pageNo = 1)
        {
            var listsanpham = db.San_Pham.Where(p => p.MALOAISP == "PK01").ToList().ToPagedList(pageNo, pageSize);
            return View(listsanpham);
        }
        public ActionResult ChiTietSP(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            San_Pham sp = db.San_Pham.Find(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
    }
}