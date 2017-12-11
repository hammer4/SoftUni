using System;
using System.IO;
using FastFood.Data;
using FastFood.Models.Enums;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using FastFood.DataProcessor.Dto.Export;
using System.Xml.Linq;
using System.Collections.Generic;

namespace FastFood.DataProcessor
{
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            OrderType type = (OrderType)Enum.Parse(typeof(OrderType), orderType);

            var orders = context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .Where(o => o.Employee.Name == employeeName)
                .Select(o => new
                {
                    o.Customer,
                    Items = o.OrderItems
                        .Select(oi => new
                        {
                            oi.Item.Name,
                            oi.Item.Price,
                            oi.Quantity
                        }),
                    TotalPrice = o.OrderItems
                        .Sum(oi => oi.Quantity * oi.Item.Price)
                })
                .OrderByDescending(o => o.TotalPrice)
                .ThenByDescending(o => o.Items.Count())
                .ToList();

            var result = new
            {
                Name = employeeName,
                Orders = orders,
                TotalMade = orders.Sum(o => o.TotalPrice)
            };

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            string[] catArray = categoriesString.Split(',');
            var categoriesArr = context.Categories
                .Include(c => c.Items)
                .ThenInclude(i => i.OrderItems)
                .Where(c => catArray.Contains(c.Name))
                .ToArray();


            var categories = new List<CategoryDto>();
            foreach (var c in categoriesArr)
            {
                var name = c.Name;

                var mostPopularItem = c.Items
                            .OrderByDescending(i => i.OrderItems.Sum(oi => oi.Quantity * i.Price))
                            .First();
                var itemName = mostPopularItem
                            .Name;
                var totalMade = mostPopularItem
                            .OrderItems
                            .Sum(oi => oi.Quantity * oi.Item.Price);
                var timesSold = mostPopularItem
                            .OrderItems
                            .Sum(oi => oi.Quantity);

                categories.Add(new CategoryDto { Name = name, ItemName = itemName, TimesSold = timesSold, TotalMade = totalMade });
            };

            categories = categories
                .OrderByDescending(c => c.TotalMade)
                .ThenByDescending(c => c.TimesSold)
                .ToList();

            var xDoc = new XDocument();
            xDoc.Add(new XElement("Categories"));

            foreach (var c in categories)
            {
                var category = new XElement("Category");

                category.Add(new XElement("Name", c.Name));
                var mostPop = new XElement("MostPopularItem");

                mostPop.Add(new XElement("Name", c.ItemName));
                mostPop.Add(new XElement("TotalMade", c.TotalMade));
                mostPop.Add(new XElement("TimesSold", c.TimesSold));

                category.Add(mostPop);
                xDoc.Element("Categories").Add(category);
            }

            return xDoc.ToString();
        }
    }
}