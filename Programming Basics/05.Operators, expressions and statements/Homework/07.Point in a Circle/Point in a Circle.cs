using System;

class PointInACircle
{
    static void Main()
    {
        float x = float.Parse(Console.ReadLine());
        float y = float.Parse(Console.ReadLine());
        bool insideCircle = Math.Sqrt(x * x + y * y) <= 2;
        Console.WriteLine(insideCircle);
    }
}
