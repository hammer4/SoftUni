using System;
using System.Collections.Generic;
using System.Text;

public class DrawingTool
{
    private Figure figure;

    public DrawingTool(Figure figure)
    {
        this.figure = figure;
    }

    public Figure Figure
    {
        get
        {
            return this.figure;
        }
    }
}