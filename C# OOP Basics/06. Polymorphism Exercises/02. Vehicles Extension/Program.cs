using System;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        Vehicle car = new Car(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
        input = Console.ReadLine().Split();
        Vehicle truck = new Truck(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
        input = Console.ReadLine().Split();
        Vehicle bus = new Bus(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
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
                case nameof(Bus):
                    ExecuteCommand(bus, command, value);
                    break;
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }

    private static void ExecuteCommand(Vehicle vehicle, string command, double value)
    {
        switch (command)
        {
            case "Drive":
                Console.WriteLine(vehicle.Drive(value));
                break;
            case "Refuel":
                try
                {
                    vehicle.Refuel(value);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case "DriveEmpty":
                ((Bus)vehicle).SwitchOffAirConditioner();
                Console.WriteLine(vehicle.Drive(value));
                ((Bus)vehicle).SwitchOnAirConditioner();
                break;
        }
    }
}
