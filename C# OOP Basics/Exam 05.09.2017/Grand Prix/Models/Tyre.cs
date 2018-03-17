using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Tyre
{
    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public virtual double Degradation
    {
        get { return degradation; }
        protected set
        {
            if(value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }

            degradation = value;
        }
    }

    public double Hardness
    {
        get { return hardness; }
        private set { hardness = value; }
    }

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    internal virtual void Degradate()
    {
        this.Degradation -= this.Hardness;
    }
}