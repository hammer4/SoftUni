namespace WebServer.ByTheCakeApplication.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels.Products;
    using ViewModels.Shopping;

    public class ShoppingService : IShoppingService
    {
        public void CreateOrder(int userId, IEnumerable<int> productIds)
        {
            using (var context = new ByTheCakeDbContext())
            {
                var order = new Order
                {
                    UserId = userId,
                    CreationDate = DateTime.UtcNow,
                    Products = productIds
                              .Select(id => new OrderProduct
                              {
                                  ProductId = id
                              })
                              .ToList()
                };

                context.Add(order);
                context.SaveChanges();
            }
        }

        public IEnumerable<OrdersListingViewModel> FindOrders(string username)
        {
            using (var context = new ByTheCakeDbContext())
            {
                return context
                      .Orders
                      .Where(o => o.User.Username == username)
                      .Select(o => new OrdersListingViewModel
                      {
                          Id = o.Id,
                          CreationDate = o.CreationDate,
                          TotalSum = o.Products
                                    .Where(op => op.OrderId == o.Id)
                                    .Select(op => op.Product)
                                    .Sum(p => p.Price)
                      })
                      .ToList();
            }
        }

        public OrderDetailsViewModel FindOrder(int id, string username)
        {
            using (var context = new ByTheCakeDbContext())
            {
                return context
                    .Orders
                    .Where(u => u.User.Username == username)
                    .Where(o => o.Id == id)
                    .Select(o => new OrderDetailsViewModel
                    {
                        Id = o.Id,
                        CreationDate = o.CreationDate,
                        Products = o.Products
                                   .Where(op => op.OrderId == id)
                                   .Select(op => new ProductListingViewModel
                                   {
                                       Id = op.ProductId,
                                       Name = op.Product.Name,
                                       Price = op.Product.Price
                                   })
                                   .ToList()
                    })
                    .FirstOrDefault();
            }
        }
    }
}
