using System;
using System.Collections.Generic;

public class Vertex : IComparable<Vertex>
{
    public Vertex(int index)
    {
        this.Index = index;
        this.DijkstraDistance = 0;
        this.Neighbors = new List<Vertex>();
        this.Edges = new List<Edge>();
        this.From = index;
    }

    public int Index { get; private set; }

    public int From { get; set; }

    public double DijkstraDistance { get; set; }

    public List<Vertex> Neighbors { get; private set; }

    public List<Edge> Edges { get; private set; }

    public int CompareTo(Vertex other)
    {
        return (100 - this.DijkstraDistance).CompareTo(100 - other.DijkstraDistance);
    }
}