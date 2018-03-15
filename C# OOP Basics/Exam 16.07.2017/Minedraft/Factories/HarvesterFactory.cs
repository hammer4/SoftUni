using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HarvesterFactory
{
    public static Harvester Create(List<string> args)
    {
        string type = args[0];

        switch (type)
        {
            case "Sonic":
                return new SonicHarvester(args[1], double.Parse(args[2]), double.Parse(args[3]), int.Parse(args[4]));
            case "Hammer":
                return new HammerHarvester(args[1], double.Parse(args[2]), double.Parse(args[3]));
            default:
                throw new InvalidOperationException();
        }
    }
}