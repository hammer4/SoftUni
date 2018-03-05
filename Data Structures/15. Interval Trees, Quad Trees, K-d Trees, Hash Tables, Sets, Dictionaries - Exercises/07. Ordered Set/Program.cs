using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var set = new OrderedSet<int>();
        set.Add(17);
        set.Add(9);
        set.Add(12);
        set.Add(19);
        set.Add(6);
        set.Add(25);
        Console.WriteLine(set.Count);
        set.Remove(12);
        Console.WriteLine(set.Contains(9));
        Console.WriteLine(set.Contains(8));
        Console.WriteLine(set.Count);
        foreach (var item in set)
        {
            Console.WriteLine(item);
        }
    }
}
