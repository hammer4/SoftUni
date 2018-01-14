using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var list = Console.ReadLine().Split().Select(int.Parse).ToList();
        
        for(int i = 0; i < list.Count; i++)
        {
            int current = list[i];

            int count = 0;

            for(int j = 0; j<list.Count; j++)
            {
                if(list[j] == current)
                {
                    count++;
                }
            }

            if(count % 2 == 1)
            {
                list.RemoveAll(n => n == current);
                i--;
            }
        }

        Console.WriteLine(String.Join(" ", list));
    }
}
