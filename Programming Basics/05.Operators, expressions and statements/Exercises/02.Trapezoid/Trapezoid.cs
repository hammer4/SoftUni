using System;

class Trapezoid
{
    static void Main()
    {
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float h = float.Parse(Console.ReadLine());
        float area = ((float)(a + b) / 2) * h;
        Console.WriteLine(area);
    }
}
