using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Pizza_Calories
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Dough")
                {
                    try
                    {
                        Dough dough = new Dough(tokens[1], tokens[2], int.Parse(tokens[3]));
                        Console.WriteLine("{0:f2}", dough.Callories());
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
                else if (tokens[0] == "Topping")
                {
                    try
                    {
                        Topping topping = new Topping(tokens[1], int.Parse(tokens[2]));
                        Console.WriteLine("{0:f2}", topping.Callories());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
                else
                {
                    string name = tokens[1];
                    int numberOfToppings = 0;
                    numberOfToppings = int.Parse(tokens[2]);
                    if (numberOfToppings > 10)
                    {
                        Console.WriteLine("Number of toppings should be in range [0..10].");
                        return;
                    }

                    command = Console.ReadLine();
                    tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    Pizza pizza;
                    try
                    {
                        Dough dough = new Dough(tokens[1], tokens[2], int.Parse(tokens[3]));
                        pizza = new Pizza(name, dough);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }

                    for (int i = 0; i < numberOfToppings; i++)
                    {
                        command = Console.ReadLine();
                        tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            Topping topping = new Topping(tokens[1], int.Parse(tokens[2]));
                            pizza.AddTopping(topping);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return;
                        }
                    }
                    Console.WriteLine("{0} - {1:F2} Calories.", pizza.Name, pizza.Callories());
                    return;
                }
                    command = Console.ReadLine();
            }
        }
    }
}
