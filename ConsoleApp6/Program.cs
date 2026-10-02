using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

    class Book
    {
        public int ID;
        public string Name;
        public string Author;
        public Genre Genre;
        public string Izdanie;
        public double Price;

        
    }
partial class Program
    {

    public static List<Book> books = new List<Book>();
    public static int nextID = 1;
    public static int genresCount = Enum.GetValues(typeof(Genre)).Length;
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
        Book book = new Book();
        book.ID = 1 + nextID;
        nextID++;
        book.Name = name;
        book.Author = author;
        book.Genre = genre;
        book.Price = price;
        book.Izdanie = izdanie;
        books.Add(book);
    }

    static void PrintBooks(List<Book> list) {
        if (list.Count == 0)
        {
            Console.WriteLine("Книг нет");
            return;
        }
    foreach (Book book in list) {
            Console.WriteLine("ID: " + book.ID);
            Console.WriteLine("Название: " + book.Name);
            Console.WriteLine("Автор: " + book.Author);
            Console.WriteLine("Жанр: " + book.Genre);
            Console.WriteLine("Год издания: " + book.Izdanie);
            Console.WriteLine("Цена: " + book.Price + " руб.");
        }
        Console.WriteLine("Всего книг: " + list.Count);

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
        Console.WriteLine("Введите название автора: ");
        string author = Console.ReadLine();
        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Автор не может быть пустым, введите еще раз: ");
            name = Console.ReadLine();
        }


        Console.WriteLine("Выберите категорию:");
        Console.WriteLine("1. Fiction");
        Console.WriteLine("2. Mystery & Thriller");
        Console.WriteLine("3. Fantasy & Sci-Fi");
        Console.WriteLine("4. Biography");
        Console.WriteLine("5. History");
        Console.WriteLine("6. Self-Help");

        bool genreOK = false;
        Genre genre = Genre.Fiction;
        while (!genreOK)
        {
            string input3 = Console.ReadLine();

            switch (input3)
            {
                case "1":
                    genre = Genre.Fiction;
                    genreOK = true;
                    break;
                case "2":
                    genre = Genre.MysteryThriller;
                    genreOK = true;
                    break;
                case "3":
                    genre = Genre.FantasySciFi;
                    genreOK = true;
                    break;
                case "4":
                    genre = Genre.Biography;
                    genreOK = true;
                    break;
                case "5":
                    genre = Genre.History;
                    genreOK = true;
                    break;
                case "6":
                    genre = Genre.SelfHelp;
                    genreOK = true;
                    break;
                default:
                    Console.WriteLine("Неверный ввод, попробуйте еще раз: ");
                    break;
            }
        }
        Console.WriteLine("Введите издание книги: ");
        string izdanie = Console.ReadLine();
        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Название не может быть пустым, введите еще раз: ");
            izdanie = Console.ReadLine();
        }
        double price = -1;
        while (price < 0)
        {
            Console.WriteLine("Введите цену: ");
            string input2 = Console.ReadLine();
            if (!double.TryParse(input2, out price) || price < 0)
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз: ");
                input2 = Console.ReadLine();
                price = -1;
            }

            AddTestProduct(name.Trim(), author.Trim(), genre, izdanie, price);
            Console.WriteLine("Книга добавлена!");
        }
    }
    static Genre ReadGenre()
    {
        Console.WriteLine("Выберите жанр:");
        for (int i = 0; i < genresCount; i++)
        {
            Console.WriteLine((i + 1) + ". " + (Genre)i);
        }

        while (true)
        {
            Console.Write("Номер жанра: ");
            int number;
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка: введите число.");
            }
            else if (number < 1 || number > genresCount)
            {
                Console.WriteLine("Ошибка: номер от 1 до " + genresCount + ".");
            }
            else
            {
                return (Genre)(number - 1);
            }
        }
    }
    static void SearchBooks()
    {
        Console.WriteLine("Искать по:");
        Console.WriteLine("1. Названию");
        Console.WriteLine("2. Автору");
        Console.WriteLine("3. Жанру");

        int choice;
        while (true)
        {
            Console.Write("Ваш выбор: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Ошибка: введите число.");
            }
            else if (choice < 1 || choice > 3)
            {
                Console.WriteLine("Ошибка: выберите число от 1 до 3.");
            }
            else
            {
                break;
            }
        }
        if (choice == 3)
        {
            Genre genre = ReadGenre();
            PrintBooks(books.Where(b => b.Genre == genre).ToList());
            return;
        }
        Console.Write("Введите запрос: ");
        string text = Console.ReadLine().Trim().ToLower();
        if (text == "")
        {
            Console.WriteLine("Ошибка: запрос не может быть пустым.");
            return;
        }

        if (choice == 1)
        {
            PrintBooks(books.Where(b => b.Name.ToLower().Contains(text)).ToList());
        }
        else
        {
            PrintBooks(books.Where(b => b.Author.ToLower().Contains(text)).ToList());
        }
    }

    

   
    static void ShowAll()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Список книгаов пуст.");
            return;
        }

        for (int i = 0; i < books.Count; i++)
        {
            books[i].Print();
            Console.WriteLine("------------------");
        }
    }

    static Product FindByCode(string code)
    {
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Code == code)
            {
                return books[i];
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
static void DeleteBook();
{
    Console.Write("Введите код книги для удаления: ");
    string code = Console.ReadLine();

    Product found = FindByCode(code);
    if (found == null)
    {
        Console.WriteLine("книга не найден!");
        return;
    }

    books.Remove(found);
    Console.WriteLine("книга удалена!");
}
