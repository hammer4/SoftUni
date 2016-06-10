using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Population_Aggregation
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> countries = new Dictionary<string, int>();
            Dictionary<string, long> cities = new Dictionary<string, long>();
            string[] prohibbitedSymbols = new string[] { "@", "#", "$", "&", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            string command = Console.ReadLine();

            while(command != "stop")
            {
                string[] tokens = command.Split('\\');
                for(int i=0; i<prohibbitedSymbols.Length; i++)
                {
                    tokens[0] = tokens[0].Replace(prohibbitedSymbols[i], "");
                    tokens[1] = tokens[1].Replace(prohibbitedSymbols[i], "");
                }

                string country = "";
                string city = "";
                long population = long.Parse(tokens[2]);

                if (char.IsUpper(tokens[0][0]))
                {
                    country = tokens[0];
                    city = tokens[1];
                }
                else
                {
                    country = tokens[1];
                    city = tokens[0];
                }

                if(countries.ContainsKey(country))
                {
                    countries[country]++;
                }
                else if(!countries.ContainsKey(country))
                {
                    countries[country] = 1;
                }

                cities[city] = population;

                command = Console.ReadLine();
            }

            foreach(var pair in countries.OrderBy(c => c.Key))
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }

            foreach(var pair in cities.OrderByDescending(c => c.Value).Take(3))
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
