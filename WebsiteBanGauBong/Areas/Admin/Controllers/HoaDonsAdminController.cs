using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGauBong.Entities;
using PagedList;
using WebsiteBanGauBong.DAO;

namespace WebsiteBanGauBong.Areas.Admin.Controllers
{
    public class HoaDonsAdminController : Controller
    {
        private QLBanThuBongDB db = new QLBanThuBongDB();

        // GET: Admin/HoaDonsAdmin
        public ActionResult Index(int?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            HoaDonDAO hdDAO = new HoaDonDAO();
            return View(hdDAO.getNewOrder().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/HoaDonsAdmin/Details/5
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
     
        // GET: Admin/HoaDonsAdmin/Edit/5
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

        // GET: Admin/HoaDonsAdmin/Delete/5
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

        // POST: Admin/HoaDonsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
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
