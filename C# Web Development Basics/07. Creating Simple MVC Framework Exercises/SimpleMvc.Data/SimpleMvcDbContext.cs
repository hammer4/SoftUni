using Microsoft.EntityFrameworkCore;
using SimpleMvc.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.Data
{
    public class SimpleMvcDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = SimpleMvcDb; Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(u => u.Id);
                user.Property(u => u.Username).IsRequired();
                user.HasIndex(u => u.Username).IsUnique();
                user.Property(u => u.Password).IsRequired();
            });

            modelBuilder.Entity<Note>(note =>
            {
                note.HasKey(n => n.Id);
                note.HasOne(n => n.Owner)
                    .WithMany(u => u.Notes)
                    .HasForeignKey(n => n.OwnerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
