namespace PhotoShare.Client.Core.Commands
{
    using Commands.Contracts;
    using PhotoShare.Services.Contracts;
    using System;

    public class AddTownCommand : ICommand
    {
        private IUserSessionService userSessionService;
        private ITownService townService;

        public AddTownCommand(IUserSessionService userSessionService, ITownService townService)
        {
            this.userSessionService = userSessionService;
            this.townService = townService;
        }

        // AddTown <townName> <countryName>
        public string Execute(string command, string[] data)
        {
            if(data.Length != 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!this.userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            string townName = data[0];
            string country = data[1];

            var town = this.townService.Create(townName, country);

            return $"Town {townName} was added successfully!";
        }
    }
}
