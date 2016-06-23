using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Car_Salesman
{
    public class Engine
    {
        public string model;
        public string power;
        public int displacement;
        public string efficiency;

        public Engine(string model, string power)
        {
            this.model = model;
            this.power = power;
            this.displacement = 0;
            this.efficiency = "n/a";
        }

        public Engine(string model, string power, int displacement)
            :this(model, power)
        {
            this.displacement = displacement;
        }

        public Engine(string model, string power, string efficiency)
            :this(model, power)
        {
            this.efficiency = efficiency;
        }

        public Engine(string model, string power, int displacement, string efficiency)
            :this(model, power)
        {
            this.displacement = displacement;
            this.efficiency = efficiency;
        }
    }
}
