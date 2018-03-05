using System;
using System.Collections.Generic;

public class KdTree
{
    private Node root;

    public class Node
    {
        public Node(Point2D point)
        {
            this.Point = point;
        }

        public Point2D Point { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    public Node Root
    {
        get
        {
            return this.root;
        }
    }

    public bool Contains(Point2D point)
    {
        Node current = this.Root;

        int depth = 0;
        while(current != null)
        {
            if(current.Point.CompareTo(point) == 0)
            {
                break;
            }

            if (depth % 2 == 0)
            {
                int compareX = current.Point.X.CompareTo(point.X);
                if (compareX > 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            else
            {
                int compareY = current.Point.Y.CompareTo(point.Y);
                if (compareY > 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            depth++;
        }

        return current != null;
    }

    public void Insert(Point2D point)
    {
        this.root = this.Insert(this.root, point, 0);
    }

    private Node Insert(Node node, Point2D point, int depth)
    {
        if (node == null)
        {
            return new Node(point);
        }

        int compare = depth % 2;
        if (compare == 0)
        {
            int compareX = node.Point.X.CompareTo(point.X);
            if (compareX > 0)
            {
                node.Left = this.Insert(node.Left, point, depth + 1);
            }
            else if (compareX <= 0)
            {
                node.Right = this.Insert(node.Right, point, depth + 1);
            }
        }
        else
        {
            int compareY = node.Point.Y.CompareTo(point.Y);
            if (compareY > 0)
            {
                node.Left = this.Insert(node.Left, point, depth + 1);
            }
            else if (compareY <= 0)
            {
                node.Right = this.Insert(node.Right, point, depth + 1);
            }
        }

        return node;
    }

    public void BuildFromList(List<Point2D> systems)
    {
        this.root = this.Build(systems);
    }

    private Node Build(List<Point2D> systems, int depth = 0)
    {

        if (systems.Count == 0)
        {
            return null;
        }

        int axis = depth % 2;
        systems.Sort((x, y) =>
        {
            if (axis == 0)
            {
                return x.X.CompareTo(y.X);
            }
            return x.Y.CompareTo(y.Y);
        });

        int median = systems.Count / 2;
        List<Point2D> left = new List<Point2D>();
        List<Point2D> right = new List<Point2D>();

        for (int i = 0; i < median; i++)
        {
            left.Add(systems[i]);
        }
        for (int i = median + 1; i < systems.Count; i++)
        {
            right.Add(systems[i]);
        }

        Node newNode = new Node(systems[median]);
        newNode.Left = this.Build(left, depth + 1);
        newNode.Right = this.Build(right, depth + 1);
        return newNode;
    }

    public void EachInOrder(Action<Point2D> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<Point2D> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Point);
        this.EachInOrder(node.Right, action);
    }

    public void GetPoints(Action<Point2D> action, Rectangle rectangle, Rectangle space, int depth = 0)
    {
        this.EachInOrder(this.Root, action, rectangle, space, depth);
    }

    private void EachInOrder(Node node, Action<Point2D> action, Rectangle rectangle, Rectangle space, int depth)
    {
        if(node == null)
        {
            return;
        }

        if (node.Point.IsInRectangle(rectangle))
        {
            action(node.Point);
        }

        Rectangle leftRect;
        Rectangle rightRect;

        if(depth % 2 == 0)
        {
            leftRect = new Rectangle(space.X1, node.Point.X, space.Y1, space.Y2);
            rightRect = new Rectangle(node.Point.X, space.X2, space.Y1, space.Y2);
        }
        else
        {
            leftRect = new Rectangle(space.X1, space.X2, space.Y1, node.Point.Y);
            rightRect = new Rectangle(space.X1, space.X2, node.Point.Y, space.Y2);
        }

        if (rectangle.Intersects(leftRect))
        {
            this.EachInOrder(node.Left, action, rectangle, leftRect, depth + 1);
        }

        if (rectangle.Intersects(rightRect))
        {
            this.EachInOrder(node.Right, action, rectangle, rightRect, depth + 1);
        }
    }
}
