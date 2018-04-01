using System;
using System.Collections.Generic;
using System.Text;

public class Emerald : Gem
{
    public Emerald(GemClarity clarity) 
        : base(clarity, 1, 4, 9)
    {
    }
}