using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Rectangle_Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] counts = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Rectangle[] rectangles = new Rectangle[counts[0]];

            for(int i = 0; i< counts[0]; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                string id = tokens[0];
                double width = double.Parse(tokens[1]);
                double height = double.Parse(tokens[2]);
                double x = double.Parse(tokens[3]);
                double y = double.Parse(tokens[4]);

                rectangles[i] = new Rectangle(id, width, height, x, y);
            }

            for(int i=0; i< counts[1]; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                Rectangle rect1 = rectangles.Where(r => r.id == tokens[0]).First();
                Rectangle rect2 = rectangles.Where(r => r.id == tokens[1]).First();
                Console.WriteLine(rect1.Intersects(rect2));
            }
        }
    }
}
