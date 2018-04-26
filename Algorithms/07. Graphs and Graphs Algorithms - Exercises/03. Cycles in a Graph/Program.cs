
using System;
using System.Collections.Generic;
using System.Linq;

public class CyclesInGraph
{
    private static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
    static HashSet<string> visited = new HashSet<string>();
    static HashSet<string> currentVisited = new HashSet<string>();
    private static bool haveCycle;

    public static void Main()
    {
        string line = Console.ReadLine();
        while (!String.IsNullOrWhiteSpace(line))
        {
            var edge = line.Split('–').ToArray(); //long dash

            if (!graph.ContainsKey(edge[0]))
            {
                graph.Add(edge[0], new List<string>());
            }

            if (!graph.ContainsKey(edge[1]))
            {
                graph.Add(edge[1], new List<string>());
            }

            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
            line = Console.ReadLine();
        }

        foreach (var vertex in graph)
        {
            CheckForCycle(vertex.Key, null);
        }

        Console.WriteLine("Acyclic: {0}", haveCycle ? "No" : "Yes");
    }

    private static void CheckForCycle(string vertex, string parent)
    {
        if (currentVisited.Contains(vertex))
        {
            haveCycle = true;
            return;
        }

        if (visited.Contains(vertex) || haveCycle)
        {
            return;
        }

        visited.Add(vertex);
        currentVisited.Add(vertex);

        foreach (string child in graph[vertex])
        {
            if (child != parent)
            {
                CheckForCycle(child, vertex);
            }
        }

        currentVisited.Remove(vertex);
    }
}