namespace PhotoShare.Models
{
    using System.Collections.Generic;

    using PhotoShare.Models.Validation;

    public class Tag
    {
        private ICollection<AlbumTag> albumTags;

        public Tag()
        {
            this.albumTags = new HashSet<AlbumTag>();
        }

        public int Id { get; set; }

        [Tag]
        public string Name { get; set; }

        public ICollection<AlbumTag> AlbumTags
        {
            get { return this.albumTags; }
            set { this.albumTags = value; }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
