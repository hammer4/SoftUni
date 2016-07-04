using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            string[] tokens = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string token in tokens)
            {
                string[] tok = token.Split('=');
                string name = tok[0].Trim();
                decimal money = decimal.Parse(tok[1].Trim());
                try
                {
                    persons.Add(new Person(name, money));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }   
            }

            tokens = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string token in tokens)
            {
                string[] tok = token.Split('=');
                string name = tok[0].Trim();
                decimal cost = decimal.Parse(tok[1].Trim());
                try
                {
                    products.Add(new Product(name, cost));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string command = Console.ReadLine();

            while(command != "END")
            {
                tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                string productName = tokens[1];
                Person person = persons.Where(p => p.Name == personName).First();
                Product product = products.Where(p => p.Name == productName).First();

                if(person.Money >= product.Cost)
                {
                    person.Money -= product.Cost;
                    person.AddProductToBag(product);
                    Console.WriteLine("{0} bought {1}", person.Name, product.Name);
                }
                else
                {
                    Console.WriteLine("{0} can't afford {1}", person.Name, product.Name);
                }

                command = Console.ReadLine();
            }

            foreach(Person person in persons)
            {
                if(person.SeeBag().Count > 0)
                {
                    Console.WriteLine("{0} - {1}", person.Name, String.Join(", ", person.SeeBag().Select(p => p.Name)));
                }
                else
                {
                    Console.WriteLine("{0} - Nothing bought", person.Name);
                }
            }
        }
    }
}
