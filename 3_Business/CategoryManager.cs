using _1_Entity;
using _2_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Business
{
    public class CategoryManager
    {
        CategoryDAL categoryDAL;
        static CategoryManager categoryManager;
        private CategoryManager()
        {
            categoryDAL=CategoryDAL.GetInstance();
        }
        public List<Category> GetAll()
        {
            try
            {
              return categoryDAL.GetAll();
            }
            catch (Exception ex)
            {
                return new List<Category>();
            }
        }
        public Category GetById(int id)
        {
            try
            {
              return categoryDAL.GetById(id);
            }
            catch (Exception)
            {

              return null;  
            }

        }

        public string Add(Category entity)
        {
            try
            {
                if (!IsCategoryComplete(entity))
                {
                    return "Kategori Bilgileri Hatalı";
                }
                return categoryDAL.Add(entity);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string Update(Category entity)
        {
            try
            {
                if (!IsCategoryComplete(entity))
                {
                    return "Kategori Bilgileri Hatalı";
                }
               return categoryDAL.Update(entity);
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
                    return "Seçmek istediğiniz kategoriyi girin";
                }
                return categoryDAL.Delete(entityId);
            }
            catch (Exception ex)
            {
                return ex.Message;
                
            }
        }
        public bool IsCategoryComplete(Category category)
        {
            if (category.CategoryId < 1)
            {
                return false;
            }
            if(string.IsNullOrEmpty(category.CategoryName.Trim())|| string.IsNullOrEmpty(category.Detail.Trim()))
            {
                return false;
            }
            return true;
        }

        public static CategoryManager GetInstance()
        {
            if (categoryManager == null)
            {
                categoryManager = new CategoryManager();
            }
            return categoryManager;
        }
        public string GetCategoryNameById(int categoryId)
        {
            try
            {
                var categories = GetAll();

                foreach (Category cataegoryItem in categories)
                {
                    if (cataegoryItem.CategoryId == categoryId)
                    {
                        return cataegoryItem.CategoryName;
                    }
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
            return "";
        }
        public int GetCategoryIdByName(string categoryName)
        {
            try
            {
                var categories = GetAll();

                foreach (Category cataegoryItem in categories)
                {
                    if (cataegoryItem.CategoryName.ToLower().Contains(categoryName.ToLower()))
                    {
                        return cataegoryItem.CategoryId;
                    }
                }
            }
            catch (Exception ex)
            {

                return 0;
            }

            return 0;
        }
    }
}
