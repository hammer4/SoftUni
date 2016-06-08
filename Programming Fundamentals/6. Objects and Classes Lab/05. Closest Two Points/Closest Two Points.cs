using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Closest_Two_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            int pointsCount = int.Parse(Console.ReadLine());
            Point[] pointsArray = new Point[pointsCount];

            for (int i=0; i<pointsCount; i++)
            {
                pointsArray[i] = ReadPoint(Console.ReadLine());
            }

            Point[] closestPoints = ClosestPoints(pointsArray);
            foreach(Point point in closestPoints)
            {
                Console.WriteLine("({0}, {1})", point.X, point.Y);
            }
        }

        static Point ReadPoint(string input)
        {
            int[] coordinates = input.Split(' ').Select(int.Parse).ToArray();
            return new Point() { X = coordinates[0], Y = coordinates[1] };
        }

        static Point[] ClosestPoints(Point[] array)
        {
            Point[] closestPoints = new Point[2];
            double minimalDistance = double.MaxValue;

            for(int i=0; i<array.Length; i++)
            {
                for(int j= i+1; j<array.Length; j++)
                {
                    if(CalcPointDistance(array[i], array[j]) < minimalDistance)
                    {
                        minimalDistance = CalcPointDistance(array[i], array[j]);
                        closestPoints[0] = array[i];
                        closestPoints[1] = array[j];
                    }
                }
            }

            Console.WriteLine("{0:F3}", minimalDistance);
            return closestPoints;
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
