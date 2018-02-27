using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTestsHashTable
{
    [TestMethod]
    public void Add_EmptyHashTable_NoDuplicates_ShouldAddElement()
    {
        // Arrange
        HashTable<string, int> hashTable = new HashTable<string, int>();

        // Act
        KeyValue<string, int>[] elements = {
            new KeyValue<string, int>("Peter", 5), 
            new KeyValue<string, int>("Maria", 6), 
            new KeyValue<string, int>("George", 4), 
            new KeyValue<string, int>("Kiril", 5)
        };
        foreach (KeyValue<string, int> element in elements)
        {
            hashTable.Add(element.Key, element.Value);
        }

        // Assert
        List<KeyValue<string, int>> actualElements = hashTable.ToList();
        CollectionAssert.AreEquivalent(elements, actualElements);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Add_EmptyHashTable_Duplicates_ShouldThrowException()
    {
        // Arrange
        HashTable<string, string> hashTable = new HashTable<string, string> {{"Peter", "first"}, {"Peter", "second"}};

        // Act
    }

    [TestMethod]
    public void Add_1000_Elements_Grow_ShouldWorkCorrectly()
    {
        // Arrange
        HashTable<string, int> hashTable = new HashTable<string, int>(1);

        // Act
        List<KeyValue<string, int>> expectedElements = new List<KeyValue<string, int>>();
        for (int i = 0; i < 1000; i++)
        {
            hashTable.Add("key" + i, i);
            expectedElements.Add(new KeyValue<string, int>("key" + i, i));
        }

        // Assert
        List<KeyValue<string, int>> actualElements = hashTable.ToList();
        CollectionAssert.AreEquivalent(expectedElements, actualElements);
    }

    [TestMethod]
    public void AddOrReplace_WithDuplicates_ShouldWorkCorrectly()
    {
        // Arrange
        HashTable<string, int> hashTable = new HashTable<string, int>();

        // Act
        hashTable.AddOrReplace("Peter", 555);
        hashTable.AddOrReplace("Maria", 999);
        hashTable.AddOrReplace("Maria", 123);
        hashTable.AddOrReplace("Maria", 6);
        hashTable.AddOrReplace("Peter", 5);

        // Assert
        KeyValue<string, int>[] expectedElements = {
            new KeyValue<string, int>("Peter", 5), 
            new KeyValue<string, int>("Maria", 6)
        };
        List<KeyValue<string, int>> actualElements = hashTable.ToList();
        CollectionAssert.AreEquivalent(expectedElements, actualElements);
    }

    [TestMethod]
    public void Count_Empty_Add_Remove_ShouldWorkCorrectly()
    {
        // Arrange
        HashTable<string, int> hashTable = new HashTable<string, int>();

        // Assert
        Assert.AreEqual(0, hashTable.Count);

        // Act & Assert
        hashTable.Add("Peter", 555);
        hashTable.AddOrReplace("Peter", 555);
        hashTable.AddOrReplace("Ivan", 555);
        Assert.AreEqual(2, hashTable.Count);

        // Act & Assert
        hashTable.Remove("Peter");
        Assert.AreEqual(1, hashTable.Count);

        // Act & Assert
        hashTable.Remove("Peter");
        Assert.AreEqual(1, hashTable.Count);

        // Act & Assert
        hashTable.Remove("Ivan");
        Assert.AreEqual(0, hashTable.Count);
    }

    [TestMethod]
    public void Get_ExistingElement_ShouldReturnTheValue()
    {
        // Arrange
        HashTable<int, string> hashTable = new HashTable<int, string> {{555, "Peter"}};

        // Act
        string actualValue = hashTable.Get(555);

        // Assert
        Assert.AreEqual("Peter", actualValue);
    }

    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void Get_NonExistingElement_ShouldThrowException()
    {
        // Arrange
        HashTable<int, string> hashTable = new HashTable<int, string>();

        // Act
        hashTable.Get(12345);
    }

    [TestMethod]
    public void Indexer_ExistingElement_ShouldReturnTheValue()
    {
        // Arrange
        HashTable<int, string> hashTable = new HashTable<int, string> {{555, "Peter"}};

        // Act
        string actualValue = hashTable[555];

        // Assert
        Assert.AreEqual("Peter", actualValue);
    }

    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void Indexer_NonExistingElement_ShouldThrowException()
    {
        // Arrange
        HashTable<int, string> hashTable = new HashTable<int, string>();

        // Act
        string value = hashTable[12345];
    }

    [TestMethod]
    public void Indexer_AddReplace_WithDuplicates_ShouldWorkCorrectly()
    {
        // Arrange
        HashTable<string, int> hashTable = new HashTable<string, int>
        {
            ["Peter"] = 555,
            ["Maria"] = 999,
            ["Maria"] = 123,
            ["Maria"] = 6,
            ["Peter"] = 5
        };

        // Act

        // Assert
        KeyValue<string, int>[] expectedElements = {
            new KeyValue<string, int>("Peter", 5), 
            new KeyValue<string, int>("Maria", 6)
        };
        List<KeyValue<string, int>> actualElements = hashTable.ToList();
        CollectionAssert.AreEquivalent(expectedElements, actualElements);
    }

    [TestMethod]
    public void Capacity_Grow_ShouldWorkCorrectly()
    {
        // Arrange
        HashTable<string, int> hashTable = new HashTable<string, int>(2);

        // Assert
        Assert.AreEqual(2, hashTable.Capacity);

        // Act
        hashTable.Add("Peter", 123);
        hashTable.Add("Maria", 456);

        // Assert
        Assert.AreEqual(4, hashTable.Capacity);

        // Act
        hashTable.Add("Tanya", 555);
        hashTable.Add("George", 777);

        // Assert
        Assert.AreEqual(8, hashTable.Capacity);
    }

    [TestMethod]
    public void TryGetValue_ExistingElement_ShouldReturnTheValue()
    {
        // Arrange
        HashTable<int, string> hashTable = new HashTable<int, string> {{555, "Peter"}};

        // Act
        bool result = hashTable.TryGetValue(555, out string value);

        // Assert
        Assert.AreEqual("Peter", value);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TryGetValue_NonExistingElement_ShouldReturnFalse()
    {
        // Arrange
        HashTable<int, string> hashTable = new HashTable<int, string>();

        // Act
        bool result = hashTable.TryGetValue(555, out string value);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Find_ExistingElement_ShouldReturnTheElement()
    {
        // Arrange
        HashTable<string, DateTime> hashTable = new HashTable<string, DateTime>();
        string name = "Maria";
        DateTime date = new DateTime(1995, 7, 18);
        hashTable.Add(name, date);

        // Act
        KeyValue<string, DateTime> element = hashTable.Find(name);

        // Assert
        KeyValue<string, DateTime> expectedElement = new KeyValue<string, DateTime>(name, date);
        Assert.AreEqual(expectedElement, element);
    }

    [TestMethod]
    public void Find_NonExistingElement_ShouldReturnNull()
    {
        // Arrange
        HashTable<string, DateTime> hashTable = new HashTable<string, DateTime>();

        // Act
        KeyValue<string, DateTime> element = hashTable.Find("Maria");

        // Assert
        Assert.IsNull(element);
    }

    [TestMethod]
    public void ContainsKey_ExistingElement_ShouldReturnTrue()
    {
        // Arrange
        HashTable<DateTime, string> hashTable = new HashTable<DateTime, string>();
        DateTime date = new DateTime(1995, 7, 18);
        hashTable.Add(date, "Some value");

        // Act
        bool containsKey = hashTable.ContainsKey(date);

        // Assert
        Assert.IsTrue(containsKey);
    }

    [TestMethod]
    public void ContainsKey_NonExistingElement_ShouldReturnFalse()
    {
        // Arrange
        HashTable<DateTime, string> hashTable = new HashTable<DateTime, string>();
        DateTime date = new DateTime(1995, 7, 18);

        // Act
        bool containsKey = hashTable.ContainsKey(date);

        // Assert
        Assert.IsFalse(containsKey);
    }

    [TestMethod]
    public void Remove_ExistingElement_ShouldWorkCorrectly()
    {
        // Arrange
        HashTable<string, double> hashTable = new HashTable<string, double> {{"Peter", 12.5}, {"Maria", 99.9}};

        // Assert
        Assert.AreEqual(2, hashTable.Count);

        // Act
        bool removed = hashTable.Remove("Peter");

        // Assert
        Assert.IsTrue(removed);
        Assert.AreEqual(1, hashTable.Count);
    }

    [TestMethod]
    public void Remove_NonExistingElement_ShouldWorkCorrectly()
    {
        // Arrange
        HashTable<string, double> hashTable = new HashTable<string, double> {{"Peter", 12.5}, {"Maria", 99.9}};

        // Assert
        Assert.AreEqual(2, hashTable.Count);

        // Act
        bool removed = hashTable.Remove("George");

        // Assert
        Assert.IsFalse(removed);
        Assert.AreEqual(2, hashTable.Count);
    }

    [TestMethod]
    public void Remove_5000_Elements_ShouldWorkCorrectly()
    {
        // Arrange
        HashTable<string, int> hashTable = new HashTable<string, int>();
        List<string> keys = new List<string>();
        int count = 5000;
        for (int i = 0; i < count; i++)
        {
            string key = Guid.NewGuid().ToString();
            keys.Add(key);
            hashTable.Add(key, i);
        }

        // Assert
        Assert.AreEqual(count, hashTable.Count);

        // Act & Assert
        keys.Reverse();
        foreach (string key in keys)
        {
            hashTable.Remove(key);
            count--;
            Assert.AreEqual(count, hashTable.Count);
        }

        // Assert
        List<KeyValue<string, int>> expectedElements = new List<KeyValue<string, int>>();
        List<KeyValue<string, int>> actualElements = hashTable.ToList();
        CollectionAssert.AreEquivalent(expectedElements, actualElements);
    }

    [TestMethod]
    public void Clear_ShouldWorkCorrectly()
    {
        // Arrange
        HashTable<string, int> hashTable = new HashTable<string, int>();

        // Assert
        Assert.AreEqual(0, hashTable.Count);

        // Act
        hashTable.Clear();

        // Assert
        Assert.AreEqual(0, hashTable.Count);

        // Arrange
        hashTable.Add("Peter", 5);
        hashTable.Add("George", 7);
        hashTable.Add("Maria", 3);

        // Assert
        Assert.AreEqual(3, hashTable.Count);

        // Act
        hashTable.Clear();

        // Assert
        Assert.AreEqual(0, hashTable.Count);
        List<KeyValue<string, int>> expectedElements = new List<KeyValue<string, int>>();
        List<KeyValue<string, int>> actualElements = hashTable.ToList();
        CollectionAssert.AreEquivalent(expectedElements, actualElements);

        hashTable.Add("Peter", 5);
        hashTable.Add("George", 7);
        hashTable.Add("Maria", 3);

        // Assert
        Assert.AreEqual(3, hashTable.Count);
    }

    [TestMethod]
    public void Keys_ShouldWorkCorrectly()
    {
        // Arrange
        HashTable<string, double> hashTable = new HashTable<string, double>();

        // Assert
        CollectionAssert.AreEquivalent(new string[0], hashTable.Keys.ToArray());

        // Arrange
        hashTable.Add("Peter", 12.5);
        hashTable.Add("Maria", 99.9);
        hashTable["Peter"] = 123.45;

        // Act
        IEnumerable<string> keys = hashTable.Keys;

        // Assert
        string[] expectedKeys = { "Peter", "Maria" };
        CollectionAssert.AreEquivalent(expectedKeys, keys.ToArray());
    }

    [TestMethod]
    public void Values_ShouldWorkCorrectly()
    {
        // Arrange
        HashTable<string, double> hashTable = new HashTable<string, double>();

        // Assert
        CollectionAssert.AreEquivalent(new string[0], hashTable.Values.ToArray());

        // Arrange
        hashTable.Add("Peter", 12.5);
        hashTable.Add("Maria", 99.9);
        hashTable["Peter"] = 123.45;

        // Act
        IEnumerable<double> values = hashTable.Values;

        // Assert
        double[] expectedValues = { 99.9, 123.45 };
        CollectionAssert.AreEquivalent(expectedValues, values.ToArray());
    }
}
