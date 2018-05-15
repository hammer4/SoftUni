using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        string[] matrix = new string[count];

        for(int i=0; i<count; i++)
        {
            matrix[i] = Console.ReadLine();
        }

        int maxConnections = 0;

        foreach(var unit in matrix)
        {
            HashSet<int> connections = new HashSet<int>();

            for(int i=0; i<unit.Length; i++)
            {
                if(unit[i] == 'Y')
                {
                    connections.Add(i);
                }
            }

            foreach(int j in connections.ToArray())
            {
                for(int k =0; k < matrix[j].Length; k++)
                {
                    if(matrix[j][k] == 'Y')
                    {
                        connections.Add(k);
                    }
                }
            }

            if(connections.Count - 1 > maxConnections)
            {
                maxConnections = connections.Count() - 1;
            }
        }

        Console.WriteLine(maxConnections);
    }
}