using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private Dictionary<string, int> predecessorCount;

    private HashSet<string> visited;
    private HashSet<string> cycleNodes;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
        //GetPredecessorCount();
        this.visited = new HashSet<string>();
        this.cycleNodes = new HashSet<string>();
    }

    public ICollection<string> TopSort()
    {
        //Itterative

        //List<string> sorted = new List<string>();

        //while (true)
        //{
        //    string nodeToRemove = predecessorCount.Keys
        //        .Where(x => predecessorCount[x] == 0)
        //        .FirstOrDefault();

        //    if(nodeToRemove == null)
        //    {
        //        break;
        //    }

        //    foreach(var child in graph[nodeToRemove])
        //    {
        //        predecessorCount[child]--;
        //    }

        //    graph.Remove(nodeToRemove);
        //    predecessorCount.Remove(nodeToRemove);
        //    sorted.Add(nodeToRemove);
        //}

        //if(graph.Count > 0)
        //{
        //    throw new InvalidOperationException();
        //}

        LinkedList<string> sorted = new LinkedList<string>();


        //Recursive

        foreach(var node in graph.Keys)
        {
            DFS(node, sorted);
        }

        return sorted;
    }

    private void DFS(string node, LinkedList<string> sorted)
    {
        if (cycleNodes.Contains(node))
        {
            throw new InvalidOperationException("Cycle detected.");
        }

        if (!visited.Contains(node))
        {
            visited.Add(node);
            cycleNodes.Add(node);

            foreach(var child in graph[node])
            {
                DFS(child, sorted);
            }

            cycleNodes.Remove(node);
            sorted.AddFirst(node);
        }
    }

    public void GetPredecessorCount()
    {
        predecessorCount = new Dictionary<string, int>();

        foreach(var node in graph)
        {
            if (!predecessorCount.ContainsKey(node.Key))
            {
                predecessorCount[node.Key] = 0;
            }

            foreach(var child in node.Value)
            {
                if (!predecessorCount.ContainsKey(child))
                {
                    predecessorCount[child] = 0;
                }

                predecessorCount[child]++;
            }
        }
    }
}
