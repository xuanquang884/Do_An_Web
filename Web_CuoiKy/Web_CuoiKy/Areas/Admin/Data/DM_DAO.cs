using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_CuoiKy.Models;

namespace Web_CuoiKy.Areas.Admin.Data
{
    public class DM_DAO
    {
        Model_SP db = null;
        public DM_DAO()
        {
            db = new Model_SP();
        }
        public List<Loai_SP> getALLLoai()
        {
            return db.Loai_SP.ToList();
        }
        public bool Insert(Loai_SP s)
        {
            try
            {
                db.Loai_SP.Add(s);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Loai_SP s)
        {
            try
            {
                var dao = db.Loai_SP.Find(s.MALOAI);
                dao.TENLOAI = s.TENLOAI;
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(string ma)
        {
            try
            {
                var dao = db.Loai_SP.Find(ma);
                db.Loai_SP.Remove(dao);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Loai_SP Detail(string id)
        {
            return db.Loai_SP.Find(id);
        }
    }
}