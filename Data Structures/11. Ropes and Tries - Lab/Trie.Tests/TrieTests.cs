using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System.Linq;

[TestClass]
public class TrieTests
{
    [TestMethod]
    public void Insert_Contains_Single_NoMatches()
    {
        Trie<int> trie = new Trie<int>();
        trie.Insert("Andy", 25);

        var a = trie.Contains("A");
        Assert.IsFalse(trie.Contains("A"));
    }

    [TestMethod]
    public void Insert_Contains_Single_Match()
    {
        Trie<int> trie = new Trie<int>();
        trie.Insert("Andy", 25);

        Assert.IsTrue(trie.Contains("Andy"));
    }

    [TestMethod]
    public void Insert_Contains_Multiple()
    {
        Trie<int> trie = new Trie<int>();
        trie.Insert("A", 25);
        trie.Insert("AA", 25);
        trie.Insert("AAA", 25);

        Assert.IsTrue(trie.Contains("A"));
        Assert.IsTrue(trie.Contains("AA"));
        Assert.IsTrue(trie.Contains("AAA"));
    }

    [TestMethod]
    public void GetByPrefix_SingleCharPrefix_NoMatches()
    {
        Trie<int> trie = new Trie<int>();
        trie.Insert("Andy", 25);

        var expected = new string[] { };
        CollectionAssert.AreEqual(expected, new List<string>(trie.GetByPrefix("Z")));
    }

    [TestMethod]
    public void GetByPrefix_SingleCharPrefix_SingleMatch()
    {
        Trie<int> trie = new Trie<int>();
        trie.Insert("Andy", 25);

        var expected = new string[] { "Andy" };
        CollectionAssert.AreEqual(expected, new List<string>(trie.GetByPrefix("A")));
    }

    [TestMethod]
    public void GetByPrefix_SingleCharPrefix_MultipleMatches()
    {
        Trie<int> trie = new Trie<int>();
        trie.Insert("Andy", 25);
        trie.Insert("Amy", 8);
        trie.Insert("Adam", 12);
        trie.Insert("Bill", 13);

        var expected = new string[] { "Andy", "Amy", "Adam" };
        CollectionAssert.AreEqual(expected, new List<string>(trie.GetByPrefix("A")));
    }

    [TestMethod]
    public void GetByPrefix_TwoCharPrefix_SingleMatch()
    {
        Trie<int> trie = new Trie<int>();
        trie.Insert("Andy", 25);

        var expected = new string[] { "Andy" };
        CollectionAssert.AreEqual(expected, new List<string>(trie.GetByPrefix("An")));
    }

    [TestMethod]
    public void GetByPrefix_TwoCharPrefix_MultipleMatches()
    {
        Trie<int> trie = new Trie<int>();
        trie.Insert("Andy", 25);
        trie.Insert("Andy M", 8);
        trie.Insert("Adam", 12);
        trie.Insert("Bill", 13);

        var expected = new string[] { "Andy", "Andy M" };
        CollectionAssert.AreEqual(expected, new List<string>(trie.GetByPrefix("An")));
    }

    [TestMethod]
    public void GetValue_Single()
    {
        Trie<int> trie = new Trie<int>();
        trie.Insert("Andy", 25);
        
        Assert.AreEqual(25, trie.GetValue("Andy"));
    }

    [TestMethod]
    public void GetValue_Multiple()
    {
        Trie<int> trie = new Trie<int>();
        trie.Insert("Andy", 25);
        trie.Insert("Andy M", 8);
        trie.Insert("Adam", 12);
        trie.Insert("Bill", 13);

        var expected = new int[] { 25, 8, 12, 13 };
        var keys = new List<string>(trie.GetByPrefix(""));
        for (int i = 0; i < keys.Count; i++)
        {
            Assert.AreEqual(expected[i], trie.GetValue(keys[i]));
        }
    }
}
