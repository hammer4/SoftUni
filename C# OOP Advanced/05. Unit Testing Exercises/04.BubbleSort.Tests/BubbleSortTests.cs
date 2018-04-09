using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class BubbleSortTests
{
    private int[] expected;

    [SetUp]
    public void TestInit()
    {
        expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
    }

    [Test]
    public void ShouldSortDefaultOrder()
    {
        int[] array = new int[] { 1, 8, 5, 4, 3, 2, 7, 6 };

        var bubble = new BubbleSort(array);
        bubble.Sort();

        Assert.That(bubble.Array, Is.EqualTo(expected));
    }

    public void ShouldSortReversedOrder()
    {
        int[] array = new int[] { 8, 7, 6, 5, 4, 3, 2, 1 };

        var bubble = new BubbleSort(array);
        bubble.Sort();

        Assert.That(bubble.Array, Is.EqualTo(expected));
    }

    [Test]
    public void ShouldSortIncreasingOrder()
    {
        int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

        var bubble = new BubbleSort(array);
        bubble.Sort();

        Assert.That(bubble.Array, Is.EqualTo(expected));
    }
}