using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public enum Category {
        Electronics, Grocery, Clothing, Stationery
    }
    public class Product
    {
        public int Id;
        public string Name;
        public decimal Price;
        public int Quanity;
        public Category Category;
    }
    public class Program
    {
        List<Product> products = new List<Product>();
        int nextID = 1;

        static void Main()
        {
            AddProduct("PC", 50000, 5, Category.Electronics);
            AddProduct("Bread", 45, 20, Category.Grocery);
            AddProduct("T-Shirt", 640, 10, Category.Clothing);
            AddProduct("Notebook", 30, 100, Category.Stationery);
            AddProduct("Smartphone", 12000, 20, Category.Electronics);

            bool running = true;
            while (true) {
                Console.WriteLine("Меню");
                Console.WriteLine("1. Добавить товар");
                Console.WriteLine("2. Удалить товар");
                Console.WriteLine("3. Заказать поставку товара");
                Console.WriteLine("4. Продать товар");
                Console.WriteLine("5. Поиск товара");
                Console.WriteLine("6. Показать все товары");
                Console.WriteLine("0. Выход");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddProductMenu();
                }
                else if (choice == "2")
                {
                    DelProductMenu();
                }
                else if (choice == "3")
                {
                    ProductDeliveryMenu();
                }
                else if (choice == "4")
                {
                    SellProductMenu();
                }
                else if (choice == "5")
                {
                    ShowAll();
                }
                else if (choice == "6")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Неверный выбор");
                }
            }
        }

        public static void AddProduct(string name, decimal price, int quantity, Category category)
            {
            Product p = new Product();
            p.Id = nextID;
            nextId ++;
            p.Name = name;
            p.Price = price;
            p.Quanity = quantity;
            p.Category = category;
            products.Add(p);






