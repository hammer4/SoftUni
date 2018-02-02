using System;
using System.IO;

namespace _01._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineNumber = 0;
            using(StreamReader reader = new StreamReader("../Resources/text.txt"))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    if(lineNumber % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }

                    lineNumber++;
                }
            }
        }
    }
}
