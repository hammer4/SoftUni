using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int carsCount = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for(int i=0; i<carsCount; i++)
        {
            var tokens = Console.ReadLine().Split();
            Car car = new Car(tokens[0]);
            car.Engine = new Engine(int.Parse(tokens[1]), int.Parse(tokens[2]));
            car.Cargo = new Cargo(int.Parse(tokens[3]), tokens[4]);

            for(int j=0; j<8; j += 2)
            {
                car.AddTyre(new Tyre(double.Parse(tokens[j + 5]), int.Parse(tokens[j + 6])));
            }

            cars.Add(car);
        }

        var command = Console.ReadLine();

        if(command == "fragile")
        {
            cars.Where(c => c.Cargo.Type == command && c.Tyres.Any(t => t.Pressure < 1)).ToList().ForEach(c => Console.WriteLine(c.Model));
        }
        else if(command == "flammable")
        {
            cars.Where(c => c.Cargo.Type == command && c.Engine.Power > 250).ToList().ForEach(c => Console.WriteLine(c.Model));
        }
    }
}
