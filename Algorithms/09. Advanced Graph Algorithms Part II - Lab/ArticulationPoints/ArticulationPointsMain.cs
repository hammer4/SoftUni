using System;
using System.Collections.Generic;

public class ArticulationPointsMain
{
    static void Main(string[] args)
    {
        var graph = new List<int>[]
        {
                new List<int>() {1, 2, 6, 7, 9},      // children of node 0
                new List<int>() {0, 6},               // children of node 1
                new List<int>() {0, 7},               // children of node 2
                new List<int>() {4},                  // children of node 3
                new List<int>() {3, 6, 10},           // children of node 4
                new List<int>() {7},                  // children of node 5
                new List<int>() {0, 1, 4, 8, 10, 11}, // children of node 6
                new List<int>() {0, 2, 5, 9},         // children of node 7
                new List<int>() {6, 11},              // children of node 8
                new List<int>() {0, 7},               // children of node 9
                new List<int>() {4, 6},               // children of node 10
                new List<int>() {6, 8},               // children of node 11
        };

        var articulationPoints = ArticulationPoints.FindArticulationPoints(graph);
        Console.WriteLine("Articulation points: " +
            string.Join(", ", articulationPoints));
    }
}