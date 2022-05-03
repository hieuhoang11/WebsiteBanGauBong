using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanGauBong.Entities;

namespace WebsiteBanGauBong.DAO
{
    public class TaiKhoanDAO
    {
        public QLBanThuBongDB db;
        public TaiKhoanDAO()
        {
            db = new QLBanThuBongDB();
        }
        public Boolean checkAccount(String user, String pass)
        {
            Boolean rt = false;
            var query = db.TaiKhoans.Where(x => x.UserName.Equals(user));
            rt = (query.Where(x => x.Pass.Equals(pass)).Count() > 0);
            return rt;
        }
    }
}