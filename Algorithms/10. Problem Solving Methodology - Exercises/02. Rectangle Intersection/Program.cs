using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var rectangles = new List<Rectangle>();
        var x = new List<int>();
        long result = 0;

        for (int i = 0; i < n; i++)
        {
            var coordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            x.Add(coordinates[0]);
            x.Add(coordinates[1]);
            rectangles.Add(new Rectangle(coordinates[0], coordinates[1], coordinates[2], coordinates[3]));
        }

        x.Sort();
        List<Rectangle>[] rect = new List<Rectangle>[x.Count - 1];
        for (int i = 0; i < x.Count - 1; i++)
        {
            rect[i] = new List<Rectangle>();
        }

        foreach (var rectangle in rectangles)
        {
            for (int i = 0; i < rect.Count(); i++)
            {
                if (rectangle.MaxX > x[i] && rectangle.MinX < x[i + 1])
                {
                    rect[i].Add(rectangle);
                }
            }
        }

        for (int i = 0; i < rect.Count(); i++)
        {
            if (rect[i].Count() < 2)
            {
                continue;
            }

            var y = new List<int>();

            foreach (var rectangle in rect[i])
            {
                y.Add(rectangle.MinY);
                y.Add(rectangle.MaxY);
            }

            y.Sort();
            var overlapped = new int[y.Count - 1];
            foreach (var rectangle in rect[i])
            {
                for (int j = 0; j < y.Count; j++)
                {
                    if (rectangle.MaxY <= y[j] || rectangle.MinY >= y[j + 1])
                    {
                        continue;
                    }
                    overlapped[j]++;
                }
            }

            for (int j = 0; j < overlapped.Count(); j++)
            {
                if (overlapped[j] >= 2)
                {
                    int xSide = x[i + 1] - x[i];
                    int ySide = y[j + 1] - y[j];
                    result += xSide * ySide;
                }
            }
        }

        Console.WriteLine(result);
    }
}

class Rectangle : IComparable<Rectangle>
{
    public Rectangle(int minX, int maxX, int minY, int maxY)
    {
        this.MinX = minX;
        this.MaxX = maxX;
        this.MinY = minY;
        this.MaxY = maxY;
    }

    public int MinX { get; set; }

    public int MaxX { get; set; }

    public int MinY { get; set; }

    public int MaxY { get; set; }

    public int CompareTo(Rectangle other)
    {
        return this.MinX.CompareTo(other.MinX);
    }

    public decimal CalculatedArea()
    {
        return Math.Abs((this.MaxX - this.MinX) * (this.MaxY - this.MinY));
    }
}