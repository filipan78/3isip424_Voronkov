using System;
using System.Collections.Generic;
using System.Linq;

enum Genre
{
    Fiction,
    MysteryThriller,
    FantasySciFi,
    Biography,
    History,
    SelfHelp
}

class Book
{
    public int ID;
    public string Name;
    public string Author;
    public Genre Genre;
    public int Year;
    public double Price;

    public void Print()
    {
        Console.WriteLine("ID: " + ID);
        Console.WriteLine("Название: " + Name);
        Console.WriteLine("Автор: " + Author);
        Console.WriteLine("Жанр: " + GenreToText(Genre));
        Console.WriteLine("Год издания: " + Year);
        Console.WriteLine("Цена: " + Price.ToString("F2") + " руб");
    }

    public static string GenreToText(Genre genre)
    {
        switch (genre)
        {
            case Genre.Fiction: return "Художественная литература";
            case Genre.MysteryThriller: return "Детектив / Триллер";
            case Genre.FantasySciFi: return "Фэнтези / Фантастика";
            case Genre.Biography: return "Биография";
            case Genre.History: return "История";
            case Genre.SelfHelp: return "Саморазвитие";
            default: return genre.ToString();
        }
    }
}

class Program
{
    static List<Book> books = new List<Book>();
    static int nextID = 1;
    static int genresCount = Enum.GetValues(typeof(Genre)).Length;

    static void Main()
    {
        AddBookToList("Мастер и Маргарита", "Михаил Булгаков", Genre.Fiction, 1967, 650.00);
        AddBookToList("Шерлок Холмс", "Артур Конан Дойл", Genre.MysteryThriller, 1892, 850.50);
        AddBookToList("Властелин Колец", "Дж. Р. Р. Толкин", Genre.FantasySciFi, 1954, 1200.00);
        AddBookToList("Стив Джобс", "Уолтер Айзексон", Genre.Biography, 2011, 1500.00);
        AddBookToList("Sapiens. Краткая история человечества", "Юваль Ной Харари", Genre.History, 2011, 1100.00);
        AddBookToList("Мастер и Маргарита (подарочное издание)", "Михаил Булгаков", Genre.Fiction, 2020, 990.00);

        bool work = true;
        while (work)
        {
            Console.WriteLine();
            Console.WriteLine("========== Меню управления библиотекой ==========");
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Удалить книгу по ID");
            Console.WriteLine("3. Поиск книг (по названию, автору, жанру)");
            Console.WriteLine("4. Сортировка книг (по названию или году)");
            Console.WriteLine("5. Показать самую дорогую и самую дешёвую книгу");
            Console.WriteLine("6. Сгруппировать по авторам и вывести количество");
            Console.WriteLine("7. Показать все книги");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch ((choice).Trim())
            {
                case "1": AddBook(); break;
                case "2": DeleteBook(); break;
                case "3": SearchBooks(); break;
                case "4": SortBooks(); break;
                case "5": ShowPriceExtremes(); break;
                case "6": GroupByAuthors(); break;
                case "7": PrintBooks(books); break;
                case "0": work = false; break;
                default:
                    Console.WriteLine("Неверный пункт меню! Введите число от 0 до 7");
                    break;
            }
        }

        Console.WriteLine("Работа программы завершена");
    }
    static void AddBookToList(string name, string author, Genre genre, int year, double price)
    {
        Book book = new Book();
        book.ID = nextID;
        nextID++;
        book.Name = name;
        book.Author = author;
        book.Genre = genre;
        book.Year = year;
        book.Price = price;
        books.Add(book);
    }

    static void PrintBooks(List<Book> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("Книг нет.");
            return;
        }

        foreach (Book book in list)
        {
            book.Print();
        }
        Console.WriteLine("Всего книг: " + list.Count);
    }

    static string ReadNonEmpty(string prompt, string errorText)
    {
        while (true)
        {
            Console.Write(prompt);
            string text = (Console.ReadLine().Trim());
            if (text.Length > 0)
            {
                return text;
            }
            Console.WriteLine(errorText);
        }
    }

    static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            int number;
            if (!int.TryParse((Console.ReadLine().Trim()), out number))
            {
                Console.WriteLine("Ошибка! Чведите целое число");
            }
            else if (number < min || number > max)
            {
                Console.WriteLine("Ошибка! Число должно быть от " + min + " до " + max);
            }
            else
            {
                return number;
            }
        }
    }

    static double ReadPrice()
    {
        while (true)
        {
            Console.Write("Введите цену в руб: ");
            string input = (Console.ReadLine().Trim().Replace(',', '.'));
            double price;
            if (!double.TryParse(input, System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out price))
            {
                Console.WriteLine("Ошибка! Введите число");
            }
            else if (price <= 0 || double.IsInfinity(price) || double.IsNaN(price))
            {
                Console.WriteLine("Ошибка! Цена должна быть больше нуля");
            }
            else
            {
                return price;
            }
        }
    }

    static Genre ReadGenre()
    {
        Console.WriteLine("Выберите жанр");
        for (int i = 0; i < genresCount; i++)
        {
            Console.WriteLine((i + 1) + ". " + Book.GenreToText((Genre)i));
        }
        int number = ReadInt("Номер жанра ", 1, genresCount);
        return (Genre)(number - 1);
    }


    static void AddBook()
    {
        string name = ReadNonEmpty("Введите название книги ", "Название не может быть пустым");
        string author = ReadNonEmpty("Введите автора ", "Автор не может быть пустым");
        Genre genre = ReadGenre();
        int year = ReadInt("Введите год издания (1 - " + DateTime.Now.Year + "): ", 1, DateTime.Now.Year);
        double price = ReadPrice();

        AddBookToList(name, author, genre, year, price);
        Console.WriteLine("Книга добавлена! Присвоен ID " + (nextID - 1));
    }

    static void DeleteBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Список книг пуст, удалять нечего");
            return;
        }

        int id = ReadInt("Введите ID книги для удаления: ", 1, int.MaxValue);

        Book found = books.FirstOrDefault(b => b.ID == id);
        if (found == null)
        {
            Console.WriteLine("Книга с ID " + id + " не найдена!");
            return;
        }

        books.Remove(found);
        Console.WriteLine("Книга \"" + found.Name + "\" удалена!");
    }

    static void SearchBooks()
    {
        Console.WriteLine("Искать по:");
        Console.WriteLine("1. Названию");
        Console.WriteLine("2. Автору");
        Console.WriteLine("3. Жанру");
        int choice = ReadInt("Ваш выбор: ", 1, 3);

        List<Book> result;

        if (choice == 3)
        {
            Genre genre = ReadGenre();
            result = books.Where(b => b.Genre == genre).ToList();
        }
        else
        {
            string text = ReadNonEmpty("Введите запрос: ", "Запрос не может быть пустым").ToLower();

            if (choice == 1)
            {
                result = books.Where(b => b.Name.ToLower().Contains(text)).ToList();
            }
            else
            {
                result = books.Where(b => b.Author.ToLower().Contains(text)).ToList();
            }
        }

        Console.WriteLine();
        Console.WriteLine("Результаты поиска:");
        PrintBooks(result);
    }

    static void SortBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Список книг пуст");
            return;
        }

        Console.WriteLine("Сортировать по:");
        Console.WriteLine("1. Названию (А-Я)");
        Console.WriteLine("2. Году издания (от старых к новым)");
        int choice = ReadInt("Ваш выбор ", 1, 2);

        List<Book> sorted;
        if (choice == 1)
        {
            sorted = books.OrderBy(b => b.Name).ToList();
        }
        else
        {
            sorted = books.OrderBy(b => b.Year).ThenBy(b => b.Name).ToList();
        }

        Console.WriteLine();
        PrintBooks(sorted);
    }

    static void ShowPriceExtremes()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Список книг пуст");
            return;
        }

        double maxPrice = books.Max(b => b.Price);
        double minPrice = books.Min(b => b.Price);

        Book expensive = books.First(b => b.Price == maxPrice);
        Book cheap = books.First(b => b.Price == minPrice);

        Console.WriteLine("Самая дорогая книга");
        expensive.Print();
        Console.WriteLine();
        Console.WriteLine("Самая дешёвая книга");
        cheap.Print();
    }

    static void GroupByAuthors()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Список книг пуст");
            return;
        }

        var groups = books
        .GroupBy(b => b.Author)
        .Select(g => new { Author = g.Key, Count = g.Count() })
        .OrderByDescending(x => x.Count)
        .ThenBy(x => x.Author);

        Console.WriteLine("Количество книг по авторам: ");
        foreach (var g in groups)
        {
            Console.WriteLine(g.Author + " — " + g.Count + " шт");
        }
    }
}