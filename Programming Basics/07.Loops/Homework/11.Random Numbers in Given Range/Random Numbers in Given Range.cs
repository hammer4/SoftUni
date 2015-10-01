using System;

class PRandomNumbersInGivenRange
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int min = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());
        Random rand = new Random();
        for (int i=1; i<=n; i++)
        {
            int number = rand.Next(min, max + 1);
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}
