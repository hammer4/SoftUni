using System;
using PhotoShare.Client.Core.Commands.Contracts;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Client.Core.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IUserSessionService userSessionService;

        public LoginCommand(IUserService userService, IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.userSessionService = userSessionService;
        }

        public string Execute(string command, string[] data)
        {
            if (data.Length != 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (this.userSessionService.IsLoggedIn())
            {
                throw new ArgumentException("You should logout first!");
            }

            var username = data[0];
            var password = data[1];

            var user = this.userService.Login(username, password);

            return $"User {user.Username} successfully logged in!";
        }
    }
}
