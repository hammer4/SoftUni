namespace BookShop.Data
{
    using Microsoft.EntityFrameworkCore;

    using BookShop.Models;
    using BookShop.Data.EntityConfiguration;

    public class BookShopContext : DbContext
    {
		public BookShopContext() { }

		public BookShopContext(DbContextOptions options)
			:base(options) { }
		
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new AuthorConfiguration());

            modelBuilder.ApplyConfiguration(new BookCategoryConfiguration());
        }
    }
}
