using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .OrderBy(n => n)
            .ToList();

        for(int i = 0; i < list.Count; i++)
        {
            int current = list[i];
            int count = 1;
            for(int j = i + 1; j < list.Count; j++)
            {
                if(list[j] != current)
                {
                    break;
                }

                count++;
            }

            Console.WriteLine($"{current} -> {count} times");

            i += count - 1;
        }
    }
}
