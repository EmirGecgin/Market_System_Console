using _1_Entity;
using _2_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Business
{
    public class ProductManager
    {
        ProductDAL productDAL;
        static ProductManager productManager;
        private ProductManager()
        {
            productDAL=ProductDAL.GetInstance();
        }
        public string Add(Product entity)
        {
            try
            {
                if (!IsProductComplete(entity))
                {
                    return "Ürün Bilgileri Hatalı";
                }
                return productDAL.Add(entity);
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
                if (entityId < 1)
                {
                    return "Seçmek istediğiniz değeri girin";
                }
                return productDAL.Delete(entityId);

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
                return productDAL.GetAll();
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
              return productDAL.GetById(id);
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
                try
                {
                    if (!IsProductComplete(entity))
                    {
                        return "Ürün Bilgileri Hatalı";
                    }
                    return productDAL.Update(entity);
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;  
                
            }
        }
        bool IsProductComplete(Product product)
        {
            if (string.IsNullOrEmpty(product.ProductName.Trim()))
            {
                return false;
            }
            if (product.CategoryId<1 ||product.ProductId<1||product.SupplierId<1||product.Price<0||product.Quantity<1)
            {
                return false;
            }
            return true;
        }
        public static ProductManager GetInstance()
        {

           if (productManager == null)
            {
                productManager = new ProductManager();
            }
            return productManager;
        }
    }
}
