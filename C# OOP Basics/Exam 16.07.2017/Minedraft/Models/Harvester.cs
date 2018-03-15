using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Harvester : Item
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        :base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double EnergyRequirement 
    {
        get { return energyRequirement; }
        protected set
        {
            if(value < 0 || value > 20000)
            {
                throw new ArgumentException(nameof(EnergyRequirement));
            }

            energyRequirement = value;
        }
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(nameof(OreOutput));
            }
            oreOutput = value;
        }
    }
}