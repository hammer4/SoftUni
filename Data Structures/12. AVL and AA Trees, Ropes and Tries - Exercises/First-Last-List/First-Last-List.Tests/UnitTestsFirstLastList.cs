using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

[TestClass]
public class UnitTestsFirstLastList
{
    [TestMethod]
    public void Add2Items_Count_ShouldReturn2()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();

        // Act
        items.Add(5);
        items.Add(10);

        // Assert
        Assert.AreEqual(2, items.Count);
    }

    [TestMethod]
    public void Add3Items_First2Items_ShouldReturnFirst2Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);

        // Act
        var returnedItems = items.First(2).ToList();

        // Assert
        var expectedItems = new int[] { 5, 10 };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add3Items_First0Items_ShouldReturn0Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);

        // Act
        var returnedItems = items.First(0).ToList();

        // Assert
        var expectedItems = new int[] { };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add5ItemsDuplicates_First4Items_ShouldReturnFirst4Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<Product>();
        items.Add(new Product(0.50m, "coffee"));
        items.Add(new Product(1.20m, "mint drops"));
        items.Add(new Product(1.20m, "beer"));
        items.Add(new Product(0.35m, "candy"));
        items.Add(new Product(1.20m, "cola"));

        // Act
        var returnedItems = items.First(4).Select(p => p.Title).ToList();

        // Assert
        var expectedItems = new string[] {
            "coffee", "mint drops", "beer", "candy" };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add3ItemsDuplicates_First3Items_ShouldReturnFirst3Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<string>();
        items.Add("coffee");
        items.Add("coffee");
        items.Add("milk");

        // Act
        var returnedItems = items.First(3).ToList();

        // Assert
        var expectedItems = new string[] {
            "coffee", "coffee", "milk" };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Add2Items_First3Items_ShouldThrowException()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);

        // Act
        items.First(3).ToList();
    }

    [TestMethod]
    public void Add3Items_Last2Items_ShouldReturnLast2Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);

        // Act
        var returnedItems = items.Last(2).ToList();

        // Assert
        var expectedItems = new int[] { -2, 10 };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add3Items_Last0Items_ShouldReturn0Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);

        // Act
        var returnedItems = items.Last(0).ToList();

        // Assert
        var expectedItems = new int[] { };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add5ItemsDuplicates_Last4Items_ShouldReturnLast4Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<Product>();
        items.Add(new Product(0.50m, "coffee"));
        items.Add(new Product(1.20m, "mint drops"));
        items.Add(new Product(1.20m, "beer"));
        items.Add(new Product(0.35m, "candy"));
        items.Add(new Product(1.20m, "cola"));

        // Act
        var returnedItems = items.Last(4).Select(p => p.Title).ToList();

        // Assert
        var expectedItems = new string[] {
            "cola", "candy", "beer", "mint drops" };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add3ItemsDuplicates_Last3Items_ShouldReturnLast3Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<string>();
        items.Add("coffee");
        items.Add("coffee");
        items.Add("milk");

        // Act
        var returnedItems = items.Last(3).ToList();

        // Assert
        var expectedItems = new string[] {
            "milk", "coffee", "coffee" };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Add2Items_Last3Items_ShouldThrowException()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);

        // Act
        items.Last(3).ToList();
    }

    [TestMethod]
    public void Add5Items_Min3Items_ShouldReturnMin3Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);
        items.Add(8);
        items.Add(1);

        // Act
        var returnedItems = items.Min(3).ToList();

        // Assert
        var expectedItems = new int[] { -2, 1, 5 };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add5Items_Min0Items_ShouldReturn0Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);
        items.Add(8);
        items.Add(1);

        // Act
        var returnedItems = items.Min(0).ToList();

        // Assert
        var expectedItems = new int[] { };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add5ItemsDuplicates_Min4Items_ShouldReturnMin4Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<Product>();
        items.Add(new Product(0.50m, "coffee"));
        items.Add(new Product(1.20m, "mint drops"));
        items.Add(new Product(1.20m, "beer"));
        items.Add(new Product(0.50m, "candy"));
        items.Add(new Product(1.20m, "cola"));

        // Act
        var returnedItems = items.Min(4).Select(p => p.Title).ToList();

        // Assert
        var expectedItems = new string[] {
            "coffee", "candy", "mint drops", "beer" };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add3ItemsDuplicates_Min3Items_ShouldReturnMin3Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<string>();
        items.Add("coffee");
        items.Add("coffee");
        items.Add("milk");

        // Act
        var returnedItems = items.Min(3).ToList();

        // Assert
        var expectedItems = new string[] {
            "coffee", "coffee", "milk" };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Add3Items_Min4Items_ShouldThrowException()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);

        // Act
        items.Min(4).ToList();
    }

    [TestMethod]
    public void Add5Items_Max3Items_ShouldReturnMax3Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);
        items.Add(8);
        items.Add(1);

        // Act
        var returnedItems = items.Max(3).ToList();

        // Assert
        var expectedItems = new int[] { 10, 8, 5 };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add5Items_Max0Items_ShouldReturn0Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);
        items.Add(8);
        items.Add(1);

        // Act
        var returnedItems = items.Max(0).ToList();

        // Assert
        var expectedItems = new int[] { };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add5ItemsDuplicates_Max4Items_ShouldReturnMax4Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<Product>();
        items.Add(new Product(0.50m, "coffee"));
        items.Add(new Product(1.20m, "mint drops"));
        items.Add(new Product(1.20m, "beer"));
        items.Add(new Product(0.50m, "candy"));
        items.Add(new Product(1.20m, "cola"));

        // Act
        var returnedItems = items.Max(4).Select(p => p.Title).ToList();

        // Assert
        var expectedItems = new string[] {
            "mint drops", "beer", "cola", "coffee" };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add3ItemsDuplicates_Max3Items_ShouldReturnMax3Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<string>();
        items.Add("coffee");
        items.Add("coffee");
        items.Add("milk");

        // Act
        var returnedItems = items.Max(3).ToList();

        // Assert
        var expectedItems = new string[] {
            "milk", "coffee", "coffee" };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Add3Items_Max4Items_ShouldThrowException()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);

        // Act
        items.Max(4).ToList();
    }

    [TestMethod]
    public void EmptyList_Remove0Items_ShouldReturn0()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();

        // Act
        var countRemoved = items.RemoveAll(0);

        // Assert
        Assert.AreEqual(0, countRemoved);
        Assert.AreEqual(0, items.Count);
    }

    [TestMethod]
    public void Add5Items_RemoveNonExistingItem()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);
        items.Add(8);
        items.Add(1);

        // Act
        var countRemoved = items.RemoveAll(0);

        // Assert
        Assert.AreEqual(0, countRemoved);
        Assert.AreEqual(5, items.Count);
    }

    [TestMethod]
    public void Add4Items_RemoveNonExistingItem_CheckFirstLastMinMax()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(1);
        items.Add(-5);
        items.Add(10);
        items.Add(4);

        // Act
        var countRemoved = items.RemoveAll(0);
        var first = items.First(1).FirstOrDefault();
        var last = items.Last(1).FirstOrDefault();
        var min = items.Min(1).FirstOrDefault();
        var max = items.Max(1).FirstOrDefault();

        // Assert
        Assert.AreEqual(0, countRemoved);
        Assert.AreEqual(4, items.Count);
        Assert.AreEqual(1, first);
        Assert.AreEqual(4, last);
        Assert.AreEqual(-5, min);
        Assert.AreEqual(10, max);
    }

    [TestMethod]
    public void Add6Items_Remove2Items_First3Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);
        items.Add(10);
        items.Add(7);
        items.Add(70);

        // Act
        var countRemoved = items.RemoveAll(10);
        var returnedItems = items.First(3).ToList();

        // Assert
        Assert.AreEqual(2, countRemoved);
        var expectedItems = new int[] { 5, -2, 7 };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add7ItemsDuplicates_Remove3Items_First3Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<Product>();
        items.Add(new Product(1.11m, "first"));
        items.Add(new Product(0.50m, "coffee"));
        items.Add(new Product(1.20m, "mint drops"));
        items.Add(new Product(1.20m, "beer"));
        items.Add(new Product(0.50m, "candy"));
        items.Add(new Product(1.20m, "cola"));
        items.Add(new Product(2.99m, "chocolate"));

        // Act
        var countRemoved = items.RemoveAll(new Product(1.20m, null));
        var returnedItems = items.First(3).Select(p => p.Title).ToList();

        // Assert
        Assert.AreEqual(3, countRemoved);
        var expectedItems = new string[] { "first", "coffee", "candy" };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add6Items_Remove2Items_Last3Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(10);
        items.Add(-2);
        items.Add(10);
        items.Add(7);
        items.Add(8);

        // Act
        var countRemoved = items.RemoveAll(10);
        var returnedItems = items.Last(3).ToList();

        // Assert
        Assert.AreEqual(2, countRemoved);
        var expectedItems = new int[] { 8, 7, -2 };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add7ItemsDuplicates_Remove3Items_Last3Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<Product>();
        items.Add(new Product(1.11m, "first"));
        items.Add(new Product(0.50m, "coffee"));
        items.Add(new Product(2.50m, "chocolate"));
        items.Add(new Product(1.20m, "mint drops"));
        items.Add(new Product(1.20m, "beer"));
        items.Add(new Product(0.50m, "candy"));
        items.Add(new Product(1.20m, "cola"));

        // Act
        var countRemoved = items.RemoveAll(new Product(1.20m, null));
        var returnedItems = items.Last(3).Select(p => p.Title).ToList();

        // Assert
        Assert.AreEqual(3, countRemoved);
        var expectedItems = new string[] { "candy", "chocolate", "coffee" };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add5Items_Remove2Items_Min3Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(77);
        items.Add(10);
        items.Add(-2);
        items.Add(10);
        items.Add(7);

        // Act
        var countRemoved = items.RemoveAll(10);
        var returnedItems = items.Min(3).ToList();

        // Assert
        Assert.AreEqual(2, countRemoved);
        var expectedItems = new int[] { -2, 5, 7 };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add7ItemsDuplicates_Remove3Items_Min3Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<Product>();
        items.Add(new Product(0.50m, "coffee"));
        items.Add(new Product(1.20m, "mint drops"));
        items.Add(new Product(1.20m, "beer"));
        items.Add(new Product(2.22m, "chocolate"));
        items.Add(new Product(0.50m, "candy"));
        items.Add(new Product(0.01m, "cent"));
        items.Add(new Product(1.20m, "cola"));

        // Act
        var countRemoved = items.RemoveAll(new Product(1.20m, null));
        var returnedItems = items.Min(3).Select(p => p.Title).ToList();

        // Assert
        Assert.AreEqual(3, countRemoved);
        var expectedItems = new string[] { "cent", "coffee", "candy" };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add6Items_Remove2Items_Max3Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(5);
        items.Add(77);
        items.Add(10);
        items.Add(-2);
        items.Add(10);
        items.Add(7);

        // Act
        var countRemoved = items.RemoveAll(10);
        var returnedItems = items.Max(3).ToList();

        // Assert
        Assert.AreEqual(2, countRemoved);
        var expectedItems = new int[] { 77, 7, 5 };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add7ItemsDuplicates_Remove3Items_Max2Items()
    {
        // Arrange
        var items = FirstLastListFactory.Create<Product>();
        items.Add(new Product(0.50m, "coffee"));
        items.Add(new Product(1.20m, "mint drops"));
        items.Add(new Product(1.20m, "beer"));
        items.Add(new Product(2.22m, "chocolate"));
        items.Add(new Product(0.50m, "candy"));
        items.Add(new Product(0.01m, "cent"));
        items.Add(new Product(1.20m, "cola"));

        // Act
        var countRemoved = items.RemoveAll(new Product(1.20m, null));
        var returnedItems = items.Max(3).Select(p => p.Title).ToList();

        // Assert
        Assert.AreEqual(3, countRemoved);
        var expectedItems = new string[] { "chocolate", "coffee", "candy" };
        CollectionAssert.AreEqual(expectedItems, returnedItems);
    }

    [TestMethod]
    public void Add2Items_Clear_CountShouldBe0()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(1);
        items.Add(-5);

        // Act
        items.Clear();

        // Assert
        Assert.AreEqual(0, items.Count);
    }

    [TestMethod]
    public void Add5Items_Clear_AddItem_CheckFirstLastMinMax()
    {
        // Arrange
        var items = FirstLastListFactory.Create<int>();
        items.Add(1);
        items.Add(-5);
        items.Add(10);
        items.Add(4);

        // Act
        items.Clear();
        items.Add(3);

        // Assert
        Assert.AreEqual(1, items.Count);
        var first = items.First(1).FirstOrDefault();
        var last = items.Last(1).FirstOrDefault();
        var min = items.Min(1).FirstOrDefault();
        var max = items.Max(1).FirstOrDefault();
        Assert.AreEqual(3, first);
        Assert.AreEqual(3, last);
        Assert.AreEqual(3, min);
        Assert.AreEqual(3, max);
    }

    [TestMethod]
    public void ComplexTest_AllOperationsStrings()
    {
        var items = FirstLastListFactory.Create<string>();
        items.Add("zero");
        Assert.AreEqual(1, items.Count);
        Assert.AreEqual("zero", items.First(1).FirstOrDefault());
        Assert.AreEqual("zero", items.Last(1).FirstOrDefault());
        Assert.AreEqual("zero", items.Min(1).FirstOrDefault());
        Assert.AreEqual("zero", items.Max(1).FirstOrDefault());

        items.Clear();
        Assert.AreEqual(0, items.Count);

        items.Add("first");
        items.Add("second");
        items.Add("third");
        items.Add("fourth");
        Assert.AreEqual(4, items.Count);
        Assert.AreEqual("first", items.First(1).FirstOrDefault());
        Assert.AreEqual("fourth", items.Last(1).FirstOrDefault());
        Assert.AreEqual("first", items.Min(1).FirstOrDefault());
        Assert.AreEqual("third", items.Max(1).FirstOrDefault());

        Assert.AreEqual(1, items.RemoveAll("first"));
        Assert.AreEqual(1, items.RemoveAll("fourth"));
        Assert.AreEqual(0, items.RemoveAll("first"));

        Assert.AreEqual(2, items.Count);
        Assert.AreEqual("second", items.First(1).FirstOrDefault());
        Assert.AreEqual("third", items.Last(1).FirstOrDefault());
        Assert.AreEqual("second", items.Min(1).FirstOrDefault());
        Assert.AreEqual("third", items.Max(1).FirstOrDefault());
    }

    [TestMethod]
    public void ComplexTest_AllOperationsProducts()
    {
        var items = FirstLastListFactory.Create<Product>();
        Assert.AreEqual(0, items.Count);

        items.Add(new Product(0.50m, "coffee"));
        Assert.AreEqual(1, items.Count);
        var first = items.First(1).FirstOrDefault();
        var last = items.Last(1).FirstOrDefault();
        var min = items.Min(1).FirstOrDefault();
        var max = items.Max(1).FirstOrDefault();
        Assert.AreEqual("coffee", first.Title);
        Assert.AreEqual("coffee", last.Title);
        Assert.AreEqual("coffee", min.Title);
        Assert.AreEqual("coffee", max.Title);

        items.Add(new Product(0.50m, "candy"));
        Assert.AreEqual(2, items.Count);
        first = items.First(1).FirstOrDefault();
        last = items.Last(1).FirstOrDefault();
        min = items.Min(1).FirstOrDefault();
        max = items.Max(1).FirstOrDefault();
        Assert.AreEqual("coffee", first.Title);
        Assert.AreEqual("candy", last.Title);
        Assert.AreEqual("coffee", min.Title);
        Assert.AreEqual("coffee", max.Title);

        items.Add(new Product(2.99m, "chocolate"));
        Assert.AreEqual(3, items.Count);
        first = items.First(1).FirstOrDefault();
        last = items.Last(1).FirstOrDefault();
        min = items.Min(1).FirstOrDefault();
        max = items.Max(1).FirstOrDefault();
        Assert.AreEqual("coffee", first.Title);
        Assert.AreEqual("chocolate", last.Title);
        Assert.AreEqual("coffee", min.Title);
        Assert.AreEqual("chocolate", max.Title);

        items.Add(new Product(0.50m, "candy"));
        Assert.AreEqual(4, items.Count);
        first = items.First(1).FirstOrDefault();
        last = items.Last(1).FirstOrDefault();
        min = items.Min(1).FirstOrDefault();
        max = items.Max(1).FirstOrDefault();
        Assert.AreEqual("coffee", first.Title);
        Assert.AreEqual("candy", last.Title);
        Assert.AreEqual("coffee", min.Title);
        Assert.AreEqual("chocolate", max.Title);

        var countRemoved =
            items.RemoveAll(new Product(0.50m, "some product"));
        Assert.AreEqual(3, countRemoved);
        Assert.AreEqual(1, items.Count);
        first = items.First(1).FirstOrDefault();
        last = items.Last(1).FirstOrDefault();
        min = items.Min(1).FirstOrDefault();
        max = items.Max(1).FirstOrDefault();
        Assert.AreEqual("chocolate", first.Title);
        Assert.AreEqual("chocolate", last.Title);
        Assert.AreEqual("chocolate", min.Title);
        Assert.AreEqual("chocolate", max.Title);

        items.Add(new Product(0.50m, "candy"));
        Assert.AreEqual(2, items.Count);
        first = items.First(1).FirstOrDefault();
        last = items.Last(1).FirstOrDefault();
        min = items.Min(1).FirstOrDefault();
        max = items.Max(1).FirstOrDefault();
        Assert.AreEqual("chocolate", first.Title);
        Assert.AreEqual("candy", last.Title);
        Assert.AreEqual("candy", min.Title);
        Assert.AreEqual("chocolate", max.Title);

        items.Clear();
        Assert.AreEqual(0, items.Count);

        items.Add(new Product(2.50m, "beer"));
        items.Add(new Product(7.35m, "vodka"));
        items.Add(new Product(0.50m, "coffee"));
        items.Add(new Product(0.50m, "candy"));
        Assert.AreEqual(4, items.Count);
        var first2 = items.First(2).Select(p => p.Title).ToList();
        var last2 = items.Last(2).Select(p => p.Title).ToList();
        var min2 = items.Min(2).Select(p => p.Title).ToList();
        var max2 = items.Max(2).Select(p => p.Title).ToList();
        CollectionAssert.AreEqual(new string[] { "beer", "vodka" }, first2);
        CollectionAssert.AreEqual(new string[] { "candy", "coffee" }, last2);
        CollectionAssert.AreEqual(new string[] { "coffee", "candy" }, min2);
        CollectionAssert.AreEqual(new string[] { "vodka", "beer" }, max2);

        var removedCount = items.RemoveAll(new Product(12345, null));
        Assert.AreEqual(0, removedCount);

        removedCount = items.RemoveAll(new Product(7.35m, null));
        Assert.AreEqual(1, removedCount);

        removedCount = items.RemoveAll(new Product(2.50m, null));
        Assert.AreEqual(1, removedCount);

        Assert.AreEqual(2, items.Count);
        first2 = items.First(2).Select(p => p.Title).ToList();
        last2 = items.Last(2).Select(p => p.Title).ToList();
        min2 = items.Min(2).Select(p => p.Title).ToList();
        max2 = items.Max(2).Select(p => p.Title).ToList();
        CollectionAssert.AreEqual(new string[] { "coffee", "candy" }, first2);
        CollectionAssert.AreEqual(new string[] { "candy", "coffee" }, last2);
        CollectionAssert.AreEqual(new string[] { "coffee", "candy" }, min2);
        CollectionAssert.AreEqual(new string[] { "coffee", "candy" }, max2);

        removedCount = items.RemoveAll(new Product(0.50m, null));
        Assert.AreEqual(2, removedCount);
        Assert.AreEqual(0, items.Count);

        items.Add(new Product(0.50m, "milk"));
        items.Add(new Product(1.20m, "amstel"));
        items.Add(new Product(1.20m, "xxx"));
        Assert.AreEqual(3, items.Count);
        first2 = items.First(2).Select(p => p.Title).ToList();
        last2 = items.Last(2).Select(p => p.Title).ToList();
        min2 = items.Min(2).Select(p => p.Title).ToList();
        max2 = items.Max(2).Select(p => p.Title).ToList();
        CollectionAssert.AreEqual(new string[] { "milk", "amstel" }, first2);
        CollectionAssert.AreEqual(new string[] { "xxx", "amstel" }, last2);
        CollectionAssert.AreEqual(new string[] { "milk", "amstel" }, min2);
        CollectionAssert.AreEqual(new string[] { "amstel", "xxx" }, max2);

        removedCount = items.RemoveAll(new Product(0.50m, null));
        Assert.AreEqual(1, removedCount);
        Assert.AreEqual(2, items.Count);

        removedCount = items.RemoveAll(new Product(1.20m, null));
        Assert.AreEqual(2, removedCount);
        Assert.AreEqual(0, items.Count);

        items.Add(new Product(0.50m, "coffee"));
        Assert.AreEqual(1, items.Count);
        first = items.First(1).FirstOrDefault();
        last = items.Last(1).FirstOrDefault();
        min = items.Min(1).FirstOrDefault();
        max = items.Max(1).FirstOrDefault();
        Assert.AreEqual("coffee", first.Title);
        Assert.AreEqual("coffee", last.Title);
        Assert.AreEqual("coffee", min.Title);
        Assert.AreEqual("coffee", max.Title);
    }
}
