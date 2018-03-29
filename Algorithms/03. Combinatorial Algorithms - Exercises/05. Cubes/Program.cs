using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static HashSet<Cube> isomorphicCubes;
    private static int[] currentEdges;
    private static int[] colorsLeftCount;
    private static int cubesCount;

    public static void Main()
    {
        int[] sticks = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int count = NumberOfCubes(sticks);
        Console.WriteLine(count);
    }

    static void GenerateCubes(int edgeIndex)
    {
        if (edgeIndex == Cube.EDGE_COUNT)
        {
            Cube cube = new Cube(currentEdges);
            if (isomorphicCubes.Contains(cube))
            {
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                cube.RotateXY();
                for (int j = 0; j < 4; j++)
                {
                    cube.RotateXZ();
                    for (int k = 0; k < 4; k++)
                    {
                        cube.RotateYZ();
                        isomorphicCubes.Add(new Cube(cube));
                    }
                }
            }

            cubesCount++;
            //Console.WriteLine(cube);
            return;
        }

        for (int color = 1; color <= Cube.MAX_COLOR; color++)
        {
            if (colorsLeftCount[color] > 0)
            {
                colorsLeftCount[color]--;
                currentEdges[edgeIndex] = color;
                GenerateCubes(edgeIndex + 1);
                colorsLeftCount[color]++;
            }
        }
    }

    static int NumberOfCubes(int[] sticks)
    {
        colorsLeftCount = new int[Cube.MAX_COLOR + 1];
        for (int i = 0; i < Cube.EDGE_COUNT; i++)
        {
            colorsLeftCount[sticks[i]]++;
        }

        currentEdges = new int[Cube.EDGE_COUNT];
        isomorphicCubes = new HashSet<Cube>();
        cubesCount = 0;
        GenerateCubes(0);

        return cubesCount;
    }

    private class Cube
    {
        public const int EDGE_COUNT = 12;
        public const int MAX_COLOR = 6;
        public int[] edges;

        public Cube()
        {
            this.edges = new int[EDGE_COUNT];
        }

        public Cube(int[] newEdges)
            : this()
        {
            Array.Copy(newEdges, this.edges, EDGE_COUNT);
        }

        public Cube(Cube cube)
            : this()
        {
            Array.Copy(cube.edges, this.edges, EDGE_COUNT);
        }

        public override string ToString()
        {
            string s = "{";
            foreach (int edge in this.edges)
            {
                s += edge;
            }
            s += "}";

            return s;
        }

        public void RotateXY()
        {
            int[] newEdges =
            {
                    this.edges[1], this.edges[2], this.edges[3], this.edges[0],
                    this.edges[5], this.edges[6], this.edges[7], this.edges[4],
                    this.edges[9], this.edges[10], this.edges[11], this.edges[8]
                };

            this.edges = newEdges;
        }

        public void RotateXZ()
        {
            int[] newEdges =
            {
                    this.edges[4], this.edges[9], this.edges[5], this.edges[1],
                    this.edges[8], this.edges[10], this.edges[2], this.edges[0],
                    this.edges[7], this.edges[11], this.edges[6], this.edges[3]
                };

            this.edges = newEdges;
        }

        public void RotateYZ()
        {
            int[] newEdges =
            {
                    this.edges[2], this.edges[5], this.edges[10], this.edges[6],
                    this.edges[1], this.edges[9], this.edges[11], this.edges[3],
                    this.edges[0], this.edges[4], this.edges[8], this.edges[7]
                };

            this.edges = newEdges;
        }

        public override bool Equals(object obj)
        {
            Cube cube = obj as Cube;
            if (cube != null)
            {
                for (int i = 0; i < EDGE_COUNT; i++)
                {
                    if (this.edges[i] != cube.edges[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (int edge in this.edges)
            {
                hashCode = hashCode * 7 + edge;
            }

            return hashCode;
        }
    }
}