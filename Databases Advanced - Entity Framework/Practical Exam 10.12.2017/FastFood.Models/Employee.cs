using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Models
{
	public class Employee
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}