using System;
using System.Collections.Generic;
using System.Linq;

class ActivityTracker
{
    static void Main()
    {
        SortedDictionary<int, SortedDictionary<string, double>> dictionary = new SortedDictionary<int, SortedDictionary<string, double>>();
        int count = int.Parse(Console.ReadLine());

        for(int i=1; i<=count; i++)
        {
            string input = Console.ReadLine();
            string[] data = input.Split(' ');
            int month = int.Parse(data[0].Substring(3, 2));
            string name = data[1];
            double distance = double.Parse(data[2]);

            if(dictionary.ContainsKey(month))
            {
                if(dictionary[month].ContainsKey(name))
                {
                    dictionary[month][name] += distance;
                }
                else
                {
                    dictionary[month].Add(name, distance);
                }
            }
            else
            {
                SortedDictionary<string, double> dict = new SortedDictionary<string, double>();
                dict.Add(name, distance);
                dictionary.Add(month, dict);
            }
        }

        foreach(KeyValuePair<int, SortedDictionary<string, double>> keyVal in dictionary)
        {
            List<string> list = new List<string>();

            foreach(KeyValuePair<string, double> kv in keyVal.Value)
            {
                string str = kv.Key.ToString() + "(" + kv.Value.ToString() + ")";
                list.Add(str);
            }

            Console.WriteLine(keyVal.Key + ": " + string.Join(", ", list));
        }
    }
}