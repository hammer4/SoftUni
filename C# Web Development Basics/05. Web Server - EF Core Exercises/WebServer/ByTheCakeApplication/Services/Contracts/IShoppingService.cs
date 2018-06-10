namespace WebServer.ByTheCakeApplication.Services.Contracts
{
    using System.Collections.Generic;
    using ViewModels.Shopping;

    public interface IShoppingService
    {
        void CreateOrder(int userId, IEnumerable<int> productIds);

        IEnumerable<OrdersListingViewModel> FindOrders(string username);

        OrderDetailsViewModel FindOrder(int id, string username);
    }
}
