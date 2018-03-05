using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        QuadTree<TestBox> quadTree = new QuadTree<TestBox>(200, 200, 5);
        var source = new TestBox(0, 0);

        quadTree.Insert(source);
        quadTree.Insert(new TestBox(0, 10));
        quadTree.Insert(new TestBox(0, 10));
        quadTree.Insert(new TestBox(0, 10));
        quadTree.Insert(new TestBox(0, 10));
    }
}
