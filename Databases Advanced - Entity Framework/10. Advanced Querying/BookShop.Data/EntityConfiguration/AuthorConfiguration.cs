namespace BookShop.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;

    using BookShop.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(e => e.AuthorId);

            builder.Property(e => e.FirstName)
                .IsRequired(false)
                .IsUnicode(true)
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);
        }
    }
}
