namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;
    using PhotoShare.Services.Contracts;

    public class ShareAlbumCommand : ICommand
    {
        private IAlbumService albumService;
        private IUserSessionService userSessionService;

        public ShareAlbumCommand(IAlbumService albumService, IUserSessionService userSessionService)
        {
            this.albumService = albumService;
            this.userSessionService = userSessionService;
        }
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string command, string[] data)
        {
            int albumId;

            if (data.Length != 3 || !int.TryParse(data[0], out albumId))
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            string username = data[1];
            string permission = data[2];

            string albumName = albumService.ShareAlbum(albumId, username, permission);

            return $"Username {username} added to album {albumName} ({permission})";
        }
    }
}
