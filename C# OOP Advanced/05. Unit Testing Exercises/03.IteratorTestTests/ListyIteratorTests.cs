using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class ListyIteratorTests
{
    private string[] input = new string[] { "a", "b", "c" };
    private ListyIterator<string> list;

    [SetUp]
    public void TestInit()
    {
        list = new ListyIterator<string>(input);
    }

    [Test]
    public void MoveWithNextElementShouldReturnTrue()
    {
        Assert.That(() => list.Move(), Is.True);
    }

    [Test]
    public void MoveWithNoNextEelementShoudReturnFalse()
    {
        list.Move();
        list.Move();

        Assert.That(() => list.Move(), Is.False);
    }

    [Test]
    public void HasNextShouldReturnTrueIfHasNext()
    {
        Assert.That(() => list.HasNext(), Is.True);
    }

    [Test]
    public void HasNextNoNextElementShouldReturnFalse()
    {
        list.Move();
        list.Move();

        Assert.That(() => list.HasNext(), Is.False);
    }

    [Test]
    public void PrintEmptyListThrows()
    {
        list = new ListyIterator<string>();

        Assert.That(() => list.Print(), Throws.InvalidOperationException);
    }
}