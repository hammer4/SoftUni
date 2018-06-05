namespace HTTPServer.ByTheCakeApplication.Models
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        public const string SessionKey = "%^Current_Shopping_Cart^%";

        public List<Cake> Orders { get; private set; } = new List<Cake>();
    }
}
