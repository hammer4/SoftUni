namespace WebServer.ByTheCakeApplication.Services.Contracts
{
    using System.Collections.Generic;
    using ViewModels.Products;

    public interface IProductService
    {
        void Create(string name, decimal price, string imageUrl);

        IEnumerable<ProductListingViewModel> All(string searchTerm = null);

        ProductDetailsViewModel Find(int id);

        bool Exists(int id);

        IEnumerable<ProductInCartViewModel> FindProductsInCart(IEnumerable<int> ids);
    }
}
