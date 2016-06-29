using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Car
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] tokens = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Car car = new Car(tokens[0], tokens[1], tokens[2]);
            string command = Console.ReadLine();
            while(command != "END")
            {
                string[] tok = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                switch(tok[0])
                {
                    case "Travel": car.Travel(double.Parse(tok[1])); break;
                    case "Refuel": car.Refuel(double.Parse(tok[1])); break;
                    case "Distance": car.Distance(); break;
                    case "Time": car.Time(); break;
                    case "Fuel": car.Fuel(); break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
