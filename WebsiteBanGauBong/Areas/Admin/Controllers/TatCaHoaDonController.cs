using System;
using System.Collections.Generic;
using System.Data;
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
    public class TatCaHoaDonController : Controller
    {
        private QLBanThuBongDB db = new QLBanThuBongDB();

        // GET: Admin/TatCaHoaDon
        public ActionResult Index(int ?page)
        {

            int pageNumber = (page ?? 1);
            int pageSize = 10;
            HoaDonDAO hdDAO = new HoaDonDAO();
            return View(hdDAO.getAllOrder().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/TatCaHoaDon/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

       

        // GET: Admin/TatCaHoaDon/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHang = new SelectList(db.Products, "ProductId", "Name", hoaDon.MaHang);
            return View(hoaDon);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,TenKhach,SoDT,MaHang,ghiChu,NgayLap,SoLuong,XuLy")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                        
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHang = new SelectList(db.Products, "ProductId", "Name", hoaDon.MaHang);
            return View(hoaDon);
        }

        // GET: Admin/TatCaHoaDon/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/TatCaHoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon.XuLy == false)
            {
                ProductDAO proDAO = new ProductDAO();
                Product product = proDAO.getProductByID(hoaDon.MaHang);
                product.Amounts = product.Amounts + hoaDon.SoLuong;
                proDAO.Edit(product);
            }
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
