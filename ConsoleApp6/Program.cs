using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Xml.Linq;


    enum Genre
    {
        Fiction,          
        MysteryThriller,  
        FantasySciFi,    
        Biography,        
        History,          
        SelfHelp
    }

    class Product
    {
        public int ID;
        public string Name;
        public string Author;
        public Genre Genre;
        public string Izdanie;
        public double Price;

        
    }
    class Program
    {
        static List<Product> products = new List<Product>();
        static int nextID = 1;

    static void Main()
    {
        AddTestProduct("Мастер и Маргарита", "Михаил Булгаков", Genre.Fiction, "Эксмо", 650.00);
        AddTestProduct("Шерлок Холмс", "Артур Конан Дойл", Genre.MysteryThriller, "АСТ", 850.50);
        AddTestProduct("Властелин Колец", "Дж. Р. Р. Толкин", Genre.FantasySciFi, "Азбука", 1200.00);
        AddTestProduct("Стив Джобс", "Уолтер Айзексон", Genre.Biography, "Corpus", 1500.00);
        AddTestProduct("Sapiens. Краткая история человечества", "Юваль Ной Харари", Genre.History, "Синдбад", 1100.00);


        bool work = true;
        while (work)
        {
            Console.WriteLine();
            Console.WriteLine("Меню управления библиотекой");
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Удалить книгу");
            Console.WriteLine("3. Поиск книг (по названию, автору, жанру)");
            Console.WriteLine("4. Сортировка книг (по названию или году)");
            Console.WriteLine("5. Показать самую дорогую и дешёвую книгу");
            Console.WriteLine("6. Сгруппировать по авторам и вывести количество");
            Console.WriteLine("7. Показать все книги");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    DeleteBook();
                    break;
                case "3":
                    SearchBook();
                    break;
                case "4":
                    SortBooks();
                    break;
                case "5":
                    ShowPriceExtremes();
                    break;
                case "6":
                    GroupByAuthors();
                    break;
                case "7":
                    ShowAllBooks();
                    break;
                case "0":
                    work = false;
                    break;
                default:
                    Console.WriteLine("Неверный пункт меню!");
                    break;
            }

        }
    }
    static void AddTestProduct(string name, string author, Genre genre, string izdanie, double price)
    {
        Product book = new Product();
        book.ID = "1" + nextID;
        nextID++;
        book.Name = name;
        book.Author = author;
        book.Genre = genre;
        book.Price = price;
        book.Izdanie = izdanie;
        products.Add(p);
    }
    static void AddBook()
    {
        Console.WriteLine("Введите название книги: ");
        string name = Console.ReadLine();
        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Название не может быть пустым, введите еще раз: ");
            name = Console.ReadLine();
        }
        decimal price = -1;
        while (price < 0)
        {
            Console.WriteLine("Введите цену: ");
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

        Console.WriteLine("Выберите категорию:");
        Console.WriteLine("1. Fiction");
        Console.WriteLine("2. Mystery & Thriller");
        Console.WriteLine("3. Fantasy & Sci-Fi");
        Console.WriteLine("4. Biography");
        Console.WriteLine("5. History");
        Console.WriteLine("6. Self-Help");

        bool categoryOK = false;

        while (!categoryOK)
        {
            string input3 = Console.ReadLine();

            switch (input3)
            {
                case "1":
                    genre = Genre.Fiction;
                    categoryOK = true;
                    break;
                case "2":
                    category = Genre.MysteryThriller;
                    categoryOK = true;
                    break;
                case "3":
                    category = Genre.FantasySciFi;
                    categoryOK = true;
                    break;
                case "4":
                    category = Genre.Biography;
                    categoryOK = true;
                    break;
                case "5":
                    category = Genre.History;
                    categoryOK = true;
                    break;
                case "6":
                    category = Genre.SelfHelp;
                    categoryOK = true;
                    break;
                default:
                    Console.WriteLine("Неверный ввод, попробуйте еще раз: ");
                    break;
            }
        }
    }
        Product product = new Product();
        product.Code = "1" + nextID;
        nextID++;
        product.Name = name;
        product.Price = price;
        product.Quantity = quantity;
        product.Category = category;

        products.Add(product);
        Console.WriteLine("Продукт добавлен!");
    }
    static void DeleteBook();
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

    static void SearchProduct()
    {
        Console.WriteLine("Искать по: 1 - коду, 2 - названию, 3 - категории");
        string choice = Console.ReadLine();

        bool foundAny = false;

        if (choice == "1")
        {
            Console.Write("Введите код: ");
            string code = Console.ReadLine();
            Product found = FindByCode(code);
            if (found != null)
            {
                found.Print();
                foundAny = true;
            }
        }
        else if (choice == "2")
        {
            Console.Write("Введите название: ");
            string name = Console.ReadLine();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name.ToLower().Contains(name.ToLower()))
                {
                    products[i].Print();
                    Console.WriteLine("------------------");
                    foundAny = true;
                }
            }
        }
        else if (choice == "3")
        {
            
            Console.WriteLine("Введите номер категории: ");
            Console.WriteLine("1. Электроника");
            Console.WriteLine("2. Продукты");
            Console.WriteLine("3. Одежда");
            string catInput = Console.ReadLine();
            Category category = Category.Electronics;
            if (catInput == "1")
            {
                category = Category.Electronics;
            }
            else if (catInput == "2")
            {
                category = Category.Groceries;
            }
            else if (catInput == "3")
            {
                category = Category.Clothing;
            }
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Category == category)
                {
                    products[i].Print();
                    Console.WriteLine("------------------");
                    foundAny = true;
                }
            }
        }
        else
        {
            Console.WriteLine("Неверный выбор!");
            return;
        }

        if (!foundAny)
        {
            Console.WriteLine("Товары не найдены.");
        }
    }
    static void ShowAll()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("Список товаров пуст.");
            return;
        }

        for (int i = 0; i < products.Count; i++)
        {
            products[i].Print();
            Console.WriteLine("------------------");
        }
    }

    static Product FindByCode(string code)
    {
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].Code == code)
            {
                return products[i];
            }
        }
        return null;
    }
}
public void Print()
{
    Console.WriteLine("Код: " + ID);
    Console.WriteLine("Название: " + Name);
    Console.WriteLine("Автор: " + Author);
    Console.WriteLine("Жанр: " + Genre);
    Console.WriteLine("Цена: " + Price);


}
