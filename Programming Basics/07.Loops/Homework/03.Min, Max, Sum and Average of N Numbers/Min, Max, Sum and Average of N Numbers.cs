using System;

class MinMaxSumandAverageOfNNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int min = int.MaxValue;
        int max = int.MinValue;
        int sum = 0;
        double avg;
        int counter = 0;
        
        while (counter<n)
        {
            int number = int.Parse(Console.ReadLine());
            if (number<min)
            {
                min = number;
            }
            if (number > max)
            {
                max = number;
            }
            sum += number;
            counter++;
        }
        avg = (double)sum / n;

        Console.WriteLine("min = " + min);
        Console.WriteLine("max = " + max);
        Console.WriteLine("sum = " + sum);
        Console.WriteLine("avg = {0:F2}", avg);
    }
}