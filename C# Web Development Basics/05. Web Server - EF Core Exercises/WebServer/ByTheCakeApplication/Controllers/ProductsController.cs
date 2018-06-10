namespace WebServer.ByTheCakeApplication.Controllers
{
    using Infrastructure;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using Services;
    using Services.Contracts;
    using System;
    using System.Linq;
    using ViewModels;
    using ViewModels.Products;

    public class ProductsController : Controller
    {
        private const string AddView = @"products\add";
        private const string SearchView = @"products\search";
        private const string DetailsView = @"products\details";

        private readonly IProductService productService;

        public ProductsController()
        {
            this.productService = new ProductService();
        }

        public IHttpResponse Add()
        {
            this.ViewData["showResult"] = "none";

            return this.FileViewResponse(AddView);
        }

        public IHttpResponse Add(IHttpRequest req, AddProductViewModel model)
        {
            // Validate Model
            if (string.IsNullOrWhiteSpace(model.Name) ||
                string.IsNullOrWhiteSpace(model.ImageUrl) ||
                model.Name.Length < 3 ||
                model.Name.Length > 30 ||
                model.ImageUrl.Length < 3 ||
                model.ImageUrl.Length > 2000 ||
                model.Price < 0)
            {
                this.AddError("Invalid product details");
                this.ViewData["showResult"] = "none";

                return this.FileViewResponse(AddView);
            }

            // Create Product in db
            this.productService.Create(model.Name, model.Price, model.ImageUrl);

            // Update View
            this.ViewData["showResult"] = "block";
            this.ViewData["name"] = model.Name;
            this.ViewData["price"] = model.Price.ToString("F2");
            this.ViewData["imageUrl"] = model.ImageUrl;

            return this.FileViewResponse(AddView);
        }

        public IHttpResponse Search(IHttpRequest req)
        {
            const string SearchTermKey = "searchTerm";

            this.ViewData["results"] = string.Empty;

            // Get searchTerm
            var urlParameters = req.UrlParameters;

            var searchTerm = urlParameters.ContainsKey(SearchTermKey)
                            ? urlParameters[SearchTermKey]
                            : null;

            this.ViewData["searchTerm"] = searchTerm;

            // Get products from db
            var result = this.productService.All(searchTerm);

            // List Products 
            if (!result.Any())
            {
                this.ViewData["results"] = "No cakes found";
            }
            else
            {
                var allProducts = result
                    .Select(p => $@"<div><a href=""/products/{p.Id}"">{p.Name}</a> - ${p.Price:F2} <a href=""/shopping/add/{p.Id}?{SearchTermKey}={searchTerm}"">Order</a></div>");

                this.ViewData["results"] = string.Join(Environment.NewLine, allProducts);
            }

            // View Shopping Cart
            this.ViewData["showCart"] = "none";

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (shoppingCart.ProductIds.Any())
            {
                var totalProducts = shoppingCart.ProductIds.Count;
                var totalProductsText = totalProducts != 1 ? "products" : "product";

                this.ViewData["showCart"] = "block";
                this.ViewData["products"] = $"{totalProducts} {totalProductsText}";
            }

            return this.FileViewResponse(SearchView);
        }

        public IHttpResponse Details(int id)
        {
            // Get product from db
            var product = this.productService.Find(id);

            if (product == null)
            {
                return new NotFoundResponse();
            }

            // Return View
            this.ViewData["name"] = product.Name;
            this.ViewData["price"] = product.Price.ToString("F2");
            this.ViewData["imageUrl"] = product.ImageUrl;

            return this.FileViewResponse(DetailsView);
        }
    }
}
