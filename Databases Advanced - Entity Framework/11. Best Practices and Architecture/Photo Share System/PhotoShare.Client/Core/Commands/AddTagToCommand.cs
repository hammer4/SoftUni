namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;
    using PhotoShare.Services.Contracts;
    using Utilities;

    public class AddTagToCommand : ICommand
    {
        private IUserSessionService userSessionService;
        private IAlbumService albumService;

        public AddTagToCommand(IUserSessionService userSessionService, IAlbumService albumService)
        {
            this.userSessionService = userSessionService;
            this.albumService = albumService;
        }
        // AddTagTo <albumName> <tag>
        public string Execute(string command, string[] data)
        {
            if(data.Length != 2)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            string tagName = data[1].ValidateOrTransform();
            string albumName = data[0];

            this.albumService.AddTagToAlbum(albumName, tagName);

            return $"Tag {tagName} added to {albumName}!";
        }
    }
}
