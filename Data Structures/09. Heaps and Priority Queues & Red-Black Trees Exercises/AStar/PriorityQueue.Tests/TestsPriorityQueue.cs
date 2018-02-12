using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TestsPriorityQueue
{
    [TestMethod]
    public void DecreaseKey_SingleElement()
    {
        var queue = new PriorityQueue<TestNode<int>>();

        var testNode = new TestNode<int>() { Value = 1 };

        queue.Enqueue(testNode);
        queue.DecreaseKey(testNode);

        Assert.AreEqual(1, queue.Count);
        Assert.AreEqual(1, queue.Dequeue().Value);
    }

    [TestMethod]
    public void DecreaseKey_TwoElements()
    {
        var queue = new PriorityQueue<TestNode<int>>();

        var testNode1 = new TestNode<int>() { Value = 2 };
        var testNode2 = new TestNode<int>() { Value = 3 };

        queue.Enqueue(testNode1);
        queue.Enqueue(testNode2);

        testNode2.Value = 1;
        queue.DecreaseKey(testNode2);

        Assert.AreEqual(2, queue.Count);
        Assert.AreEqual(1, queue.Dequeue().Value);
    }

    [TestMethod]
    public void DecreaseKey_MultipleElements()
    {
        var queue = new PriorityQueue<TestNode<int>>();

        var testNode1 = new TestNode<int>() { Value = 6 };
        var testNode2 = new TestNode<int>() { Value = 3 };
        var testNode3 = new TestNode<int>() { Value = 4 };
        var testNode4 = new TestNode<int>() { Value = 2 };
        var testNode5 = new TestNode<int>() { Value = 8 };

        queue.Enqueue(testNode1);
        queue.Enqueue(testNode2);
        queue.Enqueue(testNode3);
        queue.Enqueue(testNode4);
        queue.Enqueue(testNode5);

        testNode5.Value = 1;
        queue.DecreaseKey(testNode5);

        Assert.AreEqual(1, queue.Dequeue().Value);
        Assert.AreEqual(2, queue.Dequeue().Value);

        testNode1.Value = 1;
        queue.DecreaseKey(testNode1);
        Assert.AreEqual(1, queue.Dequeue().Value);
    }
}

class TestNode<T> : IComparable<TestNode<T>> where T : IComparable<T>
{
    public T Value { get; set; }

    public int CompareTo(TestNode<T> other)
    {
        return this.Value.CompareTo(other.Value);
    }
}
