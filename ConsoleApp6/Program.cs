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

    static List<Product> products = new List<Product>();
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

            if (choice == "1")
            {
                AddProduct();
            }
            else if (choice == "2")
            {
                DeleteProduct();
            }
            else if (choice == "3")
            {
                SupplyProduct();
            }
            else if (choice == "4")
            {
                SellProduct();
            }
            else if (choice == "5")
            {
                SearchProduct();
            }
            else if (choice == "6")
            {
                ShowAll();
            }
            else if (choice == "0")
            {
                work = false;
            }
            else
            {
                Console.WriteLine("Неверный пункт меню!");
            }
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
    static void AddProduct()
    {
        Console.WriteLine("Введите название товара: ");
        string name = Console.ReadLine();
        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Название не может быть пустым, введите еще раз: ");
            name = Console.ReadLine();
        }
        decimal price = -1;
        while (price < 0)
        {
            Console.WriteLine("Введите количество товаров: ");
            string input2 = Console.ReadLine();
            if (!decimal.TryParse(input2, out price) || price < 0)
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз: ");
                input2 = Console.ReadLine();
                price = -1;
            }
        }
        int quantity = -1;
        while (quantity < 0)
        {
            Console.WriteLine("Введите количество товаров: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out quantity) || quantity < 0)
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз: ");
                input = Console.ReadLine();
                quantity = -1;
            }
        }

        Console.WriteLine("Выберете категорию:");
        Console.WriteLine("1. Электроника");
        Console.WriteLine("2. Продукты");
        Console.WriteLine("3. Одежда");
        bool categoryOK = false;
        Category category = Category.Groceries;
        while (!categoryOK)
        {
            string input3 = Console.ReadLine();
            if (input3 == "1")
            {
                category = Category.Electronics;
                categoryOK = true;
            }
            else if (input3 == "2")
            {
                category = Category.Groceries;
                categoryOK = true;
            }
            else if (input3 == "3")
            {
                category = Category.Clothing;
                categoryOK = true;
            }
            else
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз: ");
            }
        }
        Product product = new Product();
        product.Code = "1" + nextCode;
        nextCode++;
        product.Name = name;
        product.Price = price;
        product.Quantity = quantity;
        product.Category = category;

        products.Add(product);
        Console.WriteLine("Продукт добавлен!");
    }
    static void DeleteProduct()
    {
        Console.Write("Введите код товара для удаления: ");
        string code = Console.ReadLine();

        Product found = FindByCode(code);
        if (found == null)
        {
            Console.WriteLine("Товар не найден!");
            return;
        }

        products.Remove(found);
        Console.WriteLine("Товар удалён!");
    }

 
    static void SupplyProduct()
    {
        Console.Write("Введите код товара: ");
        string code = Console.ReadLine();

        Product found = FindByCode(code);
        if (found == null)
        {
            Console.WriteLine("Товар не найден!");
            return;
        }

        int amount = -1;
        while (amount <= 0)
        {
            Console.Write("Введите количество для поставки: ");
            string input4 = Console.ReadLine();
            if (!int.TryParse(input4, out amount) || amount <= 0)
            {
                Console.WriteLine("Введите положительное целое число!");
                amount = -1;
            }
        }
        found.Quantity = found.Quantity + amount;
        Console.WriteLine("Поставка добавлена! Новое количество: " + found.Quantity);
    }

    static void SellProduct()
    {
        Console.Write("Введите код товара: ");
        string code = Console.ReadLine();

        Product found = FindByCode(code);
        if (found == null)
        {
            Console.WriteLine("Товар не найден!");
            return;
        }

        if (!found.InStock())
        {
            Console.WriteLine("Товара нет на складе!");
            return;
        }
        int amount = -1;
        while (amount <= 0)
        {
            Console.Write("Введите количество для продажи: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out amount) || amount <= 0)
            {
                Console.WriteLine("Введите положительное целое число");
                amount = -1;
            }
        }

        if (amount > found.Quantity)
        {
            Console.WriteLine("Недостаточно товара на складе, есть только: " + found.Quantity);
            return;
        }

        found.Quantity = found.Quantity - amount;
        Console.WriteLine("Продано, остаток: " + found.Quantity);
    }


