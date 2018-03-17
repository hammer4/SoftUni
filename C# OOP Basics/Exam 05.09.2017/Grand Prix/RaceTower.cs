using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RaceTower
{
    private Dictionary<string, Driver> activeDrivers = new Dictionary<string, Driver>();
    private Dictionary<string, Driver> disqalifiedDrivers = new Dictionary<string, Driver>();

    private int lapsNumber;
    private int trackLength;
    private int currentLap;
    private Weather weather = Weather.Sunny;

    internal bool IsFinished { get; private set; }
    internal Driver Winner { get; private set; }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
  
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var driver = DriverFactory.Create(commandArgs);
            activeDrivers.Add(driver.Name, driver);
        }
        catch
        {

        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reason = commandArgs[0];
        string name = commandArgs[1];

        if (activeDrivers.ContainsKey(name))
        {
            var driver = activeDrivers[name];

            driver.IncreaseTime(20);

            if(reason == "ChangeTyres")
            {
                Tyre tyre = TyreFactory.Create(commandArgs.Skip(2).ToList());

                driver.Car.ChangeTyres(tyre);
            }
            else if(reason == "Refuel")
            {
                double fuel = double.Parse(commandArgs[2]);

                driver.Car.Refuel(fuel);
            }
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var builder = new StringBuilder();

        int numberOfLaps = int.Parse(commandArgs[0]);

        if(numberOfLaps > lapsNumber - currentLap)
        {
            try
            {
                throw new ArgumentException($"There is no time! On lap {currentLap}.");
            }
            catch(ArgumentException ae)
            {
                return ae.Message;
            }
        }

        for(int i=0; i<numberOfLaps; i++)
        {
            foreach(var driver in activeDrivers.Values)
            {
                driver.CompleteLap(trackLength);
            }

            currentLap++;

            var racers = activeDrivers.Values.Select(d => d.Name).ToList();

            foreach (var driver in racers)
            {
                try
                {
                    activeDrivers[driver].Car.ReduceFuel(trackLength * activeDrivers[driver].FuelConsumptionPerKm);

                    try
                    {
                        activeDrivers[driver].Car.Tyre.Degradate();
                    }
                    catch (ArgumentException ae)
                    {
                        var racer = activeDrivers[driver];

                        racer.Disqualify(ae.Message);
                        activeDrivers.Remove(driver);
                        disqalifiedDrivers.Add(driver, racer);
                    }
                }
                catch(ArgumentException ae)
                {
                    var racer = activeDrivers[driver];

                    racer.Disqualify(ae.Message);
                    activeDrivers.Remove(driver);
                    disqalifiedDrivers.Add(driver, racer);
                }
            }

            var active = activeDrivers.Values.Reverse().OrderBy(d => d.TotalTime).ToArray();

            for(int j= active.Length - 1; j>0; j--)
            {
                if(active.Length >= 2)
                {
                    var overtakingCandidate = active[j];
                    var overtakenCandidate = active[j - 1];

                    if(overtakingCandidate is AggressiveDriver && overtakingCandidate.Car.Tyre is UltrasoftTyre &&
                        overtakingCandidate.TotalTime - overtakenCandidate.TotalTime <= 3)
                    {
                        if(weather == Weather.Foggy)
                        {
                            overtakingCandidate.Disqualify("Crashed");
                            disqalifiedDrivers.Add(overtakingCandidate.Name, overtakingCandidate);
                            activeDrivers.Remove(overtakingCandidate.Name);
                        }
                        else
                        {
                            builder.AppendLine($"{overtakingCandidate.Name} has overtaken " +
                                $"{overtakenCandidate.Name} on lap {currentLap}.");
                            overtakingCandidate.ReduceTime(3);
                            overtakenCandidate.IncreaseTime(3);
                            j--;
                        }
                    }
                    else if(overtakingCandidate is EnduranceDriver && overtakingCandidate.Car.Tyre is HardTyre &&
                        overtakingCandidate.TotalTime - overtakenCandidate.TotalTime <= 3)
                    {
                        if(weather == Weather.Rainy)
                        {
                            overtakingCandidate.Disqualify("Crashed");
                            disqalifiedDrivers.Add(overtakingCandidate.Name, overtakingCandidate);
                            activeDrivers.Remove(overtakingCandidate.Name);
                        }
                        else
                        {
                            builder.AppendLine($"{overtakingCandidate.Name} has overtaken {overtakenCandidate.Name} " +
                                $"on lap {currentLap}.");

                            overtakingCandidate.ReduceTime(3);
                            overtakenCandidate.IncreaseTime(3);
                            j--;
                        }
                    }
                    else if(overtakingCandidate.TotalTime - overtakenCandidate.TotalTime <= 2)
                    {
                        builder.AppendLine($"{overtakingCandidate.Name} " +
                            $"has overtaken {overtakenCandidate.Name} on lap {currentLap}.");
                        overtakingCandidate.ReduceTime(2);
                        overtakenCandidate.IncreaseTime(2);
                        j--;
                    }
                }
            }


            if(currentLap == lapsNumber)
            {
                IsFinished = true;
                Winner = activeDrivers.Values.OrderBy(d => d.TotalTime).First();
            }
        }

        return builder.ToString().Trim();
    }

    public string GetLeaderboard()
    {
        var builder = new StringBuilder();

        builder.AppendLine($"Lap {currentLap}/{lapsNumber}");

        int counter = 1;
        foreach(var driver in activeDrivers.Values.OrderBy(d => d.TotalTime))
        {
            builder.AppendLine($"{counter++} {driver.Name} {driver.TotalTime:F3}");
        }

        foreach(var driver in disqalifiedDrivers.Values.Reverse())
        {
            builder.AppendLine($"{counter++} {driver.Name} {driver.FailureReason}");
        }

        return builder.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        weather = (Weather)Enum.Parse(typeof(Weather), commandArgs[0]);
    }

}