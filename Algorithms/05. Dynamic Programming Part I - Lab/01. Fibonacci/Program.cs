using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static long?[] fibValues;

    static void Main(string[] args)
    {
        int fibNumber = int.Parse(Console.ReadLine());

        fibValues = new long?[fibNumber + 1];
        fibValues[0] = 0;
        fibValues[1] = 1;

        long result = CalculateFibonacci(fibNumber);
        Console.WriteLine(result);
    }

    private static long CalculateFibonacci(int number)
    {
        if(fibValues[number] != null)
        {
            return (long)fibValues[number];
        }

        fibValues[number] = CalculateFibonacci(number - 1) + CalculateFibonacci(number - 2);
        return (long)fibValues[number];
    }
}