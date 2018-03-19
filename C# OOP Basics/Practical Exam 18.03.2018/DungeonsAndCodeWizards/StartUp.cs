using System;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
            var master = new DungeonMaster();

            while (true)
            {
                var input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    var builder = new StringBuilder();
                    builder.AppendLine("Final stats:");
                    builder.Append(master.GetStats());
                    Console.WriteLine(builder.ToString().Trim());
                    return;
                }

                string[] command = input.Split();
                var arguments = command.Skip(1).ToArray();

                try
                {
                    switch (command[0])
                    {
                        case "JoinParty":
                            Console.WriteLine(master.JoinParty(arguments));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(master.AddItemToPool(arguments));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(master.PickUpItem(arguments));
                            break;
                        case "UseItem":
                            Console.WriteLine(master.UseItem(arguments));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(master.UseItemOn(arguments));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(master.GiveCharacterItem(arguments));
                            break;
                        case "GetStats":
                            Console.WriteLine(master.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(master.Attack(arguments));
                            break;
                        case "Heal":
                            Console.WriteLine(master.Heal(arguments));
                            break;
                        case "EndTurn":
                            Console.WriteLine(master.EndTurn(arguments));
                            if (master.IsGameOver())
                            {
                                var builder = new StringBuilder();
                                builder.AppendLine("Final stats:");
                                builder.Append((master.GetStats()));
                                Console.WriteLine(builder.ToString().Trim());
                                return;
                            }
                            break;
                        case "IsGameOver":
                            Console.WriteLine(master.IsGameOver());
                            break;
                    }
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine($"Parameter Error: {ae.Message}");
                }
                catch(InvalidOperationException ioe)
                {
                    Console.WriteLine($"Invalid Operation: {ioe.Message}");
                }
            }
		}
	}
}