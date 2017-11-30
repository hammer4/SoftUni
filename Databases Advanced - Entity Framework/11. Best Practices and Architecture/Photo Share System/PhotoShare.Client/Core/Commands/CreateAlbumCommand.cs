namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;
    using PhotoShare.Services.Contracts;
    using Utilities;
    using System.Linq;

    public class CreateAlbumCommand : ICommand
    {
        private IAlbumService albumService;
        private IUserSessionService userSessionService;

        public CreateAlbumCommand(IAlbumService albumService, IUserSessionService userSessionService)
        {
            this.albumService = albumService;
            this.userSessionService = userSessionService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string command, string[] data)
        {
            if(data.Length < 3)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!userSessionService.IsLoggedIn() || userSessionService.User.Username != data[0])
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var username = data[0];
            var albumTitle = data[1];
            var color = data[2];
            var tags = data.Skip(3).Select(t => t.ValidateOrTransform()).ToArray();

            var album = albumService.CreateAlbum(username, albumTitle, color, tags);

            return $"Album {album.Name} successfully created!";
        }
    }
}
