using System;
using System.Collections.Generic;

class TextStatistics
{
    public int WordCount;
    public string Shortest;
    public string Longest;
    public int SentenceCount;
    public int VowelCount;
    public int ConsonantCount;
}

class Program
{
    static void Main(string[] args)
    {
        List<TextStatistics> history = new List<TextStatistics>();
        bool continueWork = true;

        while (continueWork)
        {
            string text;
            List<string> words;

            while (true)
            {
                Console.WriteLine("Введите текст (минимум 100 символов):");
                text = Console.ReadLine();

                if (text == null) continue;

                if (text.Length >= 100)
                {
                    words = GetWords(text);
                    if (words.Count > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Текст должен содержать хотя бы одно слово.");
                    }
                }
                else
                {
                    Console.WriteLine("Текст слишком короткий");
                }
            }

            Console.WriteLine("Текст принят!");

            TextStatistics stats = new TextStatistics();
            stats.WordCount = words.Count;
            stats.Shortest = words[0];
            stats.Longest = words[0];

            for (int i = 1; i < words.Count; i++)
            {
                if (words[i].Length < stats.Shortest.Length)
                {
                    stats.Shortest = words[i];
                }
                if (words[i].Length > stats.Longest.Length)
                {
                    stats.Longest = words[i];
                }
            }

            int sentenceCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '.' || c == '!' || c == '?')
                {
                    sentenceCount++;
                }
            }
            stats.SentenceCount = sentenceCount;

            char[] vowels = { 'а', 'о', 'у', 'ы', 'э', 'я', 'ю', 'и', 'е', 'ё', 'a', 'e', 'i', 'o', 'u', 'y' };
            int vowelCount = 0;
            int consonantCount = 0;
            List<char> letters = new List<char>();
            List<int> counts = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                char c = char.ToLower(text[i]);
                if (char.IsLetter(c))
                {
                    bool isVowel = false;
                    for (int j = 0; j < vowels.Length; j++)
                    {
                        if (c == vowels[j])
                        {
                            isVowel = true;
                            break;
                        }
                    }

                    if (isVowel)
                    {
                        vowelCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }

                    int foundIndex = -1;
                    for (int k = 0; k < letters.Count; k++)
                    {
                        if (letters[k] == c)
                        {
                            foundIndex = k;
                            break;
                        }
                    }

                    if (foundIndex == -1)
                    {
                        letters.Add(c);
                        counts.Add(1);
                    }
                    else
                    {
                        counts[foundIndex]++;
                    }
                }
            }

            stats.VowelCount = vowelCount;
            stats.ConsonantCount = consonantCount;

            Console.WriteLine("Количество слов: " + stats.WordCount);
            Console.WriteLine("Самое короткое слово: " + stats.Shortest);
            Console.WriteLine("Самое длинное слово: " + stats.Longest);
            Console.WriteLine("Количество предложений: " + stats.SentenceCount);
            Console.WriteLine("Гласных букв: " + stats.VowelCount);
            Console.WriteLine("Согласных букв: " + stats.ConsonantCount);
            Console.WriteLine("Частота букв:");
            for (int i = 0; i < letters.Count; i++)
            {
                Console.WriteLine(letters[i] + " - " + counts[i]);
            }

            history.Add(stats);

            Console.WriteLine("Хотите проанализировать ещё один текст? (да/нет)");
            string answer = Console.ReadLine()?.ToLower();
            if (answer != "да")
            {
                continueWork = false;
            }
        }

        Console.WriteLine("Работа завершена.");
        Console.WriteLine("Показать статистику по всем прошлым текстам? (да/нет)");
        string showHistory = Console.ReadLine()?.ToLower();
        if (showHistory == "да")
        {
            for (int i = 0; i < history.Count; i++)
            {
                TextStatistics s = history[i];
                Console.WriteLine("Текст номер " + (i + 1) + " ");
                Console.WriteLine("Количество слов: " + s.WordCount);
                Console.WriteLine("Самое короткое слово: " + s.Shortest);
                Console.WriteLine("Самое длинное слово: " + s.Longest);
                Console.WriteLine("Количество предложений: " + s.SentenceCount);
                Console.WriteLine("Гласных: " + s.VowelCount);
                Console.WriteLine("Согласных: " + s.ConsonantCount);
            }
        }
    }

    static List<string> GetWords(string text)
    {
        char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '\n', '\r', '\t' };
        string[] rawParts = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        return new List<string>(rawParts);
    }
}