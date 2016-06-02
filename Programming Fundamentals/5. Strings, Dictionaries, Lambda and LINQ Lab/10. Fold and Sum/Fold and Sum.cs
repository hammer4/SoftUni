using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int k = numbers.Count / 4;
            List<int> firstRowLeft = numbers.Take(k).Reverse().ToList();
            List<int> firstRowRight = numbers.Skip(3 * k).Take(k).Reverse().ToList();
            List<int> firstRow = firstRowLeft.Concat(firstRowRight).ToList();
            List<int> secondRow = numbers.Skip(k).Take(2 * k).ToList();
            List<int> result = firstRow.Select((x, index) => x + secondRow[index]).ToList();
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
