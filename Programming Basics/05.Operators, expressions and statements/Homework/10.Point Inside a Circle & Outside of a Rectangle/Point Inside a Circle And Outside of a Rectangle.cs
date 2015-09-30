using System;

class PointInsideACircleOutsideOfARectangle
{
    static void Main()
    {
        float x = float.Parse(Console.ReadLine());
        float y = float.Parse(Console.ReadLine());

        if (((x - 1) * (x - 1) + (y - 1) * (y - 1) <= 1.5 * 1.5) && (x < -1 || x > 5 || y < -1 || y > 1))
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");
    }
}
