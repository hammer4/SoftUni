using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int budget = int.Parse(Console.ReadLine().Split().Last());
        int nodesCount = int.Parse(Console.ReadLine().Split().Last());
        int edgesCount = int.Parse(Console.ReadLine().Split().Last());

        List<Node> nodes = new List<Node>();
        List<Edge> edges = new List<Edge>();

        for(int i=0; i<nodesCount; i++)
        {
            nodes.Add(new Node { IsConnected = false, Value = i });
        }

        for(int i=0; i<edgesCount; i++)
        {
            var tokens = Console.ReadLine().Split();
            bool isConnected = tokens.Length > 3;

            int from = int.Parse(tokens[0]);
            int to = int.Parse(tokens[1]);
            int price = int.Parse(tokens[2]);

            Node nodeFrom = nodes.Single(n => n.Value == from);
            Node nodeTo = nodes.Single(n => n.Value == to);

            edges.Add(new Edge { From = nodeFrom, To = nodeTo, Price = price });

            if (isConnected)
            {
                nodeFrom.IsConnected = true;
                nodeTo.IsConnected = true;
            }
        }

        int budgetUsed = 0;

        while(budgetUsed < budget)
        {
            var currentEdge = edges
                .Where(e => (e.From.IsConnected && !e.To.IsConnected) || (!e.From.IsConnected && e.To.IsConnected))
                .OrderBy(e => e.Price)
                .FirstOrDefault();

            if(currentEdge == null || currentEdge.Price > budget - budgetUsed)
            {
                break;
            }

            currentEdge.From.IsConnected = true;
            currentEdge.To.IsConnected = true;

            budgetUsed += currentEdge.Price;
        }

        Console.WriteLine($"Budget used: {budgetUsed}");
    }
}