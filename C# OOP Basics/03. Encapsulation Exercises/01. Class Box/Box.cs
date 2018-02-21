using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public string GetSurfaceArea()
    {
        double surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height;

        return $"Surface Area - {surfaceArea:F2}";
    }

    public string GetLateralSurfaceArea()
    {
        double lateralSurfaceArea = 2 * length * height + 2 * width * height;

        return $"Lateral Surface Area - {lateralSurfaceArea:F2}";
    }

    public string GetVolume()
    {
        double volume = length * width * height;

        return $"Volume - {volume:F2}";
    }
}