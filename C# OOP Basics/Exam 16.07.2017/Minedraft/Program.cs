using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var manager = new DraftManager();

        while (true)
        {
            string[] tokens = Console.ReadLine().Split();
            var args = tokens.Skip(1).ToList();

            switch (tokens[0])
            {
                case "RegisterHarvester":
                    Console.WriteLine(manager.RegisterHarvester(args));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(manager.RegisterProvider(args));
                    break;
                case "Day":
                    Console.WriteLine(manager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(manager.Mode(args));
                    break;
                case "Check":
                    Console.WriteLine(manager.Check(args));
                    break;
                case "Shutdown":
                    Console.WriteLine(manager.ShutDown());
                    return;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}