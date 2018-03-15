using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProviderFactory
{
    public static Provider Create(List<string> args)
    {
        string type = args[0];

        switch (type)
        {
            case "Solar":
                return new SolarProvider(args[1], double.Parse(args[2]));
            case "Pressure":
                return new PressureProvider(args[1], double.Parse(args[2]));
            default:
                throw new InvalidOperationException();
        }
    }
}