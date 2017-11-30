namespace PhotoShare.Models
{
    public class AlbumRole
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public Role Role { get; set; }

        public override string ToString()
        {
            return $"{this.User.Username} - {this.Album.Name} - {this.Role}";
        }
    }
}
