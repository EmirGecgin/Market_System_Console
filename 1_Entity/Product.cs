using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Entity
{
    public class Product
    {
        int _productId,_quantity,_categoryId,_supplierId;
        string _productName;
        double _price;

        public Product(int productId, int quantity, int categoryId, int supplierId, string productName, double price)
        {
            _productId = productId;
            _quantity = quantity;
            _categoryId = categoryId;
            _supplierId = supplierId;
            _productName = productName;
            _price = price;
        }

        public int ProductId { get => _productId; set => _productId = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public int CategoryId { get => _categoryId; set => _categoryId = value; }
        public int SupplierId { get => _supplierId; set => _supplierId = value; }
        public string ProductName { get => _productName; set => _productName = value; }
        public double Price { get => _price; set => _price = value; }
    }
}
