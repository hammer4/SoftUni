using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle : Figure
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public override void Draw()
    {
        Console.WriteLine($"|{new string('-', width)}|");

        for(int i=0; i<height-2; i++)
        {
            Console.WriteLine($"|{new string(' ', width)}|");
        }

        Console.WriteLine($"|{new string('-', width)}|");
    }
}
