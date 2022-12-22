using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Kurkov_o\\Downloads\\Text1.txt";/// путь к файлу
            string readText = File.ReadAllText(filePath);
            string noPunctuationText = new string(readText.Where(c => !char.IsPunctuation(c)).ToArray());
            Dictionary<string, int> dictioonary = new Dictionary<string, int>();
            foreach (string line in noPunctuationText.Split(new char[] { '\n', '\r', ' ' }))
            {
                if (!String.IsNullOrEmpty(line))
                {
                    if (!dictioonary.ContainsKey(line))
                    {
                        dictioonary.Add(line, 1);
                    }
                    else
                    {
                        int oldCount = dictioonary[line];
                        dictioonary[line] = oldCount + 1;
                    }
                }
            }
            // Сортированный список
            List<int> LintCounts = dictioonary.Values.ToList();
            LintCounts.Sort();
            LintCounts.Reverse();
            // Количество слов
            List<string> SortedCountWords = new List<string>();
            foreach (string word in dictioonary.Keys)
            {
                int count = dictioonary[word];
                for (int i = 0; i < 10; i++)
                {
                    int listCount = LintCounts[i];
                    if (count == listCount)
                    {
                        SortedCountWords.Add(word);
                    }
                }
            }
            Console.WriteLine("10 слов, которые чаще всего встречаются в тексте - " + String.Join(",", SortedCountWords));
            Console.ReadKey();
        }
    }
}