using _1_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_DataAccess
{
    public class ProductDAL : IRepostry<Product>
    {
        List<Product> products;
        static ProductDAL productDAL;
        public ProductDAL()
        {
            products = new List<Product>();
            products.Add(new Product(1, 15, 1, 1, "Çamaşır Suyu", 10.25));
            products.Add(new Product(2, 25,2,3, "Domates", 5.50));
            products.Add(new Product(3,12,4,3, "Bahçe Makası",30));
            products.Add(new Product(4, 150, 2,4, "Dondurulmuş Bezelye",3.75));

        }
        public string Add(Product entity)
        {
            try
            {
                products.Add(entity);
                return entity.ProductName +" Ürün Eklendi";
            }
            catch (Exception ex)
            {

               return ex.Message;
            }
        }

        public string Delete(int entityId)
        {
            try
            {
                foreach (Product item in products)
                {
                    if (item.ProductId == entityId)
                    {
                        products.Remove(item);
                        return item.ProductName + " Ürünü silindi.";
                    }
                }
                return "Ürün bulunamadı.";
                        
            }
            catch (Exception ex)
            {

                return ex.Message;  
            }
        }

        public List<Product> GetAll()
        {
            try
            {
                return products;
            }
            catch (Exception)
            {

                return new List<Product>();
            }
        }

        public Product GetById(int id)
        {
            try
            {
                foreach (Product item in products)
                {
                    if (item.ProductId == id)
                    {
                        return item;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string Update(Product entity)
        {
            try
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if(products[i].ProductId == entity.ProductId)
                    {
                        products[i] = entity;
                        return entity.ProductName + "güncellendi.";
                    }
                }
                return "Ürün bulunamadı.";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public static ProductDAL GetInstance()
        {
            if (productDAL == null)
            {
                productDAL = new ProductDAL();
            }
            return productDAL;
        }
    }
}
