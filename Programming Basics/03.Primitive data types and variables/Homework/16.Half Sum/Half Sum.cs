using System;

class HalfSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum1=0, sum2=0, count1=0, count2=0;
        while (count1 != n)
        {
            sum1 += int.Parse(Console.ReadLine());
            count1++;
        }
        while (count2 != n)
        {
            sum2 += int.Parse(Console.ReadLine());
            count2++;
        }
        if (sum1 == sum2)
            Console.WriteLine("Yes, sum=" + sum1);
        else
            Console.WriteLine("No, diff=" + Math.Abs(sum1 - sum2));
    }
}
