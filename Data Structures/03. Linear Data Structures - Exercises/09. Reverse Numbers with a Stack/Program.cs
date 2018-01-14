using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();
        Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList()
            .ForEach(n => stack.Push(n));

        Console.WriteLine(String.Join(" ", stack.ToArray()));
    }
}