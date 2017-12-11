using System;
using FastFood.Data;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using FastFood.Models;
using System.Xml.Linq;
using System.Globalization;
using FastFood.Models.Enums;
using FastFood.DataProcessor.Dto.Import;

namespace FastFood.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";


        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var result = new List<string>();

            var objects = JsonConvert.DeserializeAnonymousType(jsonString, new[] { new { Name = String.Empty, Age = 0, Position = String.Empty } });

            foreach (var obj in objects)
            {
                if (obj.Name == null || obj.Position == null || obj.Name.Length < 3 || obj.Name.Length > 30 || obj.Age < 15 || obj.Age > 80 || obj.Position.Length < 3 || obj.Position.Length > 30)
                {
                    result.Add(FailureMessage);
                    continue;
                }


                bool positionExists = context.Positions
                    .Any(p => p.Name == obj.Position);

                if (!positionExists)
                {
                    context.Positions.Add(new Position { Name = obj.Position });
                    context.SaveChanges();
                }

                var position = context.Positions.FirstOrDefault(p => p.Name == obj.Position);

                context.Employees.Add(new Employee { Age = obj.Age, Name = obj.Name, Position = position });
                context.SaveChanges();
                result.Add(String.Format(SuccessMessage, obj.Name));
            }

            return String.Join(Environment.NewLine, result);
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var result = new List<string>();

            var objects = JsonConvert.DeserializeAnonymousType(jsonString, new[] { new { Name = String.Empty, Price = 0.00m, Category = String.Empty } });

            foreach (var obj in objects)
            {
                bool itemExists = context.Items.Any(i => i.Name == obj.Name);

                if (itemExists || obj.Name.Length < 3 || obj.Name.Length > 30 || obj.Price < 0.01m || obj.Category.Length < 3 || obj.Category.Length > 30)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                bool categoryExists = context.Categories.Any(c => c.Name == obj.Category);

                if (!categoryExists)
                {
                    context.Categories.Add(new Category { Name = obj.Category });
                    context.SaveChanges();
                }

                var category = context.Categories.SingleOrDefault(c => c.Name == obj.Category);

                context.Items.Add(new Item { Category = category, Name = obj.Name, Price = obj.Price });
                context.SaveChanges();

                result.Add(String.Format(SuccessMessage, obj.Name));
            }

            return String.Join(Environment.NewLine, result);
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var result = new List<string>();

            XDocument xDoc = XDocument.Parse(xmlString);

            var elements = xDoc.Root.Elements();

            foreach (var o in elements)
            {
                var customer = o.Element("Customer")?.Value;
                var employeeName = o.Element("Employee")?.Value;
                var timeAsString = o.Element("DateTime")?.Value;
                var typeAsString = o.Element("Type")?.Value;

                if (customer == null || timeAsString == null || typeAsString == null || employeeName == null)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var employee = context.Employees.SingleOrDefault(e => e.Name == employeeName);

                if (employee == null)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var time = DateTime.ParseExact(timeAsString, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                object typeObj;
                var isTypeValid = Enum.TryParse(typeof(OrderType), typeAsString, out typeObj);

                if (!isTypeValid)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var type = (OrderType)typeObj;

                bool areItemsValid = true;
                var items = new List<ItemDto>();

                foreach (var i in o.Element("Items").Elements())
                {
                    string name = i.Element("Name")?.Value;
                    string quantityAsString = i.Element("Quantity")?.Value;

                    if (quantityAsString == null || name == null)
                    {
                        result.Add(FailureMessage);
                        areItemsValid = false;
                    }

                    int quantity = int.Parse(quantityAsString);

                    var item = context.Items.SingleOrDefault(it => it.Name == name);

                    if (item == null || quantity <= 0)
                    {
                        result.Add(FailureMessage);
                        areItemsValid = false;
                    }

                    items.Add(new ItemDto { Name = name, Quantity = quantity });
                }

                if (!areItemsValid)
                {
                    result.Add(FailureMessage);
                    continue;
                }

                var order = new Order { Customer = customer, DateTime = time, Employee = employee, Type = type };
                context.Orders.Add(order);

                foreach (var itemDto in items)
                {
                    var item = context.Items.SingleOrDefault(i => i.Name == itemDto.Name);
                    context.OrderItems.Add(new OrderItem { Item = item, Order = order, Quantity = itemDto.Quantity });
                }

                context.SaveChanges();

                result.Add($"Order for {customer} on {time.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} added");
            }

            return String.Join(Environment.NewLine, result);
        }
    }
}