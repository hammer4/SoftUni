using System;

class OddEvenSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int oddCounter=0, evenCounter=0;
        while (n>0)
        {
            int odd = int.Parse(Console.ReadLine());
            oddCounter += odd;
            int even = int.Parse(Console.ReadLine());
            evenCounter += even;
            n--;
        }
        Console.WriteLine(oddCounter == evenCounter ? "Yes, sum={0}" : "No, diff={1}", oddCounter, Math.Abs(oddCounter - evenCounter));
    }
}
