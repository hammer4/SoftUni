using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Cargo
{
    private int weight;
    private string type;

    public Cargo(int weight, string type)
    {
        this.Weight = weight;
        this.Type = type;
    }

    internal int Weight
    {
        get
        {
            return this.weight;
        }

        private set
        {
            this.weight = value;
        }
    }

    internal string Type
    {
        get
        {
            return this.type;
        }

        private set
        {
            this.type = value;
        }
    }
}
