namespace BookShop.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;

    using BookShop.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.BookId);

            builder.Property(e => e.Title)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(1000);

            builder.Property(e => e.ReleaseDate)
                .IsRequired(false);

            builder.HasOne(e => e.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(e => e.AuthorId);
        }
    }
}
