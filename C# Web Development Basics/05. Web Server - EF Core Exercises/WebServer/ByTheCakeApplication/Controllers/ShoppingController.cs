namespace WebServer.ByTheCakeApplication.Controllers
{
    using Infrastructure;
    using Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using Services;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ViewModels;
    using ViewModels.Shopping;

    public class ShoppingController : Controller
    {
        private readonly IProductService productService;
        private readonly IShoppingService shoppingService;
        private readonly IUserService userService;

        public ShoppingController()
        {
            this.productService = new ProductService();
            this.shoppingService = new ShoppingService();
            this.userService = new UserService();
        }

        public IHttpResponse AddToCart(IHttpRequest req)
        {
            var id = int.Parse(req.UrlParameters["id"]);

            // Validate product
            var productExists = this.productService.Exists(id);

            if (!productExists)
            {
                return new NotFoundResponse();
            }

            // Add Product to Shopping cart
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            shoppingCart.ProductIds.Add(id);

            // Redirect
            var redirectUrl = "/search";

            const string searchTermKey = "searchTerm";

            if (req.UrlParameters.ContainsKey(searchTermKey))
            {
                redirectUrl = $"{redirectUrl}?{searchTermKey}={req.UrlParameters[searchTermKey]}";
            }

            return new RedirectResponse(redirectUrl);
        }

        public IHttpResponse ShowCart(IHttpRequest req)
        {
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (!shoppingCart.ProductIds.Any())
            {
                this.ViewData["cartItems"] = "No items in your cart";
                this.ViewData["totalCost"] = "0.00";
            }
            else
            {
                var productIds = shoppingCart.ProductIds;

                var productsInCart = this.productService.FindProductsInCart(productIds);

                var items = productsInCart
                            .Select(p => $"<div>{p.Name} - ${p.Price:F2}</div><br />");

                var totalPrice = productsInCart.Sum(p => p.Price);

                this.ViewData["cartItems"] = string.Join(string.Empty, items);
                this.ViewData["totalCost"] = $"{totalPrice:F2}";
            }

            return this.FileViewResponse(@"shopping\cart");
        }

        public IHttpResponse FinishOrder(IHttpRequest req)
        {
            // Get User
            var username = req.Session.Get<string>(SessionStore.CurrentUserKey);

            var userId = this.userService.GetUserId(username);
            if (userId == null)
            {
                throw new InvalidOperationException($"User {username} does not exist");
            }

            // Get Products in Shopping cart
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            var productIds = shoppingCart.ProductIds;
            if (!productIds.Any())
            {
                return new RedirectResponse("/");
            }

            // Save Order in db
            this.shoppingService.CreateOrder(userId.Value, productIds);

            // Clear Shopping Cart
            shoppingCart.ProductIds.Clear();

            // View
            return this.FileViewResponse(@"shopping\finish-order");
        }

        public IHttpResponse ShowOrders(IHttpRequest req)
        {
            // Get Current User
            var username = req.Session.Get<string>(SessionStore.CurrentUserKey);

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new InvalidOperationException($"User {username} does not exist");
            }

            // Get Orders from db
            var orders = this.shoppingService.FindOrders(username);

            // Create orders table
            if (!orders.Any())
            {
                this.ViewData["result"] = "No orders";
            }
            else
            {
                this.ViewData["result"] = CreateOrdersListingHtml(orders);
            }

            return this.FileViewResponse(@"shopping\orders");
        }

        public IHttpResponse OrderDetails(IHttpRequest req, int id)
        {
            // Get current user
            var username = req.Session.Get<string>(SessionStore.CurrentUserKey);

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new InvalidOperationException($"User {username} does not exist");
            }

            // Get order from db (allow access to order only if created by current user)
            var order = this.shoppingService.FindOrder(id, username);
            if (order == null ||
                !order.Products.Any())
            {
                return new NotFoundResponse();
            }

            // Return View
            this.ViewData["id"] = order.Id.ToString();
            this.ViewData["creationDate"] = order.CreationDate.ToShortDateString();
            this.ViewData["products"] = CreateProductsListingHtml(order);

            return this.FileViewResponse(@"shopping\order-details");
        }

        private string CreateProductsListingHtml(OrderDetailsViewModel order)
        {
            var productsBuilder = new StringBuilder();

            foreach (var product in order.Products)
            {
                productsBuilder
                   .AppendLine("<tr>")
                        .AppendLine($@"<td><a href=""/products/{product.Id}"">{product.Name}</a></td>")
                        .AppendLine($"<td style=\"text-align: right\">$ {product.Price:F2}</td>")
                    .AppendLine("</tr>");
            }

            return productsBuilder.ToString();
        }

        private string CreateOrdersListingHtml(IEnumerable<OrdersListingViewModel> result)
        {
            var tableBuilder = new StringBuilder();

            tableBuilder
                .AppendLine($@"<table border=""1"">")
                .AppendLine("<tr style=\"background-color: lightgrey\">")
                    .AppendLine("<th>Order Id</th>")
                    .AppendLine("<th>Created On</th>")
                    .AppendLine("<th>Sum</th>")
                .AppendLine("</tr>");

            foreach (var order in result)
            {
                tableBuilder
                    .AppendLine("<tr>")
                        .AppendLine($@"<td><a href=""/orders/{order.Id}"">{order.Id}</a></td>")
                        .AppendLine($"<td>{order.CreationDate.ToShortDateString()}</td>")
                        .AppendLine($"<td style=\"text-align: right\">$ {order.TotalSum:F2}</td>")
                    .AppendLine("</tr>");
            }

            tableBuilder.AppendLine("</table>");

            return tableBuilder.ToString();
        }
    }
}
