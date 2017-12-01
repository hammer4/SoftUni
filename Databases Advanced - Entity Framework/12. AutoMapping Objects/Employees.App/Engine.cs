using System;
using System.Linq;
using Employees.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.App
{
    public class Engine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var databaseInitializerService = serviceProvider.GetService<DatabaseInitializerService>();
            databaseInitializerService.InitializeDatabase();

            var commandParser = new CommandParser(serviceProvider);

            while (true)
            {
                var input = Console.ReadLine();

                var commandTokens = input.Split(' ');

                var commandName = commandTokens.First();

                var commandArgs = commandTokens.Skip(1).ToArray();

                try
                {
                    var command = commandParser.ParseCommand(commandName);

                    var result = command.Execute(commandArgs);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
