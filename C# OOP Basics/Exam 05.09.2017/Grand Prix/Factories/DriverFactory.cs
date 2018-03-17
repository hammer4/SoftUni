using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DriverFactory
{
    public static Driver Create(List<string> args)
    {
        string type = args[0];
        var tyre = TyreFactory.Create(args.Skip(4).ToList());
        var car = new Car(int.Parse(args[2]), double.Parse(args[3]), tyre);

        switch (type)
        {
            case "Aggressive":
                return new AggressiveDriver(args[1], car);
            case "Endurance":
                return new EnduranceDriver(args[1], car);
            default:
                throw new ArgumentException();
        }
    }
}