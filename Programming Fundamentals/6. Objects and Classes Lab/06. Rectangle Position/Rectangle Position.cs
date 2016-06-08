using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Rectangle_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect1 = ReadRectangle(Console.ReadLine());
            Rectangle rect2 = ReadRectangle(Console.ReadLine());

            if(IsInside(rect1, rect2))
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
        }

        static Rectangle ReadRectangle(string input)
        {
            int[] properties = input.Split(' ').Select(int.Parse).ToArray();
            return new Rectangle() { Left = properties[0], Top = properties[1], Width = properties[2], Height = properties[3], Right = properties[0] + properties[2], Bottom = properties[1] + properties[3] };
        }

        static bool IsInside(Rectangle r1, Rectangle r2)
        {
            if(r1.Top <= r2.Top && r1.Right <= r2.Right && r1.Bottom <= r2.Bottom && r1.Left >= r2.Left)
            {
                return true;
            }

            return false;
        }
    }

    class Rectangle
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }
}
