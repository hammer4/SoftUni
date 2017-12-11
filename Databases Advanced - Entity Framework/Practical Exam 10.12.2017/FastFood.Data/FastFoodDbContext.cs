using Microsoft.EntityFrameworkCore;
using FastFood.Models;

namespace FastFood.Data
{
	public class FastFoodDbContext : DbContext
	{
		public FastFoodDbContext()
		{
		}

		public FastFoodDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (!builder.IsConfigured)
			{
				builder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            builder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Items)
                    .HasForeignKey(e => e.CategoryId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Price)
                    .IsRequired();
            });

            builder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });

            builder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Age)
                    .IsRequired();

                entity.HasOne(e => e.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(e => e.PositionId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Customer)
                    .IsRequired();

                entity.Property(e => e.DateTime)
                    .IsRequired();

                entity.Property(e => e.Type)
                    .IsRequired();

                entity.Ignore(e => e.TotalPrice);

                entity.HasOne(e => e.Employee)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.EmployeeId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ItemId });

                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(e => e.OrderId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Item)
                    .WithMany(i => i.OrderItems)
                    .HasForeignKey(e => e.ItemId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Quantity)
                    .IsRequired();
            });
		}
	}
}