using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGauBong.DAO;
using WebsiteBanGauBong.Entities;

namespace WebsiteBanGauBong.Controllers
{
    public class MuaHangController : Controller
    {
        public MuaHangController()
        {
            CategoryDAO cateDao = new CategoryDAO();
            ViewBag.listCate = cateDao.getAllCate();
        }
        //public ActionResult SanPham()
        //{           
        //    return View();
        //}
        // GET: MuaHang
        [HttpGet]
        public ActionResult SanPham(long sp)
        {
            ProductDAO proDAO = new ProductDAO();
            Product pro = proDAO.getProductByID(sp);
            if (pro == null)
            {
                ViewBag.mes = "Không tìm được sản phẩm";                
                return View();
            }
            else
            {                 
                List<long> list = new List<long>();
                list.Add(1);
                list.Add(2); list.Add(3);
                ViewBag.txtSL = list;
                return View(pro);
            }
        }

        [HttpPost]
        public ActionResult XacNhan(FormCollection f , long sp)
        {
            ProductDAO proDAO = new ProductDAO();
            Product pro = proDAO.getProductByID(sp);
            if (pro == null)
            {
                ViewBag.mes = "Không tìm được sản phẩm";
                return View();
            }
            String soLuong = f["txtSL"].ToString();
            if (Convert.ToInt64(soLuong) > pro.Amounts)
            {
                ViewBag.mes = "Số Lượng Hàng Hiện Không Đủ !";
                return View();
            }
            String tenKhach = f["txtTen"].ToString();
            String sdt = f["txtSDT"].ToString();
            String diachi = f["txtDiaChi"].ToString();
            String yeuCau = f["txtYeuCau"].ToString()!=""? f["txtYeuCau"].ToString() :"không có yêu cầu";
            
            HoaDon hoadon = new HoaDon();
            hoadon.TenKhach = tenKhach;
            hoadon.SoDT = sdt;
            hoadon.MaHang = sp;
            hoadon.ghiChu = yeuCau;
            hoadon.XuLy = false;
            hoadon.NgayLap = DateTime.Now;
            hoadon.SoLuong = Convert.ToInt32(soLuong);

            pro.Amounts = pro.Amounts - hoadon.SoLuong;
            proDAO.Edit(pro);

            if (ModelState.IsValid)
            {
                HoaDonDAO hoadonDAO = new HoaDonDAO();
                hoadonDAO.Insert(hoadon);
                ViewBag.mes = "Đặt hàng thành công";
                return View();
            }           
            else
            {
                ViewBag.mes = "Đặt hàng thất bại";
                return View();
            }       
        }
    }
}