namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;
    using PhotoShare.Services.Contracts;

    public class UploadPictureCommand : ICommand
    {
        private IAlbumService albumService;
        private IUserSessionService userSessionService;

        public UploadPictureCommand(IAlbumService albumService, IUserSessionService userSessionService)
        {
            this.albumService = albumService;
            this.userSessionService = userSessionService;
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string command, string[] data)
        {
            if (data.Length != 3)
            {
                throw new InvalidOperationException($"Command {command} not valid!");
            }

            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            string albumName = data[0];
            string pictureTitle = data[1];
            string picturePath = data[2];

            albumService.AddPicture(albumName, pictureTitle, picturePath);

            return $"Picture {pictureTitle} added to {albumName}!";
        }
    }
}
