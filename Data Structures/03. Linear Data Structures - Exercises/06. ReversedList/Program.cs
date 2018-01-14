using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var list = new ReversedList<int>();

        for(int i=1; i<=10; i++)
        {
            list.Add(i);
        }

        Console.WriteLine(list[2]);
        list.RemoveAt(2);
        Console.WriteLine(list[2]);

        foreach(var el in list)
        {
            Console.WriteLine(el);
        }
    }
}