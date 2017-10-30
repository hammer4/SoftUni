using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tyre
{
    private double pressure;
    private int age;

    public Tyre(double pressure, int age)
    {
        this.Pressure = pressure;
        this.Age = age;
    }

    internal double Pressure
    {
        get
        {
            return this.pressure;
        }

        private set
        {
            this.pressure = value;
        }
    }

    internal int Age
    {
        get
        {
            return this.age;
        }

        private set
        {
            this.age = value;
        }
    }
}
