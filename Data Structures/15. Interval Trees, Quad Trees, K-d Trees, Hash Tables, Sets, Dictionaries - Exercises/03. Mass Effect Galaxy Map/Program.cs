using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        KdTree tree = new KdTree();

        int count = int.Parse(Console.ReadLine());
        int reportsCount = int.Parse(Console.ReadLine());
        int size = int.Parse(Console.ReadLine());
        Rectangle space = new Rectangle(0, size, 0, size);

        List<Point2D> points = new List<Point2D>();
        for (int i = 0; i < count; i++)
        {
            var tokens = Console.ReadLine().Split();

            Point2D point = new Point2D(double.Parse(tokens[1]), double.Parse(tokens[2]));

            if (point.IsInRectangle(space))
            {
               points.Add(point);
            }
        }

        //tree.BuildFromList(points);

        points.ForEach(tree.Insert);
        points.Clear();

        for (int i = 0; i < reportsCount; i++)
        {
            var tokens = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            Rectangle rect = new Rectangle(tokens[0], tokens[0] + tokens[2], tokens[1], tokens[1] + tokens[3]);

            tree.GetPoints(points.Add, rect, space);

            Console.WriteLine(points.Count);
            points.Clear();
        }
    }
}