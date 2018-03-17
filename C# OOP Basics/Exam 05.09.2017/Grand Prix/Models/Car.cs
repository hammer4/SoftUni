using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Car
{
    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public Tyre Tyre
    {
        get { return tyre; }
        private set { tyre = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        private set
        {
            if(value > 160)
            {
                fuelAmount = 160;
                return;
            }

            if(value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            fuelAmount = value;
        }
    }

    public int Hp
    {
        get { return hp; }
        private set { hp = value; }
    }

    internal void ReduceFuel(double fuel)
    {
        this.FuelAmount -= fuel;
    }

    internal void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    internal void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }
}