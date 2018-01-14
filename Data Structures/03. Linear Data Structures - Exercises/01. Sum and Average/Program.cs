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
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Console.WriteLine($"Sum={(list.Count == 0 ? 0 : list.Sum())}; Average={(list.Count == 0 ? 0 : list.Average()):F2}");
    }
}