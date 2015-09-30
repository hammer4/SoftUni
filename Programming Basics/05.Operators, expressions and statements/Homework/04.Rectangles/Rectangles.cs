using System;

class Rectangles
{
    static void Main()
    {
        float height = float.Parse(Console.ReadLine());
        float width = float.Parse(Console.ReadLine());
        float perimeter = 2 * height + 2 * width;
        float area = height * width;
        Console.WriteLine(perimeter);
        Console.WriteLine(area);
    }
}
