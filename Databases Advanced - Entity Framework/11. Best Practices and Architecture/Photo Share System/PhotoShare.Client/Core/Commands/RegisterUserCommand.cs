namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;
    using PhotoShare.Services.Contracts;

    public class RegisterUserCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IUserSessionService userSessionService;

        public RegisterUserCommand(IUserService userService, IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.userSessionService = userSessionService;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string command, string[] data)
        {
            if (data.Length != 4)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (this.userSessionService.IsLoggedIn())
            {
                throw new ArgumentException("You should logout first!");
            }

            var username = data[0];
            var password = data[1];
            var confirmPassword = data[2];
            var email = data[3];

            var user = userService.Create(username, password, confirmPassword, email);

            return "User " + user.Username + " was registered successfully!";
        }
    }
}
