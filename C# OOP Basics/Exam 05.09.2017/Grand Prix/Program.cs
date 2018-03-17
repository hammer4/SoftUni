using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var race = new RaceTower();

        int count = int.Parse(Console.ReadLine());
        int length = int.Parse(Console.ReadLine());

        race.SetTrackInfo(count, length);

        while (true)
        {
            var args = Console.ReadLine().Split();
            var commandArgs = args.Skip(1).ToList();

            switch (args[0])
            {
                case "RegisterDriver":
                    race.RegisterDriver(commandArgs);
                    break;
                case "Leaderboard":
                    Console.WriteLine(race.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    string output = race.CompleteLaps(commandArgs);

                    if (output != String.Empty)
                    {
                        Console.WriteLine(output);
                    }

                    if (race.IsFinished)
                    {
                        Console.WriteLine($"{race.Winner.Name} wins the race for {race.Winner.TotalTime:f3} seconds.");
                        return;
                    }

                    break;
                case "Box":
                    race.DriverBoxes(commandArgs);
                    break;
                case "ChangeWeather":
                    race.ChangeWeather(commandArgs);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}