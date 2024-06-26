using _1_Entity;
using _3_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_UserInterface
{
    internal class Program
    {
        static ProductManager productManager; //konsola özgü statik olması.
        static CategoryManager categoryManager;
        static string username, userChoice;
        static List<Product> productList;
        static List<Category> categoryList;
        static Product chosenProduct;
        static void Init()
        {
            productManager = ProductManager.GetInstance();
            categoryManager = CategoryManager.GetInstance();
            username = "";
            userChoice = "";
        }
        static void Main(string[] args)
        {
            Init();
            Console.WriteLine("HOŞGELDİNİZ!");
            while (username.Length < 3)
            {
                Console.Write("İsminizi giriniz:");
                username = Console.ReadLine();
            }
            while (userChoice != "0")
            {
                ShowMenu();
                Console.Write("Seçiminizi yapınız:");
                userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "0":
                        break;
                    case "1":
                        GetProductList();
                        break;
                    case "2":
                        GetProductByName();
                        break;
                    case "3":
                        GetProductByCategory();
                        break;
                    case "4":
                        GetCategoryList();
                        break;
                    case "5":
                        AddProduct();
                        break;
                    case "6":
                        UpdateProduct();
                        break;
                    case "7":
                        DeleteProduct();
                        break;
                    case "8":
                        AddCategory();
                        break;
                    default:
                        Console.WriteLine("Hatalı Seçim");
                        break;
                }
            }




            Console.WriteLine("İyi Günler Dileriz.");
            Console.ReadLine();

        }

        private static void AddCategory()
        {
            Console.Write("Id : ");
            int categoryId = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Category Name : ");
            string categoryName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Category Detail : ");
            string categoryDetail = Console.ReadLine();
            Console.WriteLine();

            Category category = new Category(categoryId, categoryName, categoryDetail);
            Console.WriteLine(categoryManager.Add(category));
        }

        private static void DeleteProduct()
        {
            if (chosenProduct == null)
            {
                Console.WriteLine("Ürün seçiniz.");
                return;
            }
            Console.WriteLine("Güncelleme yapmak istediğinize emin misiniz? y/n");
            string choice = Console.ReadLine();
            while (1 == 1)
            {
                if (choice.ToLower() == "y")
                {
                    Console.WriteLine(productManager.Delete(chosenProduct.ProductId));
                    break;
                }
                else if (choice.ToLower() == "n")
                {
                    return;
                }
                Console.WriteLine("Hatalı tuşlama, y/n?");
                choice = Console.ReadLine();
            }

        }

        private static void UpdateProduct()
        {
            if (chosenProduct == null)
            {
                Console.WriteLine("Ürün seçiniz.");
                return;
            }

            Console.Write("Product Name : ");
            string productName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Category Name : ");
            string categoryName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Quantity : ");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Product Price : ");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Supplier Id: ");
            int supplierId = int.Parse(Console.ReadLine());
            Console.WriteLine();
            int categoryId = categoryManager.GetCategoryIdByName(categoryName);
            if (categoryId < 1)
            {
                Console.WriteLine("Hatalı giriş bilgisi");
                return;
            }
            Product product = new Product(chosenProduct.ProductId, quantity, categoryId, supplierId, productName, price);
            Console.WriteLine("Güncelleme yapmak istediğinize emin misiniz? y/n");
            string choice = Console.ReadLine();
            while (1==1)
            {
                if (choice.ToLower() == "y")
                {
                    Console.WriteLine(productManager.Update(product));
                    break;
                }
                else if (choice.ToLower() == "n")
                {
                    return;
                }
                Console.WriteLine("Hatalı tuşlama, y/n?");
                choice = Console.ReadLine();
            }
            

        }

        private static void AddProduct()
        {
            Console.Write("Id : ");
            int productId = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Product Name : ");
            string productName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Category Name : ");
            string categoryName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Quantity : ");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Product Price : ");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Supplier Id: ");
            int supplierId = int.Parse(Console.ReadLine());
            Console.WriteLine();
            int categoryId = categoryManager.GetCategoryIdByName(categoryName);
            if (categoryId < 1)
            {
                Console.WriteLine("Hatalı giriş bilgisi");
                return;
            }
            Product product = new Product(productId, quantity,categoryId , supplierId, productName, price);
            Console.WriteLine(productManager.Update(product)); 
        }

        private static void GetCategoryList()
        {
            categoryList=categoryManager.GetAll();
            foreach (Category item in categoryList)
            {
                Console.WriteLine($"Id: {item.CategoryId} Name: {item.CategoryName} Detail:{item.Detail}");
            }
        }

        private static void GetProductByCategory()
        {
            Console.Write("Kategori İsmi Girin:");
            string categoryName = Console.ReadLine();
            productList = productManager.GetAll();
            int categoryId = categoryManager.GetCategoryIdByName(categoryName);
            foreach (Product item in productList)
            {
                if (categoryId == item.CategoryId)
                {
                    Console.WriteLine($"Id: {item.ProductId} Name: {item.ProductName} Category:{categoryManager.GetCategoryNameById(item.CategoryId)} Quantity: {item.Quantity} Price: {item.Price} Supplier Id: {item.SupplierId}");
                    break;
                }
            }
        }

        private static void GetProductByName()
        {
            Console.Write("Seçmek istediğiniz ürünün ismini girin:");
            string productName = Console.ReadLine();
            productList = productManager.GetAll();
            foreach (Product item in productList)
            {
                if (item.ProductName.ToLower().Contains(productName.ToLower()))
                {
                    chosenProduct = item;
                    Console.WriteLine($"Id: {item.ProductId} Name: {item.ProductName} Category:{categoryManager.GetCategoryNameById(item.CategoryId)} Quantity: {item.Quantity} Price: {item.Price} Supplier Id: {item.SupplierId}");
                    break;
                }
            }
        }

        private static void GetProductList()
        {
            productList = productManager.GetAll();
            foreach (Product item in productList)
            {
                categoryList = categoryManager.GetAll();
                string CategoryName = "";
                foreach (Category cataegoryItem in categoryList)
                {
                    if (cataegoryItem.CategoryId == item.CategoryId)
                    {
                        CategoryName = cataegoryItem.CategoryName;
                        break;
                    }
                }
                Console.WriteLine("Id: {0} Name: {1} Category: {2} Quantity: {3} Unit Price: {4} Supplier: {5}", item.ProductId, item.ProductName, CategoryName, item.Quantity, item.Price, item.SupplierId);
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Sayın {0}, Seçiminizi Yapınız", username.ToUpper());
            Console.WriteLine();
            Console.WriteLine("Ana Menü");
            Console.WriteLine("1 - Tüm Ürünleri Listele");
            Console.WriteLine("2 - İsme Göre Ürünü Getir ve Seç");
            Console.WriteLine("3 - Kategoriye Göre Ürün Getir");
            Console.WriteLine("4 - Kategorileri Listele");
            Console.WriteLine("5 - Yeni Ürün Ekle");
            Console.WriteLine("6 - Seçilen Ürünü Güncelle");
            Console.WriteLine("7 - Seçilen Ürünü Sil");
            Console.WriteLine("8 - Yeni Kategori Ekle");
            Console.WriteLine();
            Console.WriteLine("0 - Çıkmak İçin Sıfıra Basınız");
            Console.WriteLine();
        }
    }
}
