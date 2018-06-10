namespace WebServer.ByTheCakeApplication.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels.Products;

    public class ProductService : IProductService
    {
        public void Create(string name, decimal price, string imageUrl)
        {
            using (var context = new ByTheCakeDbContext())
            {
                var product = new Product
                {
                    Name = name,
                    Price = price,
                    ImageUrl = imageUrl
                };

                context.Add(product);
                context.SaveChanges();
            }
        }

        public IEnumerable<ProductListingViewModel> All(string searchTerm = null)
        {
            using (var context = new ByTheCakeDbContext())
            {
                var resultsQuery = context.Products.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    resultsQuery = resultsQuery
                        .Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()));
                }

                return resultsQuery
                       .Select(p => new ProductListingViewModel
                       {
                           Id = p.Id,
                           Name = p.Name,
                           Price = p.Price
                       })
                       .ToList();
            }
        }

        public ProductDetailsViewModel Find(int id)
        {
            using (var context = new ByTheCakeDbContext())
            {
                return context
                       .Products
                       .Where(p => p.Id == id)
                       .Select(p => new ProductDetailsViewModel
                       {
                           Name = p.Name,
                           Price = p.Price,
                           ImageUrl = p.ImageUrl
                       })
                       .FirstOrDefault();
            }
        }

        public bool Exists(int id)
        {
            using (var context = new ByTheCakeDbContext())
            {
                return context
                      .Products
                      .Any(p => p.Id == id);
            }
        }

        public IEnumerable<ProductInCartViewModel> FindProductsInCart(IEnumerable<int> ids)
        {
            using (var context = new ByTheCakeDbContext())
            {
                return context
                      .Products
                      .Where(p => ids.Contains(p.Id))
                      .Select(p => new ProductInCartViewModel
                      {
                          Name = p.Name,
                          Price = p.Price
                      })
                      .ToList();
            }
        }
    }
}
