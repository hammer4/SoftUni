using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Car_Salesman
{
    public class Car
    {
        public string model;
        public Engine engine;
        public int weight;
        public string color;

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
            this.weight = 0;
            this.color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            :this(model, engine)
        {
            this.weight = weight;
        }

        public Car(string model, Engine engine, string color)
            :this(model, engine)
        {
            this.color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            :this(model, engine)
        {
            this.weight = weight;
            this.color = color;
        }
    }
}
