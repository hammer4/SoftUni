using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TyreFactory
{
    public static Tyre Create(List<string> args)
    {
        string type = args[0];

        switch (type)
        {
            case "Hard":
                return new HardTyre(double.Parse(args[1]));
            case "Ultrasoft":
                return new UltrasoftTyre(double.Parse(args[1]), double.Parse(args[2]));
            default:
                throw new ArgumentException();
        }
    }
}