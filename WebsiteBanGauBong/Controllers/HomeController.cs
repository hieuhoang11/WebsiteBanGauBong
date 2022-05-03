using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGauBong.DAO;

namespace WebsiteBanGauBong.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CategoryDAO cateDao = new CategoryDAO();
            ViewBag.listCate = cateDao.getAllCate();
            return View();
        }       
        
    }
}