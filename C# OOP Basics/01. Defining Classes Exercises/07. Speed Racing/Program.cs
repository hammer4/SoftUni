using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();

        int count = int.Parse(Console.ReadLine());

        for(int i =0; i<count; i++)
        {
            var tokens = Console.ReadLine().Split();

            cars.Add(new Car(tokens[0], decimal.Parse(tokens[1]), decimal.Parse(tokens[2])));
        }

        string command;

        while((command = Console.ReadLine()) != "End")
        {
            var tokens = command.Split();

            string model = tokens[1];
            int distance = int.Parse(tokens[2]);

            Car car = cars.First(c => c.Model == model);

            if (!car.Drive(distance))
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        cars.ForEach(Console.WriteLine);
    }
}
