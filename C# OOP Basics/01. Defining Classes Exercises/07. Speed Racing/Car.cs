using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private string model;
    private decimal fuelAmount;
    private decimal fuelConsumption;
    private int distanceTravelled;

    public Car(string model, decimal fuelAmount, decimal fuelConsumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumption = fuelConsumption;
    }

    public int DistanceTravelled
    {
        get { return distanceTravelled; }
        private set { distanceTravelled = value; }
    }

    public decimal FuelConsumption
    {
        get { return fuelConsumption; }
        private set { fuelConsumption = value; }
    }

    public decimal FuelAmount
    {
        get { return fuelAmount; }
        private set { fuelAmount = value; }
    }

    public string Model
    {
        get { return model; }
        private set { model = value; }
    }

    public bool Drive(int distance)
    {
        if(distance * FuelConsumption <= FuelAmount)
        {
            FuelAmount -= FuelConsumption * distance;
            DistanceTravelled += distance;
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{Model} {FuelAmount:F2} {DistanceTravelled}";
    }
}