namespace PhotoShare.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Caption)
                .HasMaxLength(250);

            builder.Property(e => e.Path)
                .IsRequired(true);

            builder.HasOne(e => e.Album)
                .WithMany(a => a.Pictures)
                .HasForeignKey(e => e.AlbumId);

            builder.Ignore(e => e.UserProfileId);
        }
    }
}
