using System;
using System.Collections.Generic;

public class ArticulationPoints
{
    private static List<int>[] graph;
    private static bool[] visited;
    private static int?[] parent;
    private static int[] depths;
    private static int[] lowpoint;
    private static List<int> articulationPoints;

    public static List<int> FindArticulationPoints(List<int>[] targetGraph)
    {
        graph = targetGraph;
        visited = new bool[graph.Length];
        parent = new int?[graph.Length];
        depths = new int[graph.Length];
        lowpoint = new int[graph.Length];
        articulationPoints = new List<int>();

        FindArticulationPoints(0, 0);

        return articulationPoints;
    }

    private static void FindArticulationPoints(int node, int depth)
    {
        visited[node] = true;
        depths[node] = depth;
        lowpoint[node] = depth;

        int childCount = 0;
        bool isArticulationPoint = false;

        foreach(var childNode in graph[node])
        {
            if (!visited[childNode])
            {
                parent[childNode] = node;
                FindArticulationPoints(childNode, depth + 1);
                childCount++;

                if(lowpoint[childNode] >= depths[node])
                {
                    isArticulationPoint = true;
                }

                lowpoint[node] = Math.Min(lowpoint[node], lowpoint[childNode]);
            }
            else if(childNode != parent[node])
            {
                lowpoint[node] = Math.Min(lowpoint[node], depths[childNode]);
            }
        }

        if((parent[node] != null && isArticulationPoint) || (parent[node] == null && childCount > 1))
        {
            articulationPoints.Add(node);
        }
    }
}
