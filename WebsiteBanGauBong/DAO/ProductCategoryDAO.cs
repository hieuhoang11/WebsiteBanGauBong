using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanGauBong.Entities;

namespace WebsiteBanGauBong.DAO
{
    public class ProductCategoryDAO
    {
        public QLBanThuBongDB db;
        public ProductCategoryDAO()
        {
            db = new QLBanThuBongDB();
        }
        public List<ProductCategory> getAllProductCategoryByCate(long categoryID)
        {
            var re = db.ProductCategories.Where(m => m.CategoryId == categoryID).ToList();
            return re;
        }
        public ProductCategory getNameByID(long? ID)
        {
            var re = db.ProductCategories.SingleOrDefault(c => c.ProductCategoryId == ID);
            return re;
        }
    }
}