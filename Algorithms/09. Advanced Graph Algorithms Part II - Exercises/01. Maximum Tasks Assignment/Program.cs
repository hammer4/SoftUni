using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static int[][] graph;
    private static int[] parents;

    static void Main(string[] args)
    {
        int people = int.Parse(Console.ReadLine().Split().Last());
        int tasks = int.Parse(Console.ReadLine().Split().Last());

        int nodes = people + tasks + 2;
        graph = new int[nodes][];

        for(int i=0; i<graph.Length; i++)
        {
            graph[i] = new int[nodes];
        }

        for(int i=0; i<people; i++)
        {
            graph[0][i + 1] = 1;
        }

        for(int i=0; i<tasks; i++)
        {
            graph[i + people + 1][graph.Length - 1] = 1;
        }

        for(int i=0; i<people; i++)
        {
            var line = Console.ReadLine();

            for (int j=0; j<tasks; j++)
            {

                if(line[j] == 'Y')
                {
                    graph[i + 1][j + people + 1] = 1;
                }
            }
        }

        FindMaxFlow();

        var queue = new Queue<int>();
        var result = new SortedSet<string>();
        var visited = new bool[graph.Length];

        int start = 0;
        int end = graph.Length - 1;

        queue.Enqueue(end);

        while(queue.Count > 0)
        {
            var node = queue.Dequeue();
            visited[node] = true;

            for(int i=0; i < graph.Length; i++)
            {
                if(graph[node][i] > 0 && !visited[i])
                {
                    queue.Enqueue(i);
                    visited[i] = true;

                    if(node != end && node != start && i != end && i != start)
                    {
                        result.Add($"{(char)(i - 1 + 'A')}-{node - people}");
                    }
                }
            }
        }

        Console.WriteLine(String.Join(Environment.NewLine, result));
    }

    public static void FindMaxFlow()
    {
        parents = new int[graph.Length];

        for (int i = 0; i < graph.Length; i++)
        {
            parents[i] = -1;
        }

        int maxFlow = 0;
        int start = 0;
        int end = graph.Length - 1;

        while (BFS(start, end))
        {
            int currentNode = end;

            while (currentNode != start)
            {
                int previousNode = parents[currentNode];

                graph[previousNode][currentNode] = 0;
                graph[currentNode][previousNode] = 1;

                currentNode = previousNode;
            }
        }
    }

    private static bool BFS(int start, int end)
    {
        bool[] visited = new bool[graph.Length];

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            visited[current] = true;

            for (int child = 0; child < graph[current].Length; child++)
            {
                if (!visited[child] && graph[current][child] > 0)
                {
                    queue.Enqueue(child);
                    parents[child] = current;
                }
            }
        }

        return visited[end];
    }
}