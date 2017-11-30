using PhotoShare.Models;

namespace PhotoShare.Services.Contracts
{
    public interface IAlbumService
    {
        Tag CreateTag(string name);

        Album CreateAlbum(string username, string albumTitle, string color, string[] tags);

        Tag TagByName(string name);

        Album AlbumByName(string name);

        void AddTagToAlbum(string albumName, string tagName);

        string ShareAlbum(int albumId, string username, string permission);

        void AddPicture(string albumName, string pictureTitle, string picturePath);
    }
}
