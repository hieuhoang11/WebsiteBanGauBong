using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGauBong.DAO;
using WebsiteBanGauBong.Entities;

namespace WebsiteBanGauBong.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TaiKhoan taikhoan)
        {
            TaiKhoanDAO a = new TaiKhoanDAO();
            Category cate = new Category();
           // ViewBag.listCategory = cate.getAllCategory();
            if (a.checkAccount(taikhoan.UserName, taikhoan.Pass))
                return RedirectToAction("Index", "DashboardAdmin");
            else
            {
                ViewBag.msg = "Login fail";
                return View(taikhoan);
            }
        }
    }
}