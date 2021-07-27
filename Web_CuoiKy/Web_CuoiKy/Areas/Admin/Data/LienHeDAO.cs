using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_CuoiKy.Models;

namespace Web_CuoiKy.Areas.Admin.Data
{
    public class LienHeDAO
    {
        Model_SP db = null;
        public LienHeDAO()
        {
            db = new Model_SP();
        }
        public List<LienHe> getAll()
        {
            return db.LienHes.ToList();
        }
    }
}