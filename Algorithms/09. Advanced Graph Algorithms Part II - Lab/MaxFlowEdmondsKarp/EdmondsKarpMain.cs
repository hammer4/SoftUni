using System;

public class EdmondsKarpMain
{
    static void Main(string[] args)
    {
        var graph = new int[][]
        {
                new int[] { 0, 10, 10, 0, 0, 0 },
                new int[] { 0, 0, 2, 4, 8, 0},
                new int[] { 0, 0, 0, 0, 9, 0},
                new int[] { 0, 0, 0, 0, 0, 10 },
                new int[] { 0, 0, 0, 6, 0, 10 },
                new int[] { 0, 0, 0, 0, 0, 0 },
        };

        var maxFlow = EdmondsKarp.FindMaxFlow(graph);
        Console.WriteLine($"Max flow = {maxFlow}");
    }
}
