using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "../Resources/text.txt";
            string outputPath = "../Output/02/text.txt";

            using(StreamReader reader = new StreamReader(inputPath))
            {
                using(StreamWriter writer = new StreamWriter(outputPath))
                {
                    int lineNumber = 1;
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"Line {lineNumber++}: {line}");
                    }
                }
            }
        }
    }
}
