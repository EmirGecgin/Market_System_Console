using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Entity
{
    public class Category
    {
        int _categoryId;
        string _categoryName,_detail;

        public Category(int categoryId, string categoryName, string detail)
        {
            _categoryId = categoryId;
            _categoryName = categoryName;
            _detail = detail;
        }

        public int CategoryId { get => _categoryId; set => _categoryId = value; }
        public string CategoryName { get => _categoryName; set => _categoryName = value; }
        public string Detail { get => _detail; set => _detail = value; }
    }
}
