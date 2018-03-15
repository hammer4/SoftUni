using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Provider : Item
{
    private double energyOutput;

    protected Provider(string id, double energyOutput)
        :base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if(value <= 0 || value >= 10000)
            {
                throw new ArgumentException(nameof(EnergyOutput));
            }
            energyOutput = value;
        }
    }
}