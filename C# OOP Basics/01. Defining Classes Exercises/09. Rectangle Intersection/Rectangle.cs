using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double x;
    private double y;

    public string Id
    {
        get
        {
            return this.id;
        }
    }

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.x = x;
        this.y = y;
    }

    public bool Intersects(Rectangle other)
    {
        if((other.y >= this.y && other.y - other.height <= this.y && other.x <= this.x && other.x + other.width >= this.x) ||
            (other.y >= this.y && other.y - other.height <= this.y && other.x >= this.x && other.x <= this.x + this.width) ||
            (other.y <= this.y && other.y >= this.y - this.height && other.x <= this.x && other.x + other.width >= this.x) ||
            (other.y <= this.y && other.y >= this.y - this.height && other.x >= this.x && other.x <= this.x + this.width))
        {
            return true;
        }

        return false;
    }
}