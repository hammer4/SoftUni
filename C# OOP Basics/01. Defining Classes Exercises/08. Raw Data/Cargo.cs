using System;
using System.Collections.Generic;
using System.Text;
 
public class Cargo
{
    private int weight;
    private string type;

    public Cargo(int weight, string type)
    {
        this.Weight = weight;
        this.Type = type;
    }

    public string Type
    {
        get { return type; }
        private set { type = value; }
    }

    public int Weight
    {
        get { return weight; }
        private set { weight = value; }
    }

}
