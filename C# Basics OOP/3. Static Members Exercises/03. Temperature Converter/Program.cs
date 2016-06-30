using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Temperature_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while(command != "End")
            {
                string[] tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                switch(tokens[1])
                {
                    case "Celsius": Console.WriteLine(TemperatureConverter.CelsiusToFahrenheit(int.Parse(tokens[0]))); break;
                    case "Fahrenheit": Console.WriteLine(TemperatureConverter.FahrenheitToCelsius(int.Parse(tokens[0]))); break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
