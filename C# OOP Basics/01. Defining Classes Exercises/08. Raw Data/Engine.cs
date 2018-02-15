using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private int speed;
    private int power;

    public Engine(int speed, int power)
    {
        this.Speed = speed;
        this.Power = power;
    }

    public int Power
    {
        get { return power; }
        private set { power = value; }
    }

    public int Speed
    {
        get { return speed; }
        private set { speed = value; }
    }

}