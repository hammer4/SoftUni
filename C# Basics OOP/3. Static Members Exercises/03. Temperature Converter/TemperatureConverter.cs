using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Temperature_Converter
{
    public class TemperatureConverter
    {
        public static string CelsiusToFahrenheit(int degreesInCelsius)
        {
            double degreesInFahrenheit = degreesInCelsius * 1.8 + 32;
            return String.Format("{0:F2} Fahrenheit", degreesInFahrenheit);
        }

        public static string FahrenheitToCelsius(int degreesInFahrenheit)
        {
            double degreesInCelsius = (degreesInFahrenheit - 32) * (5.0 / 9);
            return String.Format("{0:F2} Celsius", degreesInCelsius);
        }
    }
}
