using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_Entity;

namespace _2_DataAccess
{
    public class CategoryDAL : IRepostry<Category>
    {
        List<Category> _categories;
        static CategoryDAL categoryDAL;
        public CategoryDAL()
        {
            _categories = new List<Category>();
            _categories.Add(new Category(1, "Temizlik Kategorisi", "Temizlik Ürünlerini Barındıran Kategori"));
            _categories.Add(new Category(2, "Konserve Kategorisi", "Konserve Ürünlerini Barındıran Kategori"));
            _categories.Add(new Category(3, "Gıda", "Gıda Ürünlerini Barındıran Kategori"));
            _categories.Add(new Category(4, "Bahçe Malzeme Kategorisi", "Bahçe Malzemelerini Barındıran Kategori"));
        }

        public List<Category> GetAll()
        {
            try
            {
                return _categories;
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
                foreach (Category item in _categories)
                {
                    if (item.CategoryId == id)
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

        public string Add(Category entity)
        {
            try
            {
                _categories.Add(entity);
                return entity.CategoryName + "Kategori Eklendi";
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
                for (int i = 0; i < _categories.Count; i++)
                {
                    if (_categories[i].CategoryId == entity.CategoryId)
                    {
                           _categories[i] = entity;
                        return entity.CategoryName + "Kategori Güncellendi";
                    }
                } 
                return "Kategori Bulunamadı";
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
                foreach (Category item in _categories)
                {
                    if (item.CategoryId == entityId)
                    {
                        _categories.Remove(item);
                        return item.CategoryName + "Kategori Silindi";
                    }
                }
                return "Kategori Bulunamadı";
            }
            catch (Exception ex)
            {

                return ex.Message;  
            }
        }

        public static CategoryDAL GetInstance()
        {
            if (categoryDAL == null)
            {
                categoryDAL=new CategoryDAL();
            }
            return categoryDAL;
        }
    }

}
