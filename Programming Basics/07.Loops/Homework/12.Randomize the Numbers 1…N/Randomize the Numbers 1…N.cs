using System;

class RandomizeTheNumbers1toN
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        Random rand = new Random();
        for (int i=0; i<n; i++)
        {
            numbers[i] = i + 1;
        }

        for (int i=0; i<n; i++)
        {
            int a = rand.Next(0, n);
            int b;
            do
            {
                b = rand.Next(0, n);
            } while (a == b);
            int buffer;
            buffer = numbers[a];
            numbers[a] = numbers[b];
            numbers[b] = buffer;
        }

        for(int i=0; i<n; i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine();
    }
}