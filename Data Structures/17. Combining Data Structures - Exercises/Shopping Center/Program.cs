using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

class Program
{
    static void Main()
    {

        int commandsNumber = int.Parse(Console.ReadLine());
        ProductList center = new ProductList();

        for (int i = 0; i < commandsNumber; i++)
        {

            string line = Console.ReadLine();
            string command = line.Substring(0, line.IndexOf(" "));
            string[] args = line.Substring(line.IndexOf(" ") + 1).Split(';');

            switch (command)
            {
                case "AddProduct":

                    string name = args[0];
                    decimal price = decimal.Parse(args[1]);
                    string producer = args[2];

                    center.Add(name, price, producer);
                    break;
                case "DeleteProducts":
                    if (args.Length == 1)
                    {
                        int count = center.DeleteByProducer(args[0]);
                        if (count == 0)
                        {
                            Console.WriteLine("No products found");
                        }
                        else
                        {
                            Console.WriteLine(count + " products deleted");
                        }
                    }
                    else
                    {
                        int count = center.DeleteByNameProducer(
                            args[0],
                            args[1]);
                        if (count == 0)
                        {
                            Console.WriteLine("No products found");
                        }
                        else
                        {
                            Console.WriteLine(count + " products deleted");
                        }
                    }
                    break;
                case "FindProductsByName":

                    List<Product> result =
                        center.FindByName(args[0]).ToList();
                    if (result.Count != 0)
                    {
                        Console.WriteLine(string.Join(Environment.NewLine, result));
                    }
                    else
                    {
                        Console.WriteLine("No products found");
                    }
                    break;
                case "FindProductsByProducer":
                    List<Product> result2 =
                        center.FindByProducer(args[0]).ToList();
                    if (result2.Count != 0)
                    {
                        Console.WriteLine(string.Join(Environment.NewLine, result2));
                    }
                    else
                    {
                        Console.WriteLine("No products found");
                    }
                    break;

                case "FindProductsByPriceRange":
                    IEnumerable<Product> result3 =
                        center.FindByPrice(
                                decimal.Parse(args[0]),
                                decimal.Parse(args[1]));
                    if (result3.Any())
                    {
                        Console.WriteLine(string.Join(Environment.NewLine, result3));
                    }
                    else
                    {
                        Console.WriteLine("No products found");
                    }
                    break;
            }
        }
    }
}