using System.Collections.Generic;

//namespace Dijkstra
//{
    using System;

    public class DijkstraMain
    {
        public static void Main()
        {
            //    // 0   1   2   3   4   5   6   7   8   9  10  11
            //    { 0,  0,  0,  0,  0,  0, 10,  0, 12,  0,  0,  0 }, // 0
            //    { 0,  0,  0,  0, 20,  0,  0, 26,  0,  5,  0,  6 }, // 1
            //    { 0,  0,  0,  0,  0,  0,  0, 15, 14,  0,  0,  9 }, // 2
            //    { 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  7,  0 }, // 3
            //    { 0, 20,  0,  0,  0,  5, 17,  0,  0,  0,  0, 11 }, // 4
            //    { 0,  0,  0,  0,  5,  0,  6,  0,  3,  0,  0, 33 }, // 5
            //    {10,  0,  0,  0, 17,  6,  0,  0,  0,  0,  0,  0 }, // 6
            //    { 0, 26, 15,  0,  0,  0,  0,  0,  0,  3,  0, 20 }, // 7
            //    {12,  0, 14,  0,  0,  3,  0,  0,  0,  0,  0,  0 }, // 8
            //    { 0,  5,  0,  0,  0,  0,  0,  3,  0,  0,  0,  0 }, // 9
            //    { 0,  0,  0,  7,  0,  0,  0,  0,  0,  0,  0,  0 }, // 10
            //    { 0,  6,  9,  0, 11, 33,  0, 20,  0,  0,  0,  0 }, // 11

            var nodes = new Dictionary<int, Node>();
            nodes.Add(0,new Node(0));
            nodes.Add(1, new Node(1));
            nodes.Add(2, new Node(2));
            nodes.Add(3, new Node(3));
            nodes.Add(4, new Node(4));
            nodes.Add(5, new Node(5));
            nodes.Add(6, new Node(6));
            nodes.Add(7, new Node(7));
            nodes.Add(8, new Node(8));
            nodes.Add(9, new Node(9));
            nodes.Add(10, new Node(10));
            nodes.Add(11, new Node(11));

            var graph = new Dictionary<Node, Dictionary<Node, int>>()
            {
                {nodes[0], new Dictionary<Node,int>(){{nodes[6], 10}, {nodes[8], 12}}},
                {nodes[1], new Dictionary<Node,int>(){ {nodes[4], 20}, {nodes[7], 26}, {nodes[9], 5}, {nodes[11], 6}}},
                {nodes[2], new Dictionary<Node,int>() { {nodes[7], 15}, {nodes[8], 14}, {nodes[11], 9}}},
                {nodes[3], new Dictionary<Node,int>() { {nodes[10], 7}}},
                {nodes[4], new Dictionary<Node,int>() { {nodes[1], 20}, {nodes[5], 5}, {nodes[6], 17}, {nodes[11], 11}}},
                {nodes[5], new Dictionary<Node,int>() { {nodes[4], 5}, {nodes[6], 6}, {nodes[8], 3}, {nodes[11], 33}}},
                {nodes[6], new Dictionary<Node,int>() { {nodes[0], 10}, {nodes[4], 17}, {nodes[5], 6}}},
                {nodes[7], new Dictionary<Node,int>() { {nodes[1], 26}, {nodes[2], 15}, {nodes[9], 3}, {nodes[11], 20}}},
                {nodes[8], new Dictionary<Node,int>() { {nodes[0], 12}, {nodes[2], 14}, {nodes[5], 3}}},
                {nodes[9], new Dictionary<Node,int>() { {nodes[1], 5}, {nodes[7], 3}}},
                {nodes[10], new Dictionary<Node,int>() { {nodes[3], 7}}},
                {nodes[11],new Dictionary<Node,int>(){ {nodes[1], 6}, {nodes[2], 9}, {nodes[4], 11}, {nodes[5], 33}, {nodes[7], 20}}}
            };

            PrintPath(graph,nodes, 0, 9);
            PrintPath(graph, nodes, 0, 2);
            PrintPath(graph, nodes, 0, 10);
            PrintPath(graph, nodes, 0, 11);
            PrintPath(graph, nodes, 0, 1);
        }

        public static void PrintPath(Dictionary<Node, Dictionary<Node, int>> graph, Dictionary<int,Node> nodes, int sourceNode, int destinationNode)
        {
            Console.Write(
                "Shortest path [{0} -> {1}]: ",
                sourceNode,
                destinationNode);

            var path = DijkstraWithPriorityQueue.DijkstraAlgorithm(graph, nodes[sourceNode], nodes[destinationNode]);

            if (path == null)
            {
                Console.WriteLine("no path");
            }
            else
            {
                var formattedPath = string.Join("->", path);
                Console.WriteLine("{0} (length {1})", formattedPath, nodes[destinationNode].DistanceFromStart);
            }
        }
    }
//}
