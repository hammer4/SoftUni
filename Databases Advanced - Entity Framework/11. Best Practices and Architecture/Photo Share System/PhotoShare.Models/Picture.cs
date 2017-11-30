namespace PhotoShare.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }

        public string Path { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public int UserProfileId { get; set; }
        public User UserProfile { get; set; }

        public override string ToString()
        {
            return $"{this.Title} {this.Caption??string.Empty}";
        }
    }
}
