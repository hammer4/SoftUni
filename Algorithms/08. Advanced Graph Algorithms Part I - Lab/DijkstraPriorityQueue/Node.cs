//namespace Dijkstra
//{
    using System;

    public class Node : IComparable<Node>
    {
        // set default value for the distance equal to positive infinity
        public Node(int id, double distance = double.PositiveInfinity)
        {
            this.Id = id;
            this.DistanceFromStart = distance;
        }

        public int Id { get; set; }

        public double DistanceFromStart { get; set; }

        public int CompareTo(Node other)
        {
            return this.DistanceFromStart.CompareTo(other.DistanceFromStart);
        }
    }
//}
