//namespace Kurskal
//{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            List<Edge> spannigTree = new List<Edge>();
            edges.Sort();

            var parent = new int[numberOfVertices];
            for(int i=0; i<parent.Length; i++)
            {
                parent[i] = i;
            }

            foreach(var edge in edges)
            {
                int rootStartNode = FindRoot(edge.StartNode, parent);
                int rootEndNode = FindRoot(edge.EndNode, parent);

                if(rootStartNode != rootEndNode)
                {
                    spannigTree.Add(edge);
                    parent[rootEndNode] = rootStartNode;
                }
            }

            return spannigTree;
        }

        public static int FindRoot(int node, int[] parent)
        {
            int root = node;
            while(parent[root] != root)
            {
                root = parent[root];
            }

            while(node != root)
            {
                int previousParent = parent[node];
                parent[node] = root;
                node = previousParent;
            }

            return root;
        }
    }
//}
