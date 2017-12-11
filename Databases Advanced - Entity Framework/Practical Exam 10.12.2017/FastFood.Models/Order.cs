using System;
using System.Collections.Generic;
using System.Text;
using FastFood.Models.Enums;
using System.Linq;

namespace FastFood.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime DateTime { get; set; }
        public OrderType Type { get; set; }
        public decimal TotalPrice
        {
            get
            {
                if(this.OrderItems.Count > 0)
                {
                    return this.OrderItems
                        .Select(oi => oi.Item.Price * oi.Quantity).Sum();
                }

                return 0;
            }
        }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
