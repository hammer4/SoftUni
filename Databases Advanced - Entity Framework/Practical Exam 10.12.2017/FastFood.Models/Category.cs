using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
