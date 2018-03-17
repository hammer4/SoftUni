using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EnduranceDriver : Driver
{
    public EnduranceDriver(string name, Car car) 
        : base(name, car)
    {
        this.FuelConsumptionPerKm = 1.5;
    }
}