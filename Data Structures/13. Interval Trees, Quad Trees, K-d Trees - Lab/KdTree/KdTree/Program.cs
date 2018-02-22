using System;

public class Program
{
    static void Main(string[] args)
    {
        KdTree tree = new KdTree();
        tree.Insert(new Point2D(5, 5));
        tree.Insert(new Point2D(3, 2));
        tree.Insert(new Point2D(2, 6));
        tree.Insert(new Point2D(8, 8));
        tree.Insert(new Point2D(8, 9));
    }
}
