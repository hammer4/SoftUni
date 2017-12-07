using Microsoft.EntityFrameworkCore;
using Stations.Models;

namespace Stations.Data
{
	public class StationsDbContext : DbContext
	{
		public StationsDbContext()
		{
		}

		public StationsDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<SeatingClass> SeatingClasses { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<CustomerCard> Cards { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainSeat> TrainSeats { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.TrainNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasIndex(e => e.TrainNumber)
                    .IsUnique();
            });

            modelBuilder.Entity<SeatingClass>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasIndex(e => e.Abbreviation)
                    .IsUnique();
            });

            modelBuilder.Entity<TrainSeat>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Train)
                    .WithMany(t => t.TrainSeats)
                    .HasForeignKey(e => e.TrainId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.SeatingClass)
                    .WithMany(sc => sc.TrainSeats)
                    .HasForeignKey(e => e.SeatingClassId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Quantity)
                    .IsRequired();
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.OriginStation)
                    .WithMany(s => s.TripsFrom)
                    .HasForeignKey(e => e.OriginStationId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.DestinationStation)
                    .WithMany(s => s.TripsTo)
                    .HasForeignKey(e => e.DestinationStationId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Train)
                    .WithMany(t => t.Trips)
                    .HasForeignKey(e => e.TrainId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Price)
                    .IsRequired();

                entity.Property(e => e.SeatingPlace)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.HasOne(e => e.Trip)
                    .WithMany(t => t.SoldTickets)
                    .HasForeignKey(e => e.TripId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.CustomerCard)
                    .WithMany(cc => cc.BoughtTickets)
                    .HasForeignKey(e => e.CustomerCardId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(false);
            });

            modelBuilder.Entity<CustomerCard>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });
		}
	}
}