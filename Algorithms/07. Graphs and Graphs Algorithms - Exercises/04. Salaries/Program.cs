using System;
using System.Collections.Generic;
using System.Linq;

public class Salaries
{
    private static List<int>[] graph;
    private static bool[] visited;
    private static long[] salaries;

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        graph = new List<int>[n];
        visited = new bool[n];
        salaries = new long[n];

        for (int i = 0; i < n; i++)
        {
            if (graph[i] == null)
            {
                graph[i] = new List<int>();
            }

            string children = Console.ReadLine();
            for (int j = 0; j < n; j++)
            {
                if (children[j] == 'Y')
                {
                    graph[i].Add(j);
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            CalculateSalaries(i);
        }

        Console.WriteLine(salaries.Sum());
    }

    private static void CalculateSalaries(int vertex)
    {
        if (salaries[vertex] != 0 || visited[vertex])
        {
            return;
        }

        if (graph[vertex].Count == 0)
        {
            salaries[vertex] = 1;
            return;
        }

        visited[vertex] = true;
        long sum = 0;
        foreach (int child in graph[vertex])
        {
            if (salaries[child] == 0)
            {
                CalculateSalaries(child);
            }

            sum += salaries[child];
        }

        salaries[vertex] = sum;
    }
}