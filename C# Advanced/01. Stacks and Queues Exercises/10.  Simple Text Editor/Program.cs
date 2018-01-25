using System;
using System.Collections.Generic;

namespace _10.__Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Stack<string> texts = new Stack<string>();
            texts.Push("");

            for(int i=0; i<count; i++)
            {
                var input = Console.ReadLine().Split();

                switch (input[0])
                {
                    case "1":
                        string newText = texts.Peek() + input[1];
                        texts.Push(newText);
                        break;
                    case "2":
                        string previous = texts.Peek();
                        int charsToCut = int.Parse(input[1]);
                        string substring = previous.Substring(0, previous.Length - charsToCut);
                        texts.Push(substring);
                        break;
                    case "3":
                        string current = texts.Peek();
                        int index = int.Parse(input[1]);
                        Console.WriteLine(current[index - 1]);
                        break;
                    case "4":
                        texts.Pop();
                        break;
                }
            }
        }
    }
}
