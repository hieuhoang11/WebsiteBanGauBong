using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanGauBong.Entities;

namespace WebsiteBanGauBong.DAO
{
    public class HoaDonDAO
    {
        QLBanThuBongDB db;
        public HoaDonDAO()
        {
            db = new QLBanThuBongDB();
        }
        public List<HoaDon> getNewOrder()
        {
            List<HoaDon> list = db.HoaDons.Where(h => !h.XuLy).OrderBy(h=>h.NgayLap).ToList();
            return list;
        }
        public List<HoaDon> getAllOrder()
        {
            List<HoaDon> list = db.HoaDons.OrderBy(h => h.NgayLap).ToList();
            return list;
        }
        public void Insert(HoaDon hoadon)
        {
            db.HoaDons.Add(hoadon);
            db.SaveChanges();
        }
    }
}