    using System;
    using System.Collections.Generic;
    using System.Linq;

public class MostReliablePath
{
    public static void Main()
    {
        int vertexCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();
        int[] startEndPoints = Console.ReadLine().Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();
        int edgesCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();

        var graph = new Vertex[vertexCount];
        for (int i = 0; i < vertexCount; i++)
        {
            graph[i] = new Vertex(i);
        }

        for (int i = 0; i < edgesCount; i++)
        {
            int[] edgesArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int from = edgesArgs[0];
            int to = edgesArgs[1];
            int weight = edgesArgs[2];
            graph[from].Neighbors.Add(graph[to]);
            graph[to].Neighbors.Add(graph[from]);
            graph[from].Edges.Add(new Edge(to, weight));
            graph[to].Edges.Add(new Edge(from, weight));
        }

        int sourceVertex = startEndPoints[0];
        int destinationVertex = startEndPoints[1];
        graph[sourceVertex].DijkstraDistance = 100;
        var visitedVertex = new bool[vertexCount];
        visitedVertex[sourceVertex] = true;
        var queue = new PriorityQueue<Vertex>();
        queue.Enqueue(graph[sourceVertex]);

        while (queue.Count > 0)
        {
            var curentVertex = queue.ExtractMin();

            foreach (var edge in graph[curentVertex.Index].Edges)
            {
                if (graph[edge.To].DijkstraDistance < curentVertex.DijkstraDistance * edge.Weight / 100)
                {
                    graph[edge.To].DijkstraDistance = curentVertex.DijkstraDistance * edge.Weight / 100;
                    graph[edge.To].From = curentVertex.Index;
                }
            }

            foreach (var neighbor in graph[curentVertex.Index].Neighbors)
            {
                if (!visitedVertex[neighbor.Index])
                {
                    visitedVertex[neighbor.Index] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        Console.WriteLine("Most reliable path reliability: {0:F2}%", graph[destinationVertex].DijkstraDistance);
        var pathVertex = new Stack<int>();
        pathVertex.Push(destinationVertex);
        while (graph[destinationVertex].Index != graph[destinationVertex].From)
        {
            destinationVertex = graph[destinationVertex].From;
            pathVertex.Push(destinationVertex);
        }

        Console.WriteLine(string.Join(" -> ", pathVertex));
    }
}