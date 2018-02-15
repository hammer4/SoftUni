using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for(int i=0; i<count; i++)
        {
            var tokens = Console.ReadLine().Split();

            string model = tokens[0];
            int speed = int.Parse(tokens[1]);
            int power = int.Parse(tokens[2]);
            int weight = int.Parse(tokens[3]);
            string type = tokens[4];
            List<Tire> tires = new List<Tire>();

            for(int j=5; j<tokens.Length; j += 2)
            {
                double pressure = double.Parse(tokens[j]);
                int age = int.Parse(tokens[j + 1]);

                tires.Add(new Tire(pressure, age));
            }

            Engine engine = new Engine(speed, power);
            Cargo cargo = new Cargo(weight, type);

            cars.Add(new Car(model, engine, cargo, tires));
        }

        string command = Console.ReadLine();

        if(command == "fragile")
        {
            cars
                .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                .Select(c => c.Model)
                .ToList()
                .ForEach(Console.WriteLine);
        }
        else if(command == "flamable")
        {
            cars
                .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                .Select(c => c.Model)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
