namespace WebServer.ByTheCakeApplication
{
    using Controllers;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Server.Contracts;
    using Server.Routing.Contracts;
    using System;
    using ViewModels.Account;
    using ViewModels.Products;

    public class ByTheCakeApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig
                .Get(
                    "/",
                    req => new HomeController().Index());

            appRouteConfig
                .Get(
                    "/about",
                    req => new HomeController().About());

            // Calculator
            appRouteConfig
                .Get(
                    "/calculator",
                    req => new CalculatorController().Calculate());

            appRouteConfig
                .Post(
                    "calculator",
                    req => new CalculatorController().Calculate(
                        req.FormData["number1"],
                        req.FormData["number2"],
                        req.FormData["mathOperator"]));

            // Register
            appRouteConfig
                .Get(
                    "/register",
                    req => new AccountController().Register());

            appRouteConfig
                .Post(
                    "/register",
                    req => new AccountController().Register(
                        req,
                        new RegisterViewModel
                        {
                            Username = req.FormData["username"],
                            Password = req.FormData["password"],
                            ConfirmPassword = req.FormData["confirm-password"]
                        }));

            // Login
            appRouteConfig
                .Get(
                    "/login",
                    req => new AccountController().Login());

            appRouteConfig
                .Post(
                    "/login",
                    req => new AccountController().Login(
                        req,
                        new LoginViewModel
                        {
                            Username = req.FormData["username"],
                            Password = req.FormData["password"]
                        }));

            // Logout
            appRouteConfig
                .Post(
                    "/logout",
                    req => new AccountController().Logout(req));

            // Profile
            appRouteConfig
                .Get(
                    "/profile",
                    req => new AccountController().Profile(req));

            // Add Product
            appRouteConfig
                .Get(
                    "/add",
                    req => new ProductsController().Add());

            appRouteConfig
                .Post(
                    "/add",
                    req => new ProductsController().Add(
                        req,
                        new AddProductViewModel
                        {
                            Name = req.FormData["name"],
                            Price = decimal.Parse(req.FormData["price"]),
                            ImageUrl = req.FormData["imageUrl"]
                        }));

            // Browse Products
            appRouteConfig
                .Get(
                    "/search",
                    req => new ProductsController().Search(req));

            // Product Details
            appRouteConfig
                .Get(
                    "/products/{(?<id>[0-9]+)}",
                    req => new ProductsController().Details(int.Parse(req.UrlParameters["id"])));

            // Shopping Cart
            appRouteConfig
                .Get(
                    "/shopping/add/{(?<id>[0-9]+)}",
                    req => new ShoppingController().AddToCart(req));

            appRouteConfig
                .Get(
                    "/cart",
                    req => new ShoppingController().ShowCart(req));

            appRouteConfig
                .Post(
                    "/shopping/finish-order",
                    req => new ShoppingController().FinishOrder(req));

            // My Orders
            appRouteConfig
                .Get(
                    "/orders",
                    req => new ShoppingController().ShowOrders(req));

            // Order Details
            appRouteConfig
                .Get(
                    "/orders/{(?<id>[0-9]+)}",
                    req => new ShoppingController().OrderDetails(
                        req,
                        int.Parse(req.UrlParameters["id"])));
        }

        public void InitializeDatabase()
        {
            Console.WriteLine("Initializing database...");

            using (var context = new ByTheCakeDbContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
