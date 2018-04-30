using System;
using System.Collections.Generic;

public class StronglyConnectedComponentsMain
{
    static void Main()
    {
        var graph = new List<int>[]
        {
                new List<int>() {1, 11, 13}, // children of node 0
                new List<int>() {6},         // children of node 1
                new List<int>() {0},         // children of node 2
                new List<int>() {4},         // children of node 3
                new List<int>() {3, 6},      // children of node 4
                new List<int>() {13},        // children of node 5
                new List<int>() {0, 11},     // children of node 6
                new List<int>() {12},        // children of node 7
                new List<int>() {6, 11},     // children of node 8
                new List<int>() {0},         // children of node 9
                new List<int>() {4, 6, 10},  // children of node 10
                new List<int>() {},          // children of node 11
                new List<int>() {7},         // children of node 12
                new List<int>() {2, 9},      // children of node 13
        };

        var result = StronglyConnectedComponents.FindStronglyConnectedComponents(graph);

        Console.WriteLine("Strongly Connected Components:");
        foreach (var component in result)
        {
            Console.WriteLine("{{{0}}}", string.Join(", ", component));
        }
    }
}
