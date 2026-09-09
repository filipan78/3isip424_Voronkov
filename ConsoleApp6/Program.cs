using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            while (true)
            {
                Console.Write("Введите количество операций от 2 до 40: ");
                n = Convert.ToInt32(Console.ReadLine());

                if (n >= 2 && n <= 40)
                    break;

                Console.WriteLine("Нет парень ты вышел за лимит");
            }
            string[] names = new string[n];
                double[] prices = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите название товара или услуги: ");
                names[i] = Console.ReadLine();

                Console.Write("Введите сумму: ");
                prices[i] = Convert.ToDouble(Console.ReadLine());
            }
            while (true)
                {
                    Console.WriteLine("Менюшка");
                    Console.WriteLine("1. Вывод данных");
                    Console.WriteLine("2. Статистика");
                    Console.WriteLine("3. Сортировка по цене");
                    Console.WriteLine("4. Конвертация валюты");
                    Console.WriteLine("5. Поиск по названию");
                    Console.WriteLine("0. Выход");
                    Console.WriteLine("Выберите пункт");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    if (menu == 0)
                    {
                        break;
                    }
                    if (menu == 1)
                    {
                        for (int i = 0; i < n; ++i)
                        {
                            Console.WriteLine(names[i] + " - " + prices[i] + "руб.");
                        }
                    }
                    if (menu == 2)
                    {
                        double sum = 0;
                        double max = prices[0];
                        double min = prices[0];
                        for (int i = 0; i < n; ++i)
                        {
                            sum += prices[i];

                            if (prices[i] > max)
                                max = prices[i];
                            if (prices[i] < min)
                                min = prices[i];
                        }
                        Console.WriteLine("Статистика: Среднее " + sum / n + "руб.");
                        Console.WriteLine("Макс: " + max + "руб.");
                        Console.WriteLine("Мин: " + min + "руб.");
                        Console.WriteLine("Сумма: " + sum + "руб.");
                    }
                    if (menu == 3)
                    {
                        for (int i = 0; i < n - 1; i++)
                        {
                            for (int j = 0; j < n - i - 1; j++)
                            {
                                if (prices[j] > prices[j + 1])
                                {
                                    double tempPrice = prices[j];
                                    prices[j] = prices[j + 1];
                                    prices[j + 1] = tempPrice;

                                }
                            }
                        }
                        Console.WriteLine("Сортировка по цене:");
                        for (int i = 0; i < n; ++i)
                        {
                            Console.WriteLine(names[i] + " - " + prices[i] + "руб.");
                        }
                    }
                    if (menu == 4)
                    {
                        Console.WriteLine("Выберите валюту: 1. Доллар, 2. Евро");
                        int valuta = Convert.ToInt32(Console.ReadLine());
                        double currencyExchangeRate = 0;
                        if (valuta == 1)
                        {
                            currencyExchangeRate = 86;
                        }
                        if (valuta == 2)
                        {
                            currencyExchangeRate = 100;
                        }
                        if (currencyExchangeRate > 0)
                        {
                            Console.WriteLine("Конвертация: ");
                            for (int i = 0; i < n; i++)
                            {
                                Console.WriteLine(names[i] + " - " + prices[i] / currencyExchangeRate);
                            }
                        }
                    if (menu == 5)
                    {
                        Console.Write("Введите слово для поиска: ");
                            string search = Console.ReadLine();

                            bool found = false;

                            for (int i = 0; i < n; i++)
                            {
                                if (names[i].ToLower().Contains(search.ToLower()))
                                {
                                    Console.WriteLine(names[i] + " - " + prices[i] + " руб.");
                                    found = true;
                                }
                            }

                            if (found == false)
                                Console.WriteLine("Ничего не найдено");
                        }
                    }
                }
            }
        }
    }
