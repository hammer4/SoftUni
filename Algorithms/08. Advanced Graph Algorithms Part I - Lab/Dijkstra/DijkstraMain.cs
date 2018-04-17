//namespace Dijkstra
//{
    using System;

    public class DijkstraMain
    {
        public static void Main()
        {
            var graph = new[,]
            {
                // 0   1   2   3   4   5   6   7   8   9  10  11
                { 0,  0,  0,  0,  0,  0, 10,  0, 12,  0,  0,  0 }, // 0
                { 0,  0,  0,  0, 20,  0,  0, 26,  0,  5,  0,  6 }, // 1
                { 0,  0,  0,  0,  0,  0,  0, 15, 14,  0,  0,  9 }, // 2
                { 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  7,  0 }, // 3
                { 0, 20,  0,  0,  0,  5, 17,  0,  0,  0,  0, 11 }, // 4
                { 0,  0,  0,  0,  5,  0,  6,  0,  3,  0,  0, 33 }, // 5
                {10,  0,  0,  0, 17,  6,  0,  0,  0,  0,  0,  0 }, // 6
                { 0, 26, 15,  0,  0,  0,  0,  0,  0,  3,  0, 20 }, // 7
                {12,  0, 14,  0,  0,  3,  0,  0,  0,  0,  0,  0 }, // 8
                { 0,  5,  0,  0,  0,  0,  0,  3,  0,  0,  0,  0 }, // 9
                { 0,  0,  0,  7,  0,  0,  0,  0,  0,  0,  0,  0 }, // 10
                { 0,  6,  9,  0, 11, 33,  0, 20,  0,  0,  0,  0 }, // 11
            };

            PrintPath(graph, 0, 9);
            PrintPath(graph, 0, 2);
            PrintPath(graph, 0, 10);
            PrintPath(graph, 0, 11);
            PrintPath(graph, 0, 1);
        }

        public static void PrintPath(int[,] graph, int sourceNode, int destinationNode)
        {
            Console.Write(
                "Shortest path [{0} -> {1}]: ",
                sourceNode,
                destinationNode);

            var path = DijkstraWithoutQueue.DijkstraAlgorithm(graph, sourceNode, destinationNode);

            if (path == null)
            {
                Console.WriteLine("no path");
            }
            else
            {
                int pathLength = 0;
                for (int i = 0; i < path.Count - 1; i++)
                {
                    pathLength += graph[path[i], path[i + 1]];
                }

                var formattedPath = string.Join("->", path);
                Console.WriteLine("{0} (length {1})", formattedPath, pathLength);
            }
        }
}
//}
