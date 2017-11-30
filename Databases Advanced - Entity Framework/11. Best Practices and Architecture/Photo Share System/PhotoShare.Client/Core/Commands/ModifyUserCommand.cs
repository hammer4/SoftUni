namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;
    using PhotoShare.Services.Contracts;

    public class ModifyUserCommand : ICommand
    {
        private IUserSessionService userSessionService;
        private IUserService userService;

        public ModifyUserCommand(IUserSessionService userSessionService, IUserService userService)
        {
            this.userSessionService = userSessionService;
            this.userService = userService;
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string command, string[] data)
        {
            if(data.Length != 3)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!userSessionService.IsLoggedIn() || userSessionService.User.Username != data[0])
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var username = data[0];
            var property = data[1];
            var newValue = data[2];

            if(property != "Password" && property != "BornTown" && property != "CurrentTown")
            {
                throw new ArgumentException($"Property {property} not supported!");
            }

            var user = userService.ModifyUser(username, property, newValue);

            return $"User {user.Username} {property} is {newValue}.";
        }
    }
}
