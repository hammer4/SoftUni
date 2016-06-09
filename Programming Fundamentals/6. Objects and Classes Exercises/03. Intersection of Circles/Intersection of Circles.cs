using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Intersection_of_Circles
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle1 = ReadCircle(Console.ReadLine());
            Circle circle2 = ReadCircle(Console.ReadLine());
            int deltaX = circle1.Center.X - circle2.Center.X;
            int deltaY = circle1.Center.Y - circle2.Center.Y;
            double distanceBetweenCenters = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            if(distanceBetweenCenters > circle1.Radius + circle2.Radius)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
            }
        }

        static Circle ReadCircle(string input)
        {
            int[] tokens = input.Split(' ').Select(int.Parse).ToArray();
            return new Circle { Center = new Point { X = tokens[0], Y = tokens[1] }, Radius = tokens[2] };
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }
    }
}
