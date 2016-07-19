namespace Entity_Framework_Exercises
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogDbContext : DbContext
    {
        public BlogDbContext()
            : base("name=BlogDbContext")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Posts)
                .Map(m => m.ToTable("PostsTags").MapLeftKey("PostId").MapRightKey("TagId"));

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.AuthorId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.AuthorId);
        }
    }
}
