using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Dictionary<char, int> counts = new Dictionary<char, int>();

        foreach(var ch in input)
        {
            if (!counts.ContainsKey(ch))
            {
                counts[ch] = 0;
            }

            counts[ch]++;
        }

        BigInteger result = CalculateFactorial(input.Length);

        foreach(var count in counts.Values)
        {
            result /= CalculateFactorial(count);
        }

        Console.WriteLine(result);
    }

    static BigInteger CalculateFactorial(int number)
    {
        BigInteger factorial = 1;

        for(int i=2; i<=number; i++)
        {
            factorial *= i;
        }

        return factorial;
    }
}