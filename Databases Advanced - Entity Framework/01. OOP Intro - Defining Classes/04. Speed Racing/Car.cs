using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Car
{
    public string Model { get; set; }
    public decimal Fuel { get; set; }
    public decimal Consumption { get; set; }
    public decimal Mileage { get; set; }

    public Car(string model, decimal fuel, decimal consumption)
    {
        this.Model = model;
        this.Fuel = fuel;
        this.Consumption = consumption;
        this.Mileage = 0;
    }

    public void Drive(int distance)
    {
        if(this.Consumption * distance > this.Fuel)
        {
            Console.WriteLine("Insufficient fuel for the drive");
            return;
        }

        this.Fuel -= this.Consumption * distance;
        this.Mileage += distance;
    }

    public override string ToString()
    {
        return $"{this.Model} {this.Fuel:f2} {this.Mileage}";
    }
}
