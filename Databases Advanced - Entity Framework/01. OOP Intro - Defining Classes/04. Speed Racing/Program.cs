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
        List<Car> cars = new List<Car>();

        for(int i=1; i <= carsCount; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            cars.Add(new Car(tokens[0], decimal.Parse(tokens[1]), decimal.Parse(tokens[2])));
        }

        string command;
        while((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split();
            cars.First(c => c.Model == tokens[1]).Drive(int.Parse(tokens[2]));
        }

        cars.ForEach(c => Console.WriteLine(c));
    }
}

