using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
    }

    internal string FailureReason { get; private set; }

    public virtual double Speed
    {
        get { return (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount; }
    }

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        protected set { fuelConsumptionPerKm = value; }
    }

    public Car Car
    {
        get { return car; }
        private set { car = value; }
    }

    public double TotalTime
    {
        get { return totalTime; }
        private set { totalTime = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    internal void CompleteLap(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);
    }

    internal void Disqualify(string reason)
    {
        this.FailureReason = reason;
    }

    internal void ReduceTime(int seconds)
    {
        this.TotalTime -= seconds;
    }

    internal void IncreaseTime(int seconds)
    {
        this.TotalTime += seconds;
    }
}