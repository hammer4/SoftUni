namespace TeamBuilder.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TeamBuilder.Models;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Name).IsUnique();

            builder.Property(t => t.Name).HasMaxLength(25).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(32);
            builder.Property(t => t.Acronym).HasMaxLength(3).HasColumnType("CHAR(3)").IsRequired();

            builder
                .HasMany(t => t.Invitations)
                .WithOne(i => i.Team)
                .HasForeignKey(i => i.TeamId);
        }
    }
}
