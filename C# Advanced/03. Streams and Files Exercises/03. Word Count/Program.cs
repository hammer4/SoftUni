using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            List<string> words = new List<string>();
            string wordsPath = "../Resources/words.txt";
            string textPath = "../Resources/text.txt";
            string resultsPath = "../Output/03/result.txt";

            using(StreamReader readerWords = new StreamReader(wordsPath))
            {
                string word;

                while((word = readerWords.ReadLine()) != null)
                {
                    wordCount.Add(word, 0);
                    words.Add(word);
                }
            }

            using(StreamReader readerText = new StreamReader(textPath))
            {
                string line;

                while((line = readerText.ReadLine()) != null)
                {
                    foreach(string word in words)
                    {
                        string pattern = $"(?<=[^a-zA-Z]){word}(?=[^a-zA-Z])";
                        int count = Regex.Matches(line, pattern, RegexOptions.IgnoreCase).Count;
                        wordCount[word] += count;
                    }
                }
            }

            using(StreamWriter writer = new StreamWriter(resultsPath))
            {
                foreach(var word in wordCount.Keys.OrderByDescending(x => wordCount[x]))
                {
                    writer.WriteLine($"{word} - {wordCount[word]}");
                }
            }
        }
    }
}
