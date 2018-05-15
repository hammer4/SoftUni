using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Chain_Lightning
{
    class Program
    {
        static void Main(string[] args)
        {
            int nodeCount = int.Parse(Console.ReadLine());
            int edgeCount = int.Parse(Console.ReadLine());
            int lightningsCount = int.Parse(Console.ReadLine());
            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < edgeCount; i++)
            {
                int[] inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                edges.Add(new Edge(inputs[0], inputs[1], inputs[2]));
            }
            List<Edge> spanningForestEdges = Kruskal(nodeCount, edges);
            List<int>[] graph = new List<int>[nodeCount];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }
            foreach (var edge in spanningForestEdges) //no need for weights here
            {
                graph[edge.StartNode].Add(edge.EndNode);
                graph[edge.EndNode].Add(edge.StartNode);
            }
            //process lightnings
            int[] damages = new int[nodeCount];
            for (int i = 0; i < lightningsCount; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int startNode = int.Parse(inputs[0]);
                int damage = int.Parse(inputs[1]);
                bool[] visited = new bool[nodeCount];
                int[] depths = new int[nodeCount];
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(startNode);
                visited[startNode] = true;
                depths[startNode] = 0;
                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    if (depths[node] >= 10) //the important optimization 60/100 -> 100/100
                    {
                        break;
                    }
                    foreach (var child in graph[node])
                    {
                        if (!visited[child])
                        {
                            visited[child] = true;
                            queue.Enqueue(child);
                            depths[child] = depths[node] + 1;
                            //could also calculate damage here instead of below 
                        }
                    }
                }
                damages[startNode] += damage;
                visited[startNode] = false;
                for (int node = 0; node < damages.Length; node++)
                {
                    if (visited[node])
                    {                             //if depth >= 10, damage = 0 (max 1000)                    
                        damages[node] += damage / (int)Math.Pow(2, depths[node]);
                    }
                }
            }
            Console.WriteLine(damages.Max());
        }

        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            int[] parents = new int[numberOfVertices];
            List<Edge> results = new List<Edge>();
            edges.Sort();
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = i;
            }
            foreach (var edge in edges)
            {
                int startRoot = FindRoot(edge.StartNode, parents);
                int endRoot = FindRoot(edge.EndNode, parents);
                if (startRoot != endRoot)
                {
                    parents[endRoot] = startRoot;
                    results.Add(edge);
                }
            }
            return results;
        }

        public static int FindRoot(int node, int[] parent)
        {
            int beginNode = node;
            while (parent[node] != node)
            {
                node = parent[node];
            }

            //optimization to make all nodes point to the root so we don't traverse later
            int root = node;
            int current = beginNode;
            while (parent[current] != current)
            {
                int parentNode = parent[current];
                parent[current] = root;
                current = parentNode;
            }
            return root;
        }
    }

    public class Edge : IComparable<Edge>
    {
        public Edge(int startNode, int endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public int StartNode { get; set; }

        public int EndNode { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            int weightCompared = this.Weight.CompareTo(other.Weight);
            return weightCompared;
        }
    }
}