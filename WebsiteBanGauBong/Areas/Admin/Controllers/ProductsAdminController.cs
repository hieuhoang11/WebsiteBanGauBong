using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGauBong.DAO;
using WebsiteBanGauBong.Entities;
using PagedList;
using PagedList.Mvc;

namespace WebsiteBanGauBong.Areas.Admin.Controllers
{
    public class ProductsAdminController : Controller
    {
        ProductDAO proDAO;
        public ProductsAdminController()
        {
            proDAO = new ProductDAO();
        }
        // GET: Admin/Products
        public ActionResult Index(int? page)
        {
            int pageNumber = (page??1);
            int pageSize = 10;
            return View(proDAO.getAllProduct().OrderBy(p=>p.Name).ToPagedList(pageNumber,pageSize));
        }

        public ActionResult ThemMoi()
        {
            QLBanThuBongDB db = new QLBanThuBongDB();
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ProductCategoryID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(Product product)
        {

            if (ModelState.IsValid)
            {
                proDAO.Insert(product);                
                Redirect("Index");
            }
            QLBanThuBongDB db = new QLBanThuBongDB();
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ProductCategoryID", "Name", product.ProductCategoryID);
            return View(product);
        }

        public ActionResult ChiTiet(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = proDAO.getProductByID(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Xoa(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLBanThuBongDB db = new QLBanThuBongDB();
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoa(int id)
        {
            QLBanThuBongDB db = new QLBanThuBongDB();
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: AdminSite/HangHoas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product hangHoa = proDAO.getProductByID(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            QLBanThuBongDB db = new QLBanThuBongDB();
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ProductCategoryID", "Name", hangHoa.ProductCategoryID);
            return View(hangHoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Code,Images,Price,PromotionPrice,Amounts,Detail,ProductCategoryID")] Product hangHoa)
        {
            QLBanThuBongDB db = new QLBanThuBongDB();
            if (ModelState.IsValid)
            {
                db.Entry(hangHoa).State = EntityState.Modified;              
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ProductCategoryID", "Name", hangHoa.ProductCategoryID);
            return View(hangHoa);
        }
    }
}