using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DataProcessor.Dto.Export
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string ItemName { get; set; }
        public decimal TotalMade { get; set; }
        public int TimesSold { get; set; }
    }
}
