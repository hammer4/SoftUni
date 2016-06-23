using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Google
{
    public class Car
    {
        public string model;
        public int speed;

        public Car(string model, int speed)
        {
            this.model = model;
            this.speed = speed;
        }

        public override string ToString()
        {
            return this.model + " " + this.speed;
        }
    }
}
