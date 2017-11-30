namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;
    using PhotoShare.Services.Contracts;
    using System.Linq;

    public class ListFriendsCommand : ICommand
    {
        private IFriendshipService friendshipService;

        public ListFriendsCommand(IFriendshipService friendshipService)
        {
            this.friendshipService = friendshipService;
        }
        // PrintFriendsList <username>
        public string Execute(string command, string[] data)
        {
            if(data.Length != 1)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string username = data[0];

            var friends = friendshipService.ListFriends(username).Select(f => $"-[{f}]");

            return friends.Count() == 0 ? "No friends for this user. :(" :
                $"Friends:{Environment.NewLine}{String.Join(Environment.NewLine, friends)}";
        }
    }
}
