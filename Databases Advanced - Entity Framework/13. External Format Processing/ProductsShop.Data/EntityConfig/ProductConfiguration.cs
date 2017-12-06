using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsShop.Models;

namespace ProductsShop.Data.EntityConfig
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired(false);

            builder.HasOne(e => e.Buyer)
                .WithMany(u => u.ProductsBought)
                .HasForeignKey(e => e.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Seller)
                .WithMany(u => u.SellingProducts)
                .HasForeignKey(e => e.SellerId);
        }
    }
}
