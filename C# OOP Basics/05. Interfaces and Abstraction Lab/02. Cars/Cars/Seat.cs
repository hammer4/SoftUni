using System;
using System.Collections.Generic;
using System.Text;

public class Seat : Car, ICar
{
    public Seat(string model, string color) : base(model, color)
    {
    }
}