using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var date1 = new DateTime(tokens[0], tokens[1], tokens[2]);

        tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var date2 = new DateTime(tokens[0], tokens[1], tokens[2]);

        var dateModifier = new DateModifier(date1, date2);
        Console.WriteLine(dateModifier.DateDifferenceInDays());
    }
}