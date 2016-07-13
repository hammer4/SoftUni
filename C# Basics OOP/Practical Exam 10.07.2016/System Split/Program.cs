using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Split
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<HardwareComponent> computer = new List<HardwareComponent>();
            List<HardwareComponent> dump = new List<HardwareComponent>();
            
            while (command != "System Split")
            {
                string[] tokens = command.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToArray();
                switch(tokens[0])
                {
                    case "RegisterPowerHardware": CommandExecutor.RegisterPowerHardware(computer, tokens[1]); break;
                    case "RegisterHeavyHardware": CommandExecutor.RegisterHeavyHardware(computer, tokens[1]); break;
                    case "RegisterExpressSoftware": CommandExecutor.RegisterExpressSoftware(computer, tokens[1]); break;
                    case "RegisterLightSoftware": CommandExecutor.RegisterLightSoftware(computer, tokens[1]); break;
                    case "ReleaseSoftwareComponent": CommandExecutor.ReleaseSoftwareComponent(computer, tokens[1]); break;
                    case "Analyze": CommandExecutor.Analyze(computer); break;
                    case "Dump": CommandExecutor.Dump(computer, dump, tokens[1]); break;
                    case "Restore": CommandExecutor.Restore(computer, dump, tokens[1]); break;
                    case "Destroy": CommandExecutor.Destroy(dump, tokens[1]); break;
                    case "DumpAnalyze": CommandExecutor.DumpAnalyze(computer, dump); break;
                }

                command = Console.ReadLine();
            }

            CommandExecutor.SystemSplit(computer);
        }
    }
}
