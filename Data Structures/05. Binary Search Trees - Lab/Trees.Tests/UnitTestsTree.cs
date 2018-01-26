using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTestsTree
{
    [TestMethod]
    public void BuildTree_ForEachTraversal_ShouldWorkCorrectly()
    {
        // Arrange
        var tree =
            new Tree<int>(7,
                new Tree<int>(19,
                    new Tree<int>(1),
                    new Tree<int>(12),
                    new Tree<int>(31)),
                new Tree<int>(21),
                new Tree<int>(14,
                    new Tree<int>(23),
                    new Tree<int>(6)));
        // Act
        var nodes = new List<int>();
        tree.Each(nodes.Add);

        // Assert
        var expectedNodes = new int[] { 7, 19, 1, 12, 31, 21, 14, 23, 6 };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void BuildTree_PrintTree_ShouldWorkCorrectly()
    {
        // Arrange
        var tree =
            new Tree<int>(7,
                new Tree<int>(19,
                    new Tree<int>(1),
                    new Tree<int>(12),
                    new Tree<int>(31)),
                new Tree<int>(21),
                new Tree<int>(14,
                    new Tree<int>(23),
                    new Tree<int>(6)));

        // Act
        var outputStream = new MemoryStream();
        using (var outputWriter = new StreamWriter(outputStream))
        {
            Console.SetOut(outputWriter);
            tree.Print();
        }
        var output = Encoding.UTF8.GetString(outputStream.ToArray());

        // Assert
        var expectedOutput = "7\n  19\n    1\n    12\n    31\n  21\n  14\n    23\n    6\n";
        output = output.Replace("\r\n", "\n");
        Assert.AreEqual(expectedOutput, output);
    }
}
