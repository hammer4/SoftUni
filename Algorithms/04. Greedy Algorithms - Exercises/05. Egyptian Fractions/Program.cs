using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Console.ReadLine().Split('/').Select(e => int.Parse(e)).ToArray();
        int p = tokens[0];
        int q = tokens[1];

        if (p >= q)
        {
            Console.WriteLine("Error (fraction is equal to or greater than 1)");
            return;
        }

        Console.Write($"{p}/{q} = ");
        if (q % p == 0)
        {
            q = q / p;
            p = 1;
            Console.WriteLine($"1/{q}");
            return;
        }

        while (true)
        {
            int divider = (p + q) / p;
            Console.Write($"1/{divider} + ");

            p = (p * divider) - q;
            q = q * divider;

            if (q % p == 0)
            {
                q = q / p;
                p = 1;
                Console.WriteLine($"1/{q}");
                break;
            }
        }
    }
}