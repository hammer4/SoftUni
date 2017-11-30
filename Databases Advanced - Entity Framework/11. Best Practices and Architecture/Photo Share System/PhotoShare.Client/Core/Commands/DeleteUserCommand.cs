namespace PhotoShare.Client.Core.Commands
{
    using System;
    using PhotoShare.Services.Contracts;
    using Contracts;

    public class DeleteUserCommand : ICommand
    {
        private IUserSessionService userSessionService;
        private IUserService userService;

        public DeleteUserCommand(IUserSessionService userSessionService, IUserService userService)
        {
            this.userService = userService;
            this.userSessionService = userSessionService;
        }

        // DeleteUser <username>
        public string Execute(string command, string[] data)
        {
            if(data.Length != 1)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if(!userSessionService.IsLoggedIn() || userSessionService.User.Username != data[0])
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var username = data[0];

            this.userService.Delete(username);

            return $"User {username} was deleted successfully!";
        }
    }
}
