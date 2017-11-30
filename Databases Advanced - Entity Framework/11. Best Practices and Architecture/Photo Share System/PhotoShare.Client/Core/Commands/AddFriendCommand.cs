namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;
    using PhotoShare.Services.Contracts;

    public class AddFriendCommand : ICommand
    {
        private IUserSessionService userSessionService;
        private IFriendshipService friendshipService;

        public AddFriendCommand(IUserSessionService userSessionService, IFriendshipService friendshipService)
        {
            this.userSessionService = userSessionService;
            this.friendshipService = friendshipService;
        }
        // AddFriend <username1> <username2>
        public string Execute(string command, string[] data)
        {
            if(data.Length != 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!userSessionService.IsLoggedIn() || userSessionService.User.Username != data[0])
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            string userUsername = data[0];
            string friendUsername = data[1];

            friendshipService.AddFriend(userUsername, friendUsername);

            return $"Friend {friendUsername} added to {userUsername}";
        }
    }
}
