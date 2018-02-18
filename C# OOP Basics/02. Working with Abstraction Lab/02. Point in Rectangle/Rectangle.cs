using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    private Point topLeft;
    private Point bottomRight;

    public Rectangle(Point topLeft, Point bottomRight)
    {
        this.topLeft = topLeft;
        this.bottomRight = bottomRight;
    }

    public bool Contains(Point point)
    {
        return this.topLeft.X <= point.X && this.bottomRight.X >= point.X && this.topLeft.Y <= point.Y && this.bottomRight.Y >= point.Y;
    }
}
