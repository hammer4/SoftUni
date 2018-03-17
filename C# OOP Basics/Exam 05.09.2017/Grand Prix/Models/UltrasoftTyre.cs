using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UltrasoftTyre : Tyre
{
    private double grip;

    public UltrasoftTyre(double hardness, double grip) 
        : base(hardness)
    {
        this.Name = "Ultrasoft";
        this.Grip = grip;
    }

    public double Grip
    {
        get { return grip; }
        private set { grip = value; }
    }

    public override double Degradation
    {
        get { return base.Degradation; }
        protected set
        {
            if(value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }

            base.Degradation = value;
        }
    }

    internal override void Degradate()
    {
        this.Degradation -= this.Hardness + this.Grip;
    }
}