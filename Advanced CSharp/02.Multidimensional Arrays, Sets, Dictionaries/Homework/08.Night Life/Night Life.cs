using System;
using System.Collections.Generic;

class NightLife
{
    static void Main()
    {
        Dictionary<string, SortedDictionary<string, SortedSet<string>>> main = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();

        string input = Console.ReadLine();

        while(input != "END")
        {
            string[] data = input.Split(';');
            if (main.ContainsKey(data[0]))
            {
                if (main[data[0]].ContainsKey(data[1]))
                {
                    main[data[0]][data[1]].Add(data[2]);
                }
                else
                {
                    
                    SortedDictionary<string, SortedSet<string>> sortedDictionary = new SortedDictionary<string, SortedSet<string>>();
                    SortedSet<string> sortedSet = new SortedSet<string>();
                    sortedSet.Add(data[2]);
                    sortedDictionary.Add(data[1], sortedSet);
                    main[data[0]].Add(data[1], sortedSet);
                }
            }
            else
            {
                SortedSet<string> sortedSet = new SortedSet<string>();
                sortedSet.Add(data[2]);
                SortedDictionary<string, SortedSet<string>> sortedDictionary = new SortedDictionary<string, SortedSet<string>>();
                sortedDictionary.Add(data[1], sortedSet);
                main.Add(data[0], sortedDictionary);
            }

            input = Console.ReadLine();
        }

        Console.WriteLine();

        foreach(string city in main.Keys)
        {
            Console.WriteLine(city);
            
            foreach(string venue in main[city].Keys)
            {
                Console.WriteLine("->{0}: {1}", venue, String.Join(", ", main[city][venue]));
            }
        }
    }
}