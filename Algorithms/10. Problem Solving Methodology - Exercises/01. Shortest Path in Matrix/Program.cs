
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static int[,] matrix;

    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        int columns = int.Parse(Console.ReadLine());
        matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            var rowElements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = rowElements[j];
            }
        }

        var result = DijkstraAlgorithm(matrix, 0, 0, rows - 1, columns - 1);
        Console.WriteLine("Length: " + result.Sum());
        Console.WriteLine("Path: " + string.Join(" ", result));

    }

    public static List<int> DijkstraAlgorithm(int[,] graph, int sourceRow, int sourceColumn, int destinationRow, int destinationColumn)
    {
        int n = graph.GetLength(0);
        int m = graph.GetLength(1);

        int[,] distance = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                distance[i, j] = int.MaxValue;
            }
        }

        distance[sourceRow, sourceColumn] = 0;

        Tuple<int, int>[,] previous = new Tuple<int, int>[n, m];
        var currentCell = new Tuple<int, int>(sourceRow, sourceColumn);
        previous[0, 0] = currentCell;
        bool[,] used = new bool[n, m];

        Tuple<int, int>[] neigbourCells = new Tuple<int, int>[4]
        {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(-1, 0),
                new Tuple<int, int>(0, -1)
        };

        while (true)
        {
            int minDistance = int.MaxValue;
            Tuple<int, int> nextCell = null;
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < m; column++)
                {
                    if (!used[row, column] && distance[row, column] < minDistance)
                    {
                        minDistance = distance[row, column];
                        nextCell = new Tuple<int, int>(row, column);
                    }
                }
            }

            if (minDistance == int.MaxValue)
            {
                break;
            }

            used[nextCell.Item1, nextCell.Item2] = true;

            foreach (var cell in neigbourCells)
            {
                var row = nextCell.Item1 + cell.Item1;
                var column = nextCell.Item2 + cell.Item2;
                if (row >= 0 && row < n && column >= 0 && column < m)
                {
                    var newDistance = distance[nextCell.Item1, nextCell.Item2] + graph[row, column];
                    if (newDistance < distance[row, column])
                    {
                        distance[row, column] = newDistance;
                        previous[row, column] = nextCell;
                    }
                }
            }
        }

        if (distance[destinationRow, destinationColumn] == int.MaxValue)
        {
            return null;
        }

        var path = new List<int>();
        path.Add(graph[destinationRow, destinationColumn]);
        var currentNode = previous[destinationRow, destinationColumn];
        while (currentNode.Item1 != 0 || currentNode.Item2 != 0)
        {
            path.Add(graph[currentNode.Item1, currentNode.Item2]);
            currentNode = previous[currentNode.Item1, currentNode.Item2];
        }

        path.Add(graph[sourceRow, sourceColumn]);

        path.Reverse();

        return path;
    }
}

public class PriorityQueue<T> where T : IComparable<T>
{
    private Dictionary<T, int> searchCollection;
    private List<T> heap;

    public PriorityQueue()
    {
        this.heap = new List<T>();
        this.searchCollection = new Dictionary<T, int>();
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public T ExtractMin()
    {
        var min = this.heap[0];
        var last = this.heap[this.heap.Count - 1];
        this.searchCollection[last] = 0;
        this.heap[0] = last;
        this.heap.RemoveAt(this.heap.Count - 1);
        if (this.heap.Count > 0)
        {
            this.HeapifyDown(0);
        }

        this.searchCollection.Remove(min);

        return min;
    }

    public T PeekMin()
    {
        return this.heap[0];
    }

    public void Enqueue(T element)
    {
        this.searchCollection.Add(element, this.heap.Count);
        this.heap.Add(element);
        this.HeapifyUp(this.heap.Count - 1);
    }

    private void HeapifyDown(int i)
    {
        var left = (2 * i) + 1;
        var right = (2 * i) + 2;
        var smallest = i;

        if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
        {
            smallest = left;
        }

        if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
        {
            smallest = right;
        }

        if (smallest != i)
        {
            T old = this.heap[i];
            this.searchCollection[old] = smallest;
            this.searchCollection[this.heap[smallest]] = i;
            this.heap[i] = this.heap[smallest];
            this.heap[smallest] = old;
            this.HeapifyDown(smallest);
        }
    }

    private void HeapifyUp(int i)
    {
        var parent = (i - 1) / 2;
        while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
        {
            T old = this.heap[i];
            this.searchCollection[old] = parent;
            this.searchCollection[this.heap[parent]] = i;
            this.heap[i] = this.heap[parent];
            this.heap[parent] = old;

            i = parent;
            parent = (i - 1) / 2;
        }
    }

    public void DecreaseKey(T element)
    {
        int index = this.searchCollection[element];
        this.HeapifyUp(index);
    }
}