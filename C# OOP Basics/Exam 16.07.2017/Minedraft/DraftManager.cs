using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DraftManager
{
    private Dictionary<string, Harvester> harvesters = new Dictionary<string, Harvester>();
    private Dictionary<string, Provider> providers = new Dictionary<string, Provider>();
    private double energyStored = 0;
    private double oreMined = 0;
    private WorkingMode mode = WorkingMode.Full;

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var newHarvester = HarvesterFactory.Create(arguments);
            this.harvesters.Add(newHarvester.Id, newHarvester);
            return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
        }
        catch(ArgumentException ae)
        {
            return $"Harvester is not registered, because of it's {ae.Message}";
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var newProvider = ProviderFactory.Create(arguments);
            this.providers.Add(newProvider.Id, newProvider);
            return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
        }
        catch(ArgumentException ae)
        {
            return $"Provider is not registered, because of it's {ae.Message}";
        }
    }

    public string Day()
    {
        double newEnergy = providers.Values.Sum(p => p.EnergyOutput);
        energyStored += newEnergy;

        double energyCoef = mode == WorkingMode.Full ? 1 : mode == WorkingMode.Half ? 0.6 : 0;
        double oreOutputCoef = mode == WorkingMode.Full ? 1 : mode == WorkingMode.Half ? 0.5 : 0;

        double requiredEnergy = harvesters.Values.Sum(h => h.EnergyRequirement) * energyCoef;

        double oreGained = 0;

        if(requiredEnergy <= energyStored)
        {
            energyStored -= requiredEnergy;
            oreGained = harvesters.Values.Sum(h => h.OreOutput) * oreOutputCoef;
            oreMined += oreGained;
        }

        var builder = new StringBuilder();

        builder.AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {newEnergy}")
            .Append($"Plumbus Ore Mined: {oreGained}");

        return builder.ToString();
    }
    public string Mode(List<string> arguments)
    {
        this.mode = (WorkingMode)Enum.Parse(typeof(WorkingMode), arguments[0]);
        return $"Successfully changed working mode to {this.mode.ToString()} Mode";
    }
    public string Check(List<string> arguments)
    {
        var builder = new StringBuilder();

        string id = arguments[0];
        Item item;

        if (harvesters.ContainsKey(id))
        {
            item = harvesters[id];

            var harvester = (Harvester)item;
            string type = item is SonicHarvester ? "Sonic" : "Hammer";

            builder.AppendLine($"{type} Harvester - {harvester.Id}");
            builder.AppendLine($"Ore Output: {harvester.OreOutput}");
            builder.Append($"Energy Requirement: {harvester.EnergyRequirement}");

            return builder.ToString();
        }

        if (providers.ContainsKey(id))
        {
            item = providers[id];

            var provider = (Provider)item;
            string type = item is PressureProvider ? "Pressure" : "Solar";

            builder.AppendLine($"{type} Provider - {id}");
            builder.Append($"Energy Output: {provider.EnergyOutput}");

            return builder.ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var builder = new StringBuilder();

        builder.AppendLine($"System Shutdown")
            .AppendLine($"Total Energy Stored: {energyStored}")
            .Append($"Total Mined Plumbus Ore: {oreMined}");

        return builder.ToString();
    }
}