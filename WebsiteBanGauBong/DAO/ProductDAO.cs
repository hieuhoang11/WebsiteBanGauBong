using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanGauBong.Entities;

namespace WebsiteBanGauBong.DAO
{
    public class ProductDAO
    {
        QLBanThuBongDB db;
        public ProductDAO()
        {
            db = new QLBanThuBongDB();
        }

        public List<Product> getAllProduct()
        {          
            return db.Products.ToList();
        }


        public Product getProductByID(long? productID)
        {
            Product re = db.Products.SingleOrDefault(p=>p.ProductId == productID);
            return re;
        }
        public List<Product> getProductByIDCate(int number,long? cateID)
        {
            var model = from a in db.Categories
                        join b in db.ProductCategories
                        on a.CategoryId equals b.CategoryId
                        join c in db.Products
                        on b.ProductCategoryId equals c.ProductCategoryID
                        where a.CategoryId == cateID
                        select c;
            return model.Take(number).ToList();
        }

        public List<Product> getAllProductByCateID( long? cateID)
        {
            var model = from a in db.Categories
                        join b in db.ProductCategories
                        on a.CategoryId equals b.CategoryId
                        join c in db.Products
                        on b.ProductCategoryId equals c.ProductCategoryID
                        where a.CategoryId == cateID
                        select c;
            return model.ToList();
        }

        public List<Product> getProductByProCateID(int number, long? procateID)
        {
            var model = from a in db.Products                                             
                        where a.ProductCategoryID == procateID
                        select a;
            return model.Take(number).ToList();
        }

        public List<Product> getAllProductByProCateID(long? procateID)
        {
            var model = from a in db.Products
                        where a.ProductCategoryID == procateID
                        select a;
            return model.ToList();
        }

        public List<Product> getGiamGia()
        {
            var model = from a in db.Products
                        where a.PromotionPrice > 0 
                        select a;
            return model.ToList();
        }

        public List<Product> getTheoGia(int? tu ,int? den)
        {
            var model = from a in db.Products
                        where a.Price > tu & a.Price <= den
                        select a;
            return model.ToList();
        }

        public List<Product> Search(String sTuKhoa)
        {
            
            var model = from a in db.Products
                        where a.Name.Contains(sTuKhoa) || a.Code.Contains(sTuKhoa)
                        select a;
            // var model = db.Products.Where(p=>p.Name.Contains(sTuKhoa));
            return model.ToList();
        }

        public void Insert(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static String convertPrice(String price)
        {
            String t = price;
            if(price.Length > 3)
            {
                t = price.Substring(0,price.Length - 3) + "." + price.Substring(price.Length-3);
            }
            return t + ".000";
        }

        public static String giamGia(String price, String phanTram)
        {
            Double giaMoi = Convert.ToDouble(price);
            Double giam = (Convert.ToDouble(price) * (Convert.ToDouble(phanTram) / 100));
            giaMoi -= giam;
            String re = giaMoi.ToString().Split('.')[0];
            return convertPrice(re);
        }
        public static String TietKiem(String price, String phanTram)
        {           
            Double tietKiem = (Convert.ToDouble(price) * (Convert.ToDouble(phanTram) / 100));
            String []data = (tietKiem).ToString().Split('.');
            String re = data[0];
            if (data.Length > 1)  re =( Convert.ToDouble(data[0]) + 1 ).ToString();
            return convertPrice(re);
        }
    }
}