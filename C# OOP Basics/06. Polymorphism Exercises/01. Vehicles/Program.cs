using System;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        Vehicle car = new Car(double.Parse(input[1]), double.Parse(input[2]));
        input = Console.ReadLine().Split();
        Vehicle truck = new Truck(double.Parse(input[1]), double.Parse(input[2]));

        int count = int.Parse(Console.ReadLine());

        for(int i=0; i<count; i++)
        {
            input = Console.ReadLine().Split();

            string type = input[1];
            string command = input[0];
            double value = double.Parse(input[2]);

            switch (type)
            {
                case nameof(Car):
                    ExecuteCommand(car, command, value);
                    break;
                case nameof(Truck):
                    ExecuteCommand(truck, command, value);
                    break;
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }

    private static void ExecuteCommand(Vehicle vehicle, string command, double value)
    {
        switch (command)
        {
            case "Drive":
                Console.WriteLine(vehicle.Drive(value));
                break;
            case "Refuel":
                vehicle.Refuel(value);
                break;
        }
    }
}