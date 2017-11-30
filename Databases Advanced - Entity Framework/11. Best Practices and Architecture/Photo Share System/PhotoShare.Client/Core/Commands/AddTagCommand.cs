namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Contracts;
    using PhotoShare.Services.Contracts;
    using Utilities;
    using System;

    public class AddTagCommand : ICommand
    {
        private IAlbumService albumService;
        private IUserSessionService userSessionService;

        public AddTagCommand(IAlbumService albumService, IUserSessionService userSessionService)
        {
            this.albumService = albumService;
            this.userSessionService = userSessionService;
        }

        // AddTag <tag>
        public string Execute(string command, string[] data)
        {
            if(data.Length != 1)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            string name = data[0].ValidateOrTransform();

            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var tag = this.albumService.CreateTag(name);

            return $"Tag {tag.Name} was added successfully!";
        }
    }
}
