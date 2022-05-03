using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebsiteBanGauBong.Entities;

namespace WebsiteBanGauBong.DAO
{
    public class CategoryDAO
    {
        QLBanThuBongDB db ;
        public CategoryDAO()
        {
            db = new QLBanThuBongDB();
        }
        public List<Category> getAllCate()
        {
            var re = db.Categories.ToList();
            return re;
        }
        public Category getNameByID(long? ID)
        {
            var re = db.Categories.SingleOrDefault(c=>c.CategoryId==ID);
            return re;
        }
        public void Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }
        public void Edit(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
        }
        
    }
}