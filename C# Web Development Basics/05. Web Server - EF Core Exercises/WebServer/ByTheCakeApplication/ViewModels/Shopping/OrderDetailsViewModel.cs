namespace WebServer.ByTheCakeApplication.ViewModels.Shopping
{
    using System;
    using System.Collections.Generic;
    using Products;

    public class OrderDetailsViewModel
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<ProductListingViewModel> Products { get; set; } = new List<ProductListingViewModel>();
    }
}
