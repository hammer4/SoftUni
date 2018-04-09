using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DatabaseTests
{
    private int[] array;
    private int[] bigArray;
    private int[] limitArray;

    [SetUp]
    public void TestInit()
    {
        this.array = Enumerable.Range(1, 5).ToArray();
        this.bigArray = Enumerable.Range(1, 17).ToArray();
        this.limitArray = Enumerable.Range(1, 16).ToArray();
    }

    [Test]
    public void ConstructorShouldInitializeArrayAccurately()
    {
        var db = new Database(array);

        int[] actual = db.Fetch();

        Assert.That(actual, Is.EqualTo(array));
    }

    [Test]
    public void ConstructorShouldThrowWithManyelements()
    {
        Assert.That(() => new Database(bigArray), Throws.InvalidOperationException);
    }

    [Test]
    public void AddShouldAddElement()
    {
        var db = new Database(array);

        db.Add(6);

        int[] expected = array.Concat(new int[] { 6 }).ToArray();
        int[] actual = db.Fetch();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void AddShouldThrowWhenEndIsReached()
    {
        var db = new Database(limitArray);

        Assert.That(() => db.Add(17), Throws.InvalidOperationException);
    }

    [Test]
    public void RemoveShouldRemoveLastElement()
    {
        var db = new Database(array);

        int actual = db.Remove();
        int expected = array.Last();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void RemoveEmptyCollectionShouldThrow()
    {
        var db = new Database();

        Assert.That(() => db.Remove(), Throws.InvalidOperationException);
    }

    [Test]
    public void ComplexFunctionalityTest()
    {
        var db = new Database(array);
        db.Remove();
        db.Remove();
        db.Remove();
        db.Add(13);
        db.Add(14);
        db.Remove();

        var expected = new int[] { 1, 2, 13 };
        var actual = db.Fetch();

        Assert.That(actual, Is.EqualTo(expected));
    }
}