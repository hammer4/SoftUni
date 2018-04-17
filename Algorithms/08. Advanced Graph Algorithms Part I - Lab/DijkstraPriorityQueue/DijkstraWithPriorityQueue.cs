//namespace Dijkstra
//{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
        {
            int?[] previous = new int?[graph.Count];
            bool[] visited = new bool[graph.Count];

            PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();

            foreach(var pair in graph)
            {
                pair.Key.DistanceFromStart = double.PositiveInfinity;
            }

            sourceNode.DistanceFromStart = 0;
            priorityQueue.Enqueue(sourceNode);

            while(priorityQueue.Count > 0)
            {
                var currentNode = priorityQueue.ExtractMin();

                if(currentNode == destinationNode)
                {
                    break;
                }

                foreach(var edge in graph[currentNode])
                {
                    if (!visited[edge.Key.Id])
                    {
                        priorityQueue.Enqueue(edge.Key);
                        visited[edge.Key.Id] = true;
                    }

                    double distance = currentNode.DistanceFromStart + edge.Value;

                    if(distance < edge.Key.DistanceFromStart)
                    {
                        edge.Key.DistanceFromStart = distance;
                        previous[edge.Key.Id] = currentNode.Id;
                        priorityQueue.DecreaseKey(edge.Key);
                    }
                }
            }

            if (double.IsInfinity(destinationNode.DistanceFromStart))
            {
                return null;
            }

            List<int> path = new List<int>();
            int? current = destinationNode.Id;

            while(current != null)
            {
                path.Add(current.Value);
                current = previous[current.Value];
            }

            path.Reverse();

            return path;
        }
    }
//}
