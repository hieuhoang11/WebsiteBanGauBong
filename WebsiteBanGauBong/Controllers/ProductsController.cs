using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGauBong.DAO;
using PagedList;
using PagedList.Mvc;
using WebsiteBanGauBong.Entities;

namespace WebsiteBanGauBong.Controllers
{
    public class ProductsController : Controller
    {             
        public ProductsController()
        {
            CategoryDAO cateDao = new CategoryDAO();
            ViewBag.listCate = cateDao.getAllCate();          
        }
        // GET: Products
        public ActionResult ProductsByCate(long? cateID,int? page)
        {
            //tao so san pham tren trang 
            int pageSize = 10;
            //tao bien so trang
            int pageNumber = (page ?? 1);
            ProductDAO proDAO = new ProductDAO();
            var list = proDAO.getAllProductByCateID(cateID);
            if (list.Count == 0)
            {
                ViewBag.mes = "Không có sản phẩm nào!";               
            }
            else
            {
                CategoryDAO cateDao = new CategoryDAO();
                ViewBag.mes = cateDao.getNameByID(cateID).Name;
                ViewBag.Id = cateID;
            }
            ViewBag.cateID = cateID;
            return View(list.ToList().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ProductsByProCate(long? proCateID, int? page)
        {
            //tao so san pham tren trang 
            int pageSize = 10;
            //tao bien so trang
            int pageNumber = (page ?? 1);
            ProductDAO proDAO = new ProductDAO();
            var list = proDAO.getAllProductByProCateID(proCateID);
            if (list.Count == 0)
            {
                ViewBag.mes = "Không có sản phẩm nào!";
            }
            else
            {
                ProductCategoryDAO procateDao = new ProductCategoryDAO();
                ViewBag.mes = procateDao.getNameByID(proCateID).Name;
            }
            ViewBag.proCateID = proCateID;
            return View(list.ToList().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult KhuyenMai(int? page)
        {
            //tao so san pham tren trang 
            int pageSize = 10;
            //tao bien so trang
            int pageNumber = (page ?? 1);
            ProductDAO proDAO = new ProductDAO();
            var list = proDAO.getGiamGia();
            if (list.Count == 0)
            {
                ViewBag.mes = "Không có sản phẩm nào!";
            }
            else
            {
                ProductCategoryDAO procateDao = new ProductCategoryDAO();
                ViewBag.mes = "Gấu Bông Khuyến Mãi";
            }            
            return View(list.ToList().ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(long? proID)
        {
            ProductDAO proDAO = new ProductDAO();
            Product product = proDAO.getProductByID(proID);
            if (product==null)
            {
                ViewBag.mes = "Không tìm được sản phẩm";
                return View();
            }
            return View(product);
        }
        public ActionResult Price(int? gia , int? den, int?page)
        {
            //tao so san pham tren trang 
            int pageSize = 10;
            //tao bien so trang
            int pageNumber = (page ?? 1);
            ProductDAO proDAO = new ProductDAO();
            var list = proDAO.getTheoGia(gia, den);
            if (list.Count == 0)
            {
                ViewBag.mes = "Không có sản phẩm nào!";
            }
            else
            {
                ProductCategoryDAO procateDao = new ProductCategoryDAO();
                ViewBag.mes = "Gấu Bông Giá Từ " + gia + "K Đến " + den +"K";
            }
            ViewBag.gia = gia;
            ViewBag.den = den;
            return View(list.ToList().ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Search(FormCollection f, int? page)
        {
            String sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            //tao so san pham tren trang 
            int pageSize = 10;
            //tao bien so trang
            int pageNumber = (page ?? 1);
            ProductDAO proDAO = new ProductDAO();
            var list = proDAO.Search(sTuKhoa);
            if (list.Count == 0)
            {
                ViewBag.mes = "Không có sản phẩm nào!";
            }
            else
            {
                ProductCategoryDAO procateDao = new ProductCategoryDAO();
                ViewBag.mes = "Có " + list.Count + " Kết Quả" ;
            }         
            return View(list.OrderBy(p=>p.Name).ToList().ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Search(String sTuKhoa, int? page)
        {
            ViewBag.TuKhoa = sTuKhoa;
            //tao so san pham tren trang 
            int pageSize = 10;
            //tao bien so trang
            int pageNumber = (page ?? 1);
            ProductDAO proDAO = new ProductDAO();
            var list = proDAO.Search(sTuKhoa);
            if (list.Count == 0)
            {
                ViewBag.mes = "Không có sản phẩm nào!";
            }
            else
            {
                ProductCategoryDAO procateDao = new ProductCategoryDAO();
                ViewBag.mes = "Có " + list.Count + " Kết Quả";
            }
            return View(list.OrderBy(p => p.Name).ToList().ToPagedList(pageNumber, pageSize));
        }
    }
}