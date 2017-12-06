using System;
using ProductsShop.Data;
using ProductsShop.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ProductsShop.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(Console.BufferWidth, 2000);

            using (var context = new ProductsShopContext())
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //XML
                //SeedXML(context);
                //ProductsInRange(context);
                //SoldProductsXML(context);
                //CategoriesByProductCount(context);
                UsersAndProductsXML(context);

                //JSON
                //SeedJson(context);
                //var productsInRange = GetProductsInRange(context);
                //Console.WriteLine(productsInRange);
                //var soldProducts = SoldProducts(context);
                //Console.WriteLine(soldProducts);
                //var categories = CategoriesInfo(context);
                //Console.WriteLine(categories);
                //var usersAndProducts = UsersAndProducts(context);
                //Console.WriteLine(usersAndProducts);
            }
        }

        private static void UsersAndProductsXML(ProductsShopContext context)
        {
            var users = context.Users
                .Where(u => u.SellingProducts.Count > 0)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.SellingProducts.Count,
                        products = u.SellingProducts
                            .Select(sp => new
                            {
                                name = sp.Name,
                                price = sp.Price
                            })
                            .ToArray()
                    }
                })
                .OrderByDescending(o => o.soldProducts.count)
                .ThenBy(o => o.lastName)
                .ToArray();

            var xDoc = new XDocument();
            xDoc.Add(new XElement("users"));
            xDoc.Element("users").SetAttributeValue("count", users.Count());

            foreach(var u in users)
            {
                var user = new XElement("user");
                user.SetAttributeValue("first-name", u.firstName);
                user.SetAttributeValue("last-name", u.lastName);
                user.SetAttributeValue("age", u.age);

                var soldProducts = new XElement("sold-products");
                soldProducts.SetAttributeValue("count", u.soldProducts.count);

                foreach(var p in u.soldProducts.products)
                {
                    var product = new XElement("product", new XAttribute("name", p.name), new XAttribute("price", p.price));

                    soldProducts.Add(product);
                }

                user.Add(soldProducts);

                xDoc.Element("users").Add(user);
            }

            xDoc.Save("XML/UsersAndProducts.xml");
        }

        private static void CategoriesByProductCount(ProductsShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                    {
                        category = c.Name,
                        productsCount = c.CategoryProducts
                            .Select(cp => cp.Product)
                            .Count(),
                        averagePrice = c.CategoryProducts
                            .Select(cp => cp.Product)
                            .Average(p => p.Price),
                        totalRevenue = c.CategoryProducts
                            .Select(cp => cp.Product)
                            .Sum(p => p.Price)
                    })
                .OrderByDescending(c => c.productsCount);

            var xDoc = new XDocument();
            xDoc.Add(new XElement("categories"));

            foreach(var c in categories)
            {
                var category = new XElement("category", new XAttribute("name", c.category));
                category.Add(new XElement("products-count", c.productsCount), new XElement("average-price", c.averagePrice), new XElement("total-revenue", c.totalRevenue));

                xDoc.Element("categories").Add(category);
            }

            xDoc.Save("XML/CategoriesByProducts.xml");
        }

        private static void SoldProductsXML(ProductsShopContext context)
        {
            var users = context.Users
                .Where(u => u.SellingProducts.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.SellingProducts
                        .Select(sp => new
                        {
                            name = sp.Name,
                            price = sp.Price
                        })
                });

            var xDoc = new XDocument();
            xDoc.Add(new XElement("users"));

            foreach(var u in users)
            {
                var user = new XElement("user");
                user.SetAttributeValue("first-name", u.FirstName);
                user.SetAttributeValue("last-name", u.LastName);

                var products = new XElement("sold-products");

                foreach(var p in u.SoldProducts)
                {
                    var product = new XElement("product");
                    product.Add(new XElement("name", p.name), new XElement("price", p.price));
                    products.Add(product);
                }

                user.Add(products);

                xDoc.Element("users").Add(user);
            }

            xDoc.Save("XML/SoldProducts.xml");
        }

        private static void ProductsInRange(ProductsShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.Buyer != null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .ToList();

            var xDoc = new XDocument();
            xDoc.Add(new XElement("products"));

            foreach(var product in products)
            {
                xDoc.Element("products")
                    .Add(new XElement("product", new XAttribute("name", product.name), new XAttribute("price", product.price), new XAttribute("buyer", product.buyer)));
            }

            xDoc.Save("XML/ProductsInRange.xml");
        }

        private static void SeedXML(ProductsShopContext context)
        {
            var users = GetUsersFromXml();
            context.Users.AddRange(users);

            var categories = GetCategoriesXml();
            context.Categories.AddRange(categories);

            var products = GetProductsXml(context);
            context.Products.AddRange(products);

            var categoryProducts = CreateCategoryProducts(context);
            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();
        }

        private static List<Product> GetProductsXml(ProductsShopContext context)
        {
            XDocument xDoc = XDocument.Load("Import/products.xml");
            var elements = xDoc.Root.Elements();

            var products = new List<Product>();
            var users = context.Users.ToArray();
            var rnd = new Random();

            foreach(var element in elements)
            {
                var name = element.Element("name").Value;
                var price = decimal.Parse(element.Element("price").Value);

                Product product = new Product
                {
                    Name = name,
                    Price = price
                };

                var seller = users[rnd.Next(0, users.Length)];
                product.Seller = seller;

                var buyerId = rnd.Next(0, users.Length + (int)(users.Length * 0.3));
                product.Buyer = buyerId < users.Length ? users[buyerId] : null;

                products.Add(product);
            }

            return products;
        }

        private static List<Category> GetCategoriesXml()
        {
            XDocument xDoc = XDocument.Load("Import/categories.xml");
            var elements = xDoc.Root.Elements();

            var categories = new List<Category>();

            foreach(var element in elements)
            {
                var name = element.Element("name").Value;

                categories.Add(new Category
                {
                    Name = name
                });
            }

            return categories;
        }

        private static List<User> GetUsersFromXml()
        {
            XDocument xDoc = XDocument.Load("Import/users.xml");
            var elements = xDoc.Root.Elements();

            var users = new List<User>();

            foreach(var user in elements)
            {
                string firstName = user.Attribute("firstName")?.Value;
                string lastName = user.Attribute("lastName")?.Value;
                int? age = null;

                if(user.Attribute("age") != null)
                {
                    age = int.Parse(user.Attribute("age").Value);
                }

                users.Add(new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                });
            }

            return users;
        }

        private static string UsersAndProducts(ProductsShopContext context)
        {
            var users = context.Users
                .Where(u => u.SellingProducts.Count > 0)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.SellingProducts.Count,
                        products = u.SellingProducts
                            .Select(sp => new
                            {
                                name = sp.Name,
                                price = sp.Price
                            })
                            .ToArray()
                    }
                })
                .OrderByDescending(o => o.soldProducts.count)
                .ThenBy(o => o.lastName)
                .ToArray();

            var result = new
            {
                usersCount = users.Count(),
                users = users
            };

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return json;
        }

        private static string CategoriesInfo(ProductsShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts
                        .Select(cp => cp.Product)
                        .Count(),
                    averagePrice = c.CategoryProducts
                        .Select(cp => cp.Product)
                        .Average(p => p.Price),
                    totalRevenue = c.CategoryProducts
                        .Select(cp => cp.Product)
                        .Sum(p => p.Price)
                });

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        private static string SoldProducts(ProductsShopContext context)
        {
            var users = context.Users
                .Where(u => u.SellingProducts.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.SellingProducts
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                        .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        private static string GetProductsInRange(ProductsShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }

        private static void SeedJson(ProductsShopContext context)
        {
            var users = ImportUsersJson();
            context.Users.AddRange(users);

            var categories = ImportCategoriesJson();
            context.Categories.AddRange(categories);

            var products = ImportProductsJson(context);
            context.Products.AddRange(products);

            var categoryProducts = CreateCategoryProducts(context);
            context.CategoryProducts.AddRange(categoryProducts);

            context.SaveChanges();
        }

        private static CategoryProduct[] CreateCategoryProducts(ProductsShopContext context)
        {
            var categoryProducts = new List<CategoryProduct>();
            var products = context.Products.ToArray();
            var categories = context.Categories.ToArray();
            var rnd = new Random();

            for(int i=0; i<products.Length; i++)
            {
                int categoriesCount = rnd.Next(1, 4);
                HashSet<Category> currentCategories = new HashSet<Category>();

                for(int j=1; j <= categoriesCount; j++)
                {
                    var category = categories[rnd.Next(0, categories.Length)];
                    currentCategories.Add(category);
                }

                currentCategories.ToList().ForEach(c => categoryProducts.Add(new CategoryProduct { Category = c, Product = products[i] }));
            }

            return categoryProducts.ToArray();
        }

        private static Product[] ImportProductsJson(ProductsShopContext context)
        {
            var json = File.ReadAllText("Import/products.json");
            var products = JsonConvert.DeserializeObject<Product[]>(json);

            var users = context.Users.ToArray();

            Random rnd = new Random();

            foreach(Product product in products)
            {
                var seller = users[rnd.Next(0, users.Length)];
                product.Seller = seller;

                var buyerId = rnd.Next(0, users.Length + (int)(users.Length * 0.3));
                product.Buyer = buyerId < users.Length ? users[buyerId] : null;
            }

            return products;
        }

        private static Category[] ImportCategoriesJson()
        {
            var json = File.ReadAllText("Import/categories.json");
            var categories = JsonConvert.DeserializeObject<Category[]>(json);

            return categories;
        }

        private static User[] ImportUsersJson()
        {
            var json = File.ReadAllText("Import/users.json");
            var users = JsonConvert.DeserializeObject<User[]>(json);

            return users;
        }
    }
}
