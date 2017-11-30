namespace PhotoShare.Client.Core
{
    using System;
    using PhotoShare.Services.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    public class Engine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var databaseInitializerService = serviceProvider.GetService<IDatabaseInitializerService>();
            databaseInitializerService.InitializeDatabase();

            var commandDispatcher = new CommandDispatcher(this.serviceProvider);

            while (true)
            {
                var input = Console.ReadLine();

                var commandTokens = input.Split();

                var commandName = commandTokens.First();

                var commandArgs = commandTokens.Skip(1).ToArray();

                try
                {
                    var command = commandDispatcher.ParseCommand(commandName);

                    var result = command.Execute(commandName, commandArgs);

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
