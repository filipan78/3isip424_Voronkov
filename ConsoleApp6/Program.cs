using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

class Program
{
    enum Category
    {
        Electronics,
        Groceries,
        Clothing
    }

    class Product
    {
        public string Code;
        public string Name;
        public decimal Price;
        public int Quantity;
        public Category Category;

        public bool InStock()
        {
            return Quantity > 0;
        }

        public void Print()
        {
            Console.WriteLine("Код: " + Code);
            Console.WriteLine("Название: " + Name);
            Console.WriteLine("Цена: " + Price);
            Console.WriteLine("Количество: " + Quantity);

            string status;
            if (InStock())
            {
                status = "Да";
            }
            else
            {
                status = "Нет";
            }
            Console.WriteLine("В наличии: " + status);
            Console.WriteLine("Категория: " + Category);
        }
    }

    static List <Product>products = new List<Product>();
    static int nextCode = 1;

    static void Main()
    {
        AddTestProduct("Ноутбук", 50000, 5, Category.Electronics);
        AddTestProduct("Хлеб", 45, 20, Category.Groceries);
        AddTestProduct("Футболка", 900, 10, Category.Clothing);
        AddTestProduct("Пылесос", 12000, 0, Category.Electronics);
        AddTestProduct("Молоко", 80, 15, Category.Groceries);

        bool work = true;
        while (work)
        {
            Console.WriteLine();
            Console.WriteLine("Меню");
            Console.WriteLine("1. Добавить товар");
            Console.WriteLine("2. Удалить товар");
            Console.WriteLine("3. Заказать поставку");
            Console.WriteLine("4. Продать товар");
            Console.WriteLine("5. Поиск товара");
            Console.WriteLine("6. Показать все товары");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт: ");

            string choice = Console.ReadLine();

            if (choice == "1") AddProduct();
            else if (choice == "2") DeleteProduct();
            else if (choice == "3") SupplyProduct();
            else if (choice == "4") SellProduct();
            else if (choice == "5") SearchProduct();
            else if (choice == "6") ShowAll();
            else if (choice == "0") work = false;
            else Console.WriteLine("Неверный пункт меню!");
        }
    }
    static void AddTestProduct(string name, decimal price, int quantity, Category category)
    {
        Product p = new Product();
        p.Code = "1" + nextCode;
        nextCode++;
        p.Name = name;
        p.Price = price;
        p.Quantity = quantity;
        p.Category = category;
        products.Add(p);
    }
