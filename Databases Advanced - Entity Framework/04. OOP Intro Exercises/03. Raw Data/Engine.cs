using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Engine
{
    private int speed;
    private int power;

    public Engine(int speed, int power)
    {
        this.Speed = speed;
        this.Power = power;
    }

    internal int Speed
    {
        get
        {
            return this.speed;
        }

        private set
        {
            this.speed = value;
        }
    }

    internal int Power
    {
        get
        {
            return this.power;
        }

        private set
        {
            this.power = value;
        }
    }
}
