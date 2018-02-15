using System;
using System.Collections.Generic;
using System.Text;

public class Square : Figure
{
    private int width;

    public Square(int width)
    {
        this.width = width;
    }

    public override void Draw()
    {
        Console.WriteLine($"|{new string('-', width)}|");

        for(int i=0; i<width-2; i++)
        {
            Console.WriteLine($"|{new string(' ', width)}|");
        }

        Console.WriteLine($"|{new string('-', width)}|");
    }
}
