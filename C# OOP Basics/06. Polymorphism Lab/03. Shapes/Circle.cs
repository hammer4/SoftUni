using System;
using System.Collections.Generic;
using System.Text;

public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius
    {
        get { return radius; }
        private set { radius = value; }
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public override string Draw()
    {
        return base.Draw() + this.GetType().Name;
    }
}
