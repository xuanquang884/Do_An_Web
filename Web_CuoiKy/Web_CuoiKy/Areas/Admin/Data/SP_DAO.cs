using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_CuoiKy.Models;

namespace Web_CuoiKy.Areas.Admin.Data
{
    public class SP_DAO
    {
        Model_SP db = null;
        public SP_DAO()
        {
            db = new Model_SP();
        }

        public List<San_Pham> listALL()
        {
            return db.San_Pham.ToList();
        }

        public bool Insert(San_Pham s)
        {
            try
            {
                db.San_Pham.Add(s);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(San_Pham s)
        {
            try
            {
                var dao = db.San_Pham.Find(s.MASP);
                dao.MALOAISP = s.MALOAISP;
                dao.TENSP = s.TENSP;
                dao.MOTA = s.MOTA;
                dao.GIA = s.GIA;
                dao.SOLUONG = s.SOLUONG;
                dao.TINHTRANG = s.TINHTRANG;
                dao.LUOTVIEW = s.LUOTVIEW;
                if (s.HINH != null)
                    dao.HINH = s.HINH;
                if (s.HINH1 != null)
                    dao.HINH1 = s.HINH1;
                if (s.HINH2 != null)
                    dao.HINH2 = s.HINH2;
                if (s.HINH3 != null)
                    dao.HINH3 = s.HINH3;
                if (s.HINH4 != null)
                    dao.HINH4 = s.HINH4;
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int ma)
        {
            try
            {
                var dao = db.San_Pham.Find(ma);
                db.San_Pham.Remove(dao);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public San_Pham Detail(int id)
        {
            return db.San_Pham.Find(id);
        }

        public List<San_Pham> listByCategory(string madanhmuc)
        {
            return db.San_Pham.Where(x => x.MALOAISP == madanhmuc).ToList();
        }
    }
}