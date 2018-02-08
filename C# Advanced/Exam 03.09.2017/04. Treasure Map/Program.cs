using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _04._Treasure_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string mainPattern = @"#[^#!]{12,}!|![^#!]{12,}#";
            string namePattern = @"[^0-9a-zA-Z]+([a-zA-Z]{4})[^0-9a-zA-Z]+";
            string numberPattern = @"[^0-9]([0-9]{3})-([0-9]{6}|[0-9]{4})[^0-9]";

            for (int i=0; i<count; i++)
            {
                string input = Console.ReadLine();

                Regex regex1 = new Regex(mainPattern);

                var matches = regex1.Matches(input);
                
                if(matches.Count > 0)
                {
                    List<int> validIndices = new List<int>();

                    for(int j=0; j<matches.Count; j++)
                    {
                        var nameMatches = Regex.Matches(matches[j].ToString(), namePattern);
                        var numbersMatches = Regex.Matches(matches[j].ToString(), numberPattern);

                        if(nameMatches.Count > 0 && numbersMatches.Count > 0)
                        {
                            validIndices.Add(j);
                        }
                    }

                    if(validIndices.Count > 0)
                    {
                        string current = matches[validIndices[validIndices.Count / 2]].ToString();

                        string streetName = Regex.Matches(current, namePattern)[0].Groups[1].ToString();
                        var numberMatches = Regex.Matches(current, numberPattern);

                        string streetNumber = numberMatches[numberMatches.Count - 1].Groups[1].ToString();
                        string pass = numberMatches[numberMatches.Count - 1].Groups[2].ToString();

                        Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {pass}.");
                    }
                }
            }
        }
    }
}
