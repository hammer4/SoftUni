//namespace Kurskal
//{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KruskalMain
    {
        public static void Main()
        {
            int numberOfVertices = 9;
            var graphEdges = new List<Edge>
            {
                new Edge(0, 3, 9),
                new Edge(0, 5, 4),
                new Edge(0, 8, 5),
                new Edge(1, 4, 8),
                new Edge(1, 7, 7),
                new Edge(2, 6, 12),
                new Edge(3, 5, 2),
                new Edge(3, 6, 8),
                new Edge(3, 8, 20),
                new Edge(4, 7, 10),
                new Edge(6, 8, 7)
            };

            var minimumSpanningForest = KruskalAlgorithm.Kruskal(numberOfVertices, graphEdges);

            Console.WriteLine("Minimum spanning forest weight: " +
                            minimumSpanningForest.Sum(e => e.Weight));

            foreach (var edge in minimumSpanningForest)
            {
                Console.WriteLine(edge);
            }
        }
    }
//}
