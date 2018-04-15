using System;
using System.Collections.Generic;

public class TopologicalSorterApp
{
    static void Main()
    {
        //var graph = new Dictionary<string, List<string>>()
        //{
        //    { "IDEs", new List<string>() { "variables", "loops" } },
        //    { "variables", new List<string>() { "conditionals", "loops", "bits" } },
        //    { "loops", new List<string>() { "bits" } },
        //    { "conditionals", new List<string>() { "loops" } },
        //};

        var graph = new Dictionary<string, List<string>>() {
            { "A", new List<string>() { "B", "C" } },
            { "B", new List<string>() { "D", "E" } },
            { "C", new List<string>() { "F" } },
            { "D", new List<string>() { "C", "F" } },
            { "E", new List<string>() { "D" } },
            { "F", new List<string>() { } },
        };

        var topSorter = new TopologicalSorter(graph);
        var sortedNodes = topSorter.TopSort();

        Console.WriteLine("Topological sorting: {0}",
            string.Join(", ", sortedNodes));

        // Topological sorting: A, B, E, D, C, F
    }
}
