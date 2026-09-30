using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> historyWords = new List<int>();
            List<string> historyShortest = new List<string>();
            List<int> historyCountSentences = new List<int>();
            List<int> historyCountVowels = new List<int>();
            List<int> historyCountConsonantst = new List<int>();
            List<string> historyLongest = new List<string>();

            bool continueWork = true;

            while (continueWork)
            {
                string text;

                while (true)
                {
                    Console.WriteLine("Введите текст минимум 100 символов");
                    text = Console.ReadLine();

                    if (text.Length >= 100) 
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Текст слишком котороткий");
                    }
                }
                List<string> words = GetWords(text);

                int wordCount = words.Count;
                
                string shortest = words[0];
                string longest = words[0];

                for (int i = 1; i < wordCount; i++)
                {
                    if (words[i].Length == shortest.Length)
                    {
                        shortest = words[i];
                    }
                    if (words[i].Length == longest.Length)
                    {
                        longest = words[i];
                    }
                }
                int sentenceCount = 0;

                for (int i = 0; i < wordCount; i++)
                {
                    char c = text[i];

                    if (c == '!' || c == '?' || c == '.')
                    {
                        sentenceCount++;
                    }
                }
                char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };

                int vowelsCount = 0;
                int consonantCount = 0;

                List<char> letters = new List<char>();
                List<int> count = new List<int>();

                for (int i = 0; i < wordCount;i++) {
                    char c = char.ToLower(text[i]);

                    if (char.IsLetter(c))
                    {
                        bool isVowel = false;

                        for (int j = 0; j < vowels.Length; j++)
                        {
                            if (c == vowels[j])
                            {
                                isVowel = true;
                            }
                        }
                        if (isVowel)
                        {
                            vowelsCount++;
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
                Console.WriteLine("Частота букв:");
                for (int i = 0; i < letters.Count; i++)
                {
                    Console.WriteLine(letters[i] + " - " + counts[i]);
                }
                Console.WriteLine("Количество слов: " + wordCount);
                Console.WriteLine("Самое короткое слово: " + shortest);
                Console.WriteLine("Самое длинное слово: " + longest);
                Console.WriteLine("Количество предложений: " + sentenceCount);
                Console.WriteLine("Гласных букв: " + vowelCount);
                Console.WriteLine("Согласных букв: " + consonantCount);
                historyWordCount.Add(wordCount);
                historyShortest.Add(shortest);
                historyLongest.Add(longest);
                historySentenceCount.Add(sentenceCount);
                historyVowelCount.Add(vowelCount);
                historyConsonantCount.Add(consonantCount);





            }

        }
    }
}
