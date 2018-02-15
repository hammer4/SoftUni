using System;
using System.Collections.Generic;
using System.Text;

public class Cat
{
    private string name;

    public Cat(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
    }
}
