using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Car
{
    public class Car
    {
        public double speed;
        public double fuel;
        public double fuelEconomy;
        public double travelDistance;
        public double travelTime;

        public Car(double speed, double fuel, double fuelEconomy)
        {
            this.speed = speed;
            this.fuel = fuel;
            this.fuelEconomy = fuelEconomy;
            this.travelDistance = 0;
            this.travelTime = 0;
        }

        public void Travel(double distance)
        {
            double requiredFuel = fuelEconomy * (distance / 100);
            if(this.fuel >= requiredFuel)
            {
                this.fuel -= requiredFuel;
                this.travelDistance += distance;
                this.travelTime += (distance / this.speed) * 60;
            }
            else
            {
                double passedDistance = this.fuel / (this.fuelEconomy / 100);
                this.fuel = 0;
                this.travelDistance += passedDistance;
                this.travelTime += (passedDistance / this.speed) * 60;
            }
        }

        public void Refuel(double load)
        {
            this.fuel += load;
        }

        public void Distance()
        {
            Console.WriteLine("Total distance: {0:F1} kilometers", this.travelDistance);
        }

        public void Time()
        {
            Console.WriteLine("Total time: {0} hours and {1} minutes", this.travelTime/60, this.travelTime%60);
        }

        public void Fuel()
        {
            Console.WriteLine("Fuel left: {0:F1} liters", this.fuel);
        }
    }
}
