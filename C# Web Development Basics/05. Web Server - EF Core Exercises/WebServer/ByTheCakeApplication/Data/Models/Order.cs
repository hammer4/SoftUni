namespace WebServer.ByTheCakeApplication.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<OrderProduct> Products { get; set; } = new List<OrderProduct>();
    }
}
