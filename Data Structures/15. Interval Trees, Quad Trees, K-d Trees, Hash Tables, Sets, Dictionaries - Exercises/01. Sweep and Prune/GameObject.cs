using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameObject
{
    public GameObject(string name, double x1, double y1)
    {
        this.Name = name;
        this.X1 = x1;
        this.Y1 = y1;
    }

    public string Name { get; private set; }
    public double X1 { get; private set; }
    public double X2 { get { return X1 + 10; } }
    public double Y1 { get; private set; }
    public double Y2 { get { return Y1 + 10; } }

    public void Move(double newX1, double newY1)
    {
        this.X1 = newX1;
        this.Y1 = newY1;
    }
}