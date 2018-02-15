using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] counts = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        List<Rectangle> rectangles = new List<Rectangle>();

        for(int i=0; i<counts[0]; i++)
        {
            var tokens = Console.ReadLine()
                .Split();

            string id = tokens[0];
            double width = double.Parse(tokens[1]);
            double height = double.Parse(tokens[2]);
            double x = double.Parse(tokens[3]);
            double y = double.Parse(tokens[4]);

            rectangles.Add(new Rectangle(id, width, height, x, y));
        }

        for(int i=0; i<counts[1]; i++)
        {
            var tokens = Console.ReadLine().Split();

            Rectangle rectangle1 = rectangles.First(r => r.Id == tokens[0]);
            Rectangle rectangle2 = rectangles.First(r => r.Id == tokens[1]);

            if (rectangle1.Intersects(rectangle2))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}