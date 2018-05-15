using System;
using System.Collections.Generic;
using System.Linq;

public class TourdeSofia
{
    static int[] distTo;
    static bool[] marked;

    static void Main(string[] args)
    {
        int vertexCount = int.Parse(Console.ReadLine());
        int streetsCount = int.Parse(Console.ReadLine());
        int source = int.Parse(Console.ReadLine());

        HashSet<int>[] graph = new HashSet<int>[vertexCount];
        for (int i = 0; i < graph.Length; i++)
        {
            graph[i] = new HashSet<int>();
        }

        distTo = new int[vertexCount];
        marked = new bool[vertexCount];

        for (int i = 0; i < streetsCount; i++)
        {
            int[] edge = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            graph[edge[0]].Add(edge[1]);
        }

        BFS(graph, source);

        bool found = false;
        int min = int.MaxValue;
        for (int i = 0; i < graph.Length; i++)
        {
            if (marked[i] && graph[i].Contains(source) && distTo[i] + 1 < min)
            {
                found = true;
                min = distTo[i] + 1;
            }
        }

        if (found)
        {
            Console.WriteLine(min);
        }
        else
        {
            Console.WriteLine(marked.Where(x => x).Count());
        }
    }

    private static void BFS(HashSet<int>[] graph, int source)
    {
        Queue<int> q = new Queue<int>();

        q.Enqueue(source);
        distTo[source] = 0;
        marked[source] = true;

        while (q.Count > 0)
        {
            int current = q.Dequeue();
            foreach (var child in graph[current])
            {
                if (!marked[child])
                {
                    q.Enqueue(child);
                    marked[child] = true;
                    distTo[child] = distTo[current] + 1;
                }
            }
        }
    }
}