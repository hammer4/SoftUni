using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Split
{
    public static class CommandExecutor
    {
        public static void RegisterPowerHardware(List<HardwareComponent> computer, string command)
        {
            string[] tokens = command.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
            string name = tokens[0];
            long capacity = long.Parse(tokens[1]);
            long memory = long.Parse(tokens[2]);
            computer.Add(new PowerHardwareComponent(name, capacity, memory));
        }

        public static void RegisterHeavyHardware(List<HardwareComponent> computer, string command)
        {
            string[] tokens = command.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            long capacity = long.Parse(tokens[1]);
            long memory = long.Parse(tokens[2]);
            computer.Add(new HeavyHardwareComponent(name, capacity, memory));
        }

        public static void RegisterExpressSoftware(List<HardwareComponent> computer, string command)
        {
            string[] tokens = command.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
            string hardwareName = tokens[0];
            string softwareName = tokens[1];
            long capacity = long.Parse(tokens[2]);
            long memory = long.Parse(tokens[3]);
            
            if(computer.Any(h => h.Name == hardwareName))
            {
                HardwareComponent hardware = computer.Where(h => h.Name == hardwareName).First();
                if (hardware.MaximumCapacity - hardware.UsedCapacity >= capacity && hardware.MaximumMemory - hardware.UsedMemory >= memory)
                    {
                    SoftwareComponent software = new ExpressSoftwareComponent(softwareName, capacity, memory);
                    hardware.AddSoftwareComponent(software);
                    hardware.UsedCapacity += software.CapacityConsumption;
                    hardware.UsedMemory += software.MemoryConsumption;
                }
            }
        }

        public static void RegisterLightSoftware(List<HardwareComponent> computer, string command)
        {
            string[] tokens = command.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
            string hardwareName = tokens[0];
            string softwareName = tokens[1];
            long capacity = long.Parse(tokens[2]);
            long memory = long.Parse(tokens[3]);

            if (computer.Any(h => h.Name == hardwareName))
            {
                HardwareComponent hardware = computer.Where(h => h.Name == hardwareName).First();
                if (hardware.MaximumCapacity - hardware.UsedCapacity >= capacity && hardware.MaximumMemory - hardware.UsedMemory >= memory)
                {
                    SoftwareComponent software = new LightSoftwareComponent(softwareName, capacity, memory);
                    hardware.AddSoftwareComponent(software);
                    hardware.UsedCapacity += software.CapacityConsumption;
                    hardware.UsedMemory += software.MemoryConsumption;
                }
            }
        }

        public static void ReleaseSoftwareComponent(List<HardwareComponent> computer, string command)
        {
            string[] tokens = command.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
            string hardwareName = tokens[0];
            string softwareName = tokens[1];
            
            if(computer.Any(h => h.Name == hardwareName))
            {
                HardwareComponent hardware = computer.Where(h => h.Name == hardwareName).First();

                if(hardware.SeeSoftware().Any(s => s.Name == softwareName))
                {
                    SoftwareComponent software = hardware.SeeSoftware().Where(s => s.Name == softwareName).First();

                    hardware.RemoveSoftwareComponent(software);
                    hardware.UsedCapacity -= software.CapacityConsumption;
                    hardware.UsedMemory -= software.MemoryConsumption;
                }
            } 
        }

        public static void Analyze(List<HardwareComponent> computer)
        {
            Console.WriteLine("System Analysis");
            Console.WriteLine("Hardware Components: {0}", computer.Count);
            Console.WriteLine("Software Components: {0}", computer.Sum(h => h.SeeSoftware().Count));
            Console.WriteLine("Total Operational Memory: {0} / {1}", computer.Select(h => h.UsedMemory).Sum(), computer.Select(h => h.MaximumMemory).Sum());
            Console.WriteLine("Total Capacity Taken: {0} / {1}", computer.Select(h => h.UsedCapacity).Sum(), computer.Select(h => h.MaximumCapacity).Sum());
        }

        public static void SystemSplit(List<HardwareComponent> computer)
        {
            foreach(HardwareComponent hardware in computer.Where(h => h is PowerHardwareComponent))
            {
                Console.WriteLine("Hardware Component - {0}", hardware.Name);
                Console.WriteLine("Express Software Components - {0}", hardware.SeeSoftware().Where(s => s is ExpressSoftwareComponent).Count());
                Console.WriteLine("Light Software Components - {0}", hardware.SeeSoftware().Where(s => s is LightSoftwareComponent).Count());
                Console.WriteLine("Memory Usage: {0} / {1}", hardware.UsedMemory, hardware.MaximumMemory);
                Console.WriteLine("Capacity Usage: {0} / {1}", hardware.UsedCapacity, hardware.MaximumCapacity);
                Console.WriteLine("Type: Power");
                if (hardware.SeeSoftware().Count > 0)
                {
                    Console.WriteLine("Software Components: {0}", string.Join(", ", hardware.SeeSoftware().Select(s => s.Name)));
                }
                else
                    Console.WriteLine("Software Components: None");
            }

            foreach (HardwareComponent hardware in computer.Where(h => h is HeavyHardwareComponent))
            {
                Console.WriteLine("Hardware Component - {0}", hardware.Name);
                Console.WriteLine("Express Software Components - {0}", hardware.SeeSoftware().Where(s => s is ExpressSoftwareComponent).Count());
                Console.WriteLine("Light Software Components - {0}", hardware.SeeSoftware().Where(s => s is LightSoftwareComponent).Count());
                Console.WriteLine("Memory Usage: {0} / {1}", hardware.UsedMemory, hardware.MaximumMemory);
                Console.WriteLine("Capacity Usage: {0} / {1}", hardware.UsedCapacity, hardware.MaximumCapacity);
                Console.WriteLine("Type: Heavy");
                if (hardware.SeeSoftware().Count > 0)
                {
                    Console.WriteLine("Software Components: {0}", string.Join(", ", hardware.SeeSoftware().Select(s => s.Name)));
                }
                else
                    Console.WriteLine("Software Components: None");
            }
        }

        public static void Dump(List<HardwareComponent> computer, List<HardwareComponent> dump, string command)
        {
            if(computer.Any(h => h.Name == command))
            {
                HardwareComponent hardware = computer.Where(h => h.Name == command).First();
                computer.Remove(hardware);
                dump.Add(hardware);
            }
        }

        public static void Restore(List<HardwareComponent> computer, List<HardwareComponent> dump, string command)
        {
            if (dump.Any(h => h.Name == command))
            {
                HardwareComponent hardware = dump.Where(h => h.Name == command).First();
                dump.Remove(hardware);
                computer.Add(hardware);
            }
        }

        public static void Destroy(List<HardwareComponent> dump, string command)
        {
            if (dump.Any(h => h.Name == command))
            {
                HardwareComponent hardware = dump.Where(h => h.Name == command).First();
                dump.Remove(hardware);
            }
        }

        public static void DumpAnalyze(List<HardwareComponent> computer, List<HardwareComponent> dump)
        {
            Console.WriteLine("Dump Analysis");
            Console.WriteLine("Power Hardware Components: {0}", dump.Where(h => h is PowerHardwareComponent).Count());
            Console.WriteLine("Heavy Hardware Components: {0}", dump.Where(h => h is HeavyHardwareComponent). Count());

            Console.WriteLine("Express Software Components: {0}", dump.Select(h => h.SeeSoftware().Where(s => s is ExpressSoftwareComponent)).Count());
            Console.WriteLine("Light Software Components: {0}", dump.Select(h => h.SeeSoftware().Where(s => s is LightSoftwareComponent)).Count());

            long memory = 0;
            long capacity = 0;

            foreach (HardwareComponent hardware in dump)
            {
                memory += hardware.SeeSoftware().Select(s => s.MemoryConsumption).Sum();
                capacity += hardware.SeeSoftware().Select(s => s.CapacityConsumption).Sum();
            }

            Console.WriteLine("Total Dumped Memory: {0}", memory);
            Console.WriteLine("Total Dumped Capacity: {0}", capacity);
        }
    }
}
