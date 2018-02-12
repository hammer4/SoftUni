using System;
using System.Collections.Generic;

public class AStar
{
    private char[,] map;

    public AStar(char[,] map)
    {
        this.map = map;
    }

    public static int GetH(Node current, Node goal)
    {
        var deltaX = Math.Abs(current.Col - goal.Col);
        var deltaY = Math.Abs(current.Row - goal.Row);

        return deltaX + deltaY;
    }

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {
        var open = new PriorityQueue<Node>();
        var parent = new Dictionary<Node, Node>();
        var cost = new Dictionary<Node, int>();

        open.Enqueue(start);
        parent[start] = null;
        cost[start] = 0;

        while(open.Count > 0)
        {
            var current = open.Dequeue();
            if (current.Equals(goal))
            {
                break;
            }

            for(int i= current.Row - 1; i<=current.Row + 1; i++)
            {
                for(int j=current.Col - 1; j<=current.Col + 1; j++)
                {
                    if(i==1 && j == 2)
                    {

                    }
                    if(Math.Abs(Math.Abs(i-j) - Math.Abs(current.Row - current.Col)) == 1 && i >= 0 && i < map.GetLength(0) && j >= 0 && j < map.GetLength(1) && (map[i,j] == '-' || map[i,j] == '*'))
                    {
                        var newCost = cost[current] + 1;
                        Node neighbor = new Node(i, j);

                        if (!cost.ContainsKey(neighbor) || newCost < cost[neighbor])
                        {
                            cost[neighbor] = newCost;
                            neighbor.F = newCost + GetH(neighbor, goal);
                            open.Enqueue(neighbor);
                            parent[neighbor] = current;
                        }
                    }
                }
            }
        }

        var result = new Stack<Node>();

        if (parent.ContainsKey(goal))
        {
            result.Push(goal);
            var current = parent[goal];

            while(current != start && current != null)
            {
                result.Push(current);
                current = parent[current];
            }

            result.Push(current);
        }
        else
        {
            result.Push(start);
        }

        return result;
    }
}

