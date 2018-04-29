using System;
using System.Collections.Generic;
using System.Linq;

public class ModifiedKruskalAlgorithm
{
    public static void Main()
    {
        int nodesCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();
        int edgesCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();

        var queue = new PriorityQueue<Edge>();
        for (int i = 0; i < edgesCount; i++)
        {
            int[] edgeArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var edge = new Edge(edgeArgs[0], edgeArgs[1], edgeArgs[2]);
            queue.Enqueue(edge);
        }

        var nodes = new int[nodesCount];
        for (int i = 1; i < nodesCount; i++)
        {
            nodes[i] = i;
        }

        var resultMst = new List<Edge>();
        int mstWeight = 0;
        while (queue.Count > 0)
        {
            var minEdge = queue.ExtractMin();
            int from = minEdge.From;
            int to = minEdge.To;
            int weight = minEdge.Weight;
            int fromRoot = FindRoot(from, nodes);
            int toRoot = FindRoot(to, nodes);
            if (fromRoot != toRoot)
            {
                resultMst.Add(minEdge);
                MergeTrees(fromRoot, to, nodes);
                mstWeight += weight;
            }
        }

        Console.WriteLine("Minimum spanning forest weight: " + mstWeight);
    }

    private static void MergeTrees(int fromRoot, int to, int[] nodes)
    {
        int currentRoot = nodes[to];
        while (currentRoot != fromRoot)
        {
            int oldRoot = nodes[currentRoot];
            nodes[currentRoot] = fromRoot;
            currentRoot = oldRoot;
        }
    }

    private static int FindRoot(int from, int[] nodes)
    {
        int root = nodes[from];
        while (root != nodes[root])
        {
            root = nodes[root];
        }

        return root;
    }
}