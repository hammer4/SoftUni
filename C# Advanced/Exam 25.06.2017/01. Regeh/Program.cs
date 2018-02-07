using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> indices = new List<int>();

            string pattern = @"\[[^[<]+<([0-9]+)REGEH([0-9]+)>[^\]]+]";

            var matches = Regex.Matches(input, pattern);

            for (int i = 0; i < matches.Count; i++)
            {
                 indices.Add(int.Parse(matches[i].Groups[1].Value));
                 indices.Add(int.Parse(matches[i].Groups[2].Value));
            }

            int count = 0;
            foreach(var index in indices)
            {
                count += index;
                Console.Write(input[count / input.Length + count % input.Length]);
            }
        }
    }
}
