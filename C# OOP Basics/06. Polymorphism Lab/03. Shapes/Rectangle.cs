using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Width
    {
        get { return width; }
        private set { width = value; }
    }

    public double Height
    {
        get { return height; }
        private set { height = value; }
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Width + 2 * Height;
    }

    public override string Draw()
    {
        return base.Draw() + this.GetType().Name;
    }
}