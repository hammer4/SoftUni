using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTestsBinaryTree
{
    [TestMethod]
    public void BuildBinaryTree_ForEachTraversal_InOrder_ShouldWorkCorrectly()
    {
        // Arrange
        var binaryTree =
            new BinaryTree<string>("*",
                new BinaryTree<string>("+",
                    new BinaryTree<string>("3"),
                    new BinaryTree<string>("2")),
                new BinaryTree<string>("-",
                    new BinaryTree<string>("9"),
                    new BinaryTree<string>("6")));

        // Act
        var nodes = new List<string>();
        binaryTree.EachInOrder(nodes.Add);

        // Assert
        var expectedNodes = new string[] { "3", "+", "2", "*", "9", "-", "6" };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void BuildBinaryTree_ForEachTraversal_PostOrder_ShouldWorkCorrectly()
    {
        // Arrange
        var binaryTree =
            new BinaryTree<string>("*",
                new BinaryTree<string>("+",
                    new BinaryTree<string>("3"),
                    new BinaryTree<string>("2")),
                new BinaryTree<string>("-",
                    new BinaryTree<string>("9"),
                    new BinaryTree<string>("6")));

        // Act
        var nodes = new List<string>();
        binaryTree.EachPostOrder(nodes.Add);

        // Assert
        var expectedNodes = new string[] { "3", "2", "+", "9", "6", "-", "*" };
        CollectionAssert.AreEqual(expectedNodes, nodes);
    }

    [TestMethod]
    public void BuildBinaryTree_PrintIndentedPreOrder_ShouldWorkCorrectly()
    {
        // Arrange
        var binaryTree =
            new BinaryTree<string>("*",
                new BinaryTree<string>("-",
                    new BinaryTree<string>("+",
                        new BinaryTree<string>("3"),
                        new BinaryTree<string>("2")),
                    new BinaryTree<string>("*",
                        new BinaryTree<string>("9"),
                        new BinaryTree<string>("6"))),
                new BinaryTree<string>("8"));

        // Act
        var outputStream = new MemoryStream();
        using (var outputWriter = new StreamWriter(outputStream))
        {
            Console.SetOut(outputWriter);
            binaryTree.PrintIndentedPreOrder();
        }
        var output = Encoding.UTF8.GetString(outputStream.ToArray());

        // Assert
        var expectedOutput = "*\n  -\n    +\n      3\n      2\n    *\n      9\n      6\n  8\n";
        output = output.Replace("\r\n", "\n");
        Assert.AreEqual(expectedOutput, output);
    }
}
