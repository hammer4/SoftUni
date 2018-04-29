
using System;

public class Edge : IComparable<Edge>
{
    public Edge(int from, int to, int weight)
    {
        this.From = from;
        this.To = to;
        this.Weight = weight;
    }

    public int From { get; private set; }

    public int To { get; private set; }

    public int Weight { get; private set; }

    public int CompareTo(Edge other)
    {
        return this.Weight.CompareTo(other.Weight);
    }

    public override string ToString()
    {
        return $"({this.From} {this.To}) -> {this.Weight}";
    }
}