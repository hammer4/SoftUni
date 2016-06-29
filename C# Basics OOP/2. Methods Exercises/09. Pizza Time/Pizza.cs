using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Pizza_Time
{
    public class Pizza
    {
        public string name;
        public int group;

        public static SortedDictionary<int, List<string>> Pizzas(params string[] arr)
        {
            SortedDictionary<int, List<string>> dictionary = new SortedDictionary<int, List<string>>();
            foreach(string pizza in arr)
            {
                int counter = 0;
                int index = 0;
                char ch = pizza[index];
                while(char.IsDigit(ch))
                {
                    counter++;
                    index++;
                    ch = pizza[index];
                }

                int group = int.Parse(pizza.Substring(0, counter));
                string name = pizza.Substring(counter);

                if(dictionary.ContainsKey(group))
                {
                    dictionary[group].Add(name);
                }
                else
                {
                    dictionary[group] = new List<string>();
                    dictionary[group].Add(name);
                }
            }

            return dictionary;
        }
    }
}
