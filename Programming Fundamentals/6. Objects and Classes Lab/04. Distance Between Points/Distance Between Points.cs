using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.Distance_Between_Points;

namespace _04.Distance_Between_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point1 = PointReader(Console.ReadLine());
            Point point2 = PointReader(Console.ReadLine());
            Console.WriteLine("{0:F3}",CalcPointDistance(point1, point2));
        }

        static Point PointReader(string input)
        {
            int[] coordinates = input.Split(' ').Select(int.Parse).ToArray();
            return new Point() { X = coordinates[0], Y = coordinates[1] };
        }

        static double CalcPointDistance(Point point1, Point point2)
        {
            int deltaX = point1.X - point2.X;
            int deltaY = point1.Y - point2.Y;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
