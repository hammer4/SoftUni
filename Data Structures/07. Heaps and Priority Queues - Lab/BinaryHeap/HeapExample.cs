using System;

public class HeapExample
{
    static void Main()
    {
        Console.WriteLine("Created an empty heap.");
        var heap = new BinaryHeap<int>();
        heap.Insert(5);
        heap.Insert(8);
        heap.Insert(1);
        heap.Insert(3);
        heap.Insert(12);
        heap.Insert(-4);

        Console.WriteLine("Heap elements (max to min):");
        while (heap.Count > 0)
        {
            var max = heap.Pull();
            Console.WriteLine(max);
        }

        var arr = new int[] { 5, 2, 0, -4, 3, 12 };

        Console.WriteLine("Unsorted: " + string.Join(" ", arr));

        Heap<int>.Sort(arr);

        Console.WriteLine("Sorted: " + string.Join(" ", arr));
    }
}
