using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();
        List<Car> cars = new List<Car>();

        for(int i=0; i<count; i++)
        {
            var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string model = tokens[0];
            int power = int.Parse(tokens[1]);

            if(tokens.Length == 2)
            {
                engines.Add(new Engine(model, power));
            }
            else if(tokens.Length == 3)
            {
                if (tokens[2].All(Char.IsDigit))
                {
                    int displacement = int.Parse(tokens[2]);
                    engines.Add(new Engine(model, power, displacement));
                }
                else
                {
                    string efficiency = tokens[2];
                    engines.Add(new Engine(model, power, efficiency));
                }
            }
            else if(tokens.Length == 4)
            {
                int displacement = int.Parse(tokens[2]);
                string efficiency = tokens[3];

                engines.Add(new Engine(model, power, displacement, efficiency));
            }
        }

        count = int.Parse(Console.ReadLine());

        for(int i=0; i<count; i++)
        {
            var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = tokens[0];
            Engine engine = engines.First(e => e.Model == tokens[1]);

            if(tokens.Length == 2)
            {
                cars.Add(new Car(model, engine));
            }
            else if(tokens.Length == 3)
            {
                if (tokens[2].All(Char.IsDigit))
                {
                    int weight = int.Parse(tokens[2]);

                    cars.Add(new Car(model, engine, weight));
                }
                else
                {
                    string color = tokens[2];

                    cars.Add(new Car(model, engine, color));
                }
            }
            else if(tokens.Length == 4)
            {
                int weight = int.Parse(tokens[2]);
                string color = tokens[3];

                cars.Add(new Car(model, engine, weight, color));
            }
        }

        cars.ForEach(Console.WriteLine);
    }
}
