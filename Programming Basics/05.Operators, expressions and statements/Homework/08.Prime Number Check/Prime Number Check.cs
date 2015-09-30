using System;

class PrimeNumberCheck
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int counter=0;
        for (int i = 2; i <= n / 2; i++)
            if (n % i == 0)
                counter++;
        bool result = counter == 0 && n>1;
        Console.WriteLine(result);
    }
}
