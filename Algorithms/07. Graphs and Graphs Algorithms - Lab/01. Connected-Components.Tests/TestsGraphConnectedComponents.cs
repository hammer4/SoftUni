using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

[TestClass]
public class TestsGraphConnectedComponents
{
    [TestMethod]
    public void TestGraphConnectedComponents9Vertices()
    {
        // Arrange
        var input =
            "9" + "\n" +
            "3 6" + "\n" +
            "3 4 5 6" + "\n" +
            "8" + "\n" +
            "0 1 5" + "\n" +
            "1 6" + "\n" +
            "1 3" + "\n" +
            "0 1 4" + "\n" +
            "" + "\n" +
            "2" + "\n";

        // Act
        var inputReader = new StringReader(input);
        var outputWriter = new StringWriter();
        using (outputWriter)
        {
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);
            GraphConnectedComponents.Main();
        }
        var output = outputWriter.ToString();

        // Assert
        var expectedOutput =
            "Connected component: 6 4 5 1 3 0" + "\n" +
            "Connected component: 8 2" + "\n" +
            "Connected component: 7" + "\n";
        output = output.Replace("\r\n", "\n");
        Assert.AreEqual(expectedOutput, output);
    }

    [TestMethod]
    public void TestGraphConnectedComponents1Vertex()
    {
        // Arrange
        var input =
            "1" + "\n" +
            "0" + "\n";

        // Act
        var inputReader = new StringReader(input);
        var outputWriter = new StringWriter();
        using (outputWriter)
        {
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);
            GraphConnectedComponents.Main();
        }
        var output = outputWriter.ToString();

        // Assert
        var expectedOutput =
            "Connected component: 0\n";
        output = output.Replace("\r\n", "\n");
        Assert.AreEqual(expectedOutput, output);
    }

    [TestMethod]
    public void TestGraphConnectedComponents0Vertices()
    {
        // Arrange
        var input =
            "0" + "\n";

        // Act
        var inputReader = new StringReader(input);
        var outputWriter = new StringWriter();
        using (outputWriter)
        {
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);
            GraphConnectedComponents.Main();
        }
        var output = outputWriter.ToString();

        // Assert
        var expectedOutput = "";
        Assert.AreEqual(expectedOutput, output);
    }

    [TestMethod]
    public void TestGraphConnectedComponents7Vertices()
    {
        // Arrange
        var input =
            "7" + "\n" +
            "" + "\n" +
            "2 6" + "\n" +
            "1" + "\n" +
            "4" + "\n" +
            "3" + "\n" +
            "" + "\n" +
            "1" + "\n" +
            "" + "\n";

        // Act
        var inputReader = new StringReader(input);
        var outputWriter = new StringWriter();
        using (outputWriter)
        {
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);
            GraphConnectedComponents.Main();
        }
        var output = outputWriter.ToString();

        // Assert
        var expectedOutput =
            "Connected component: 0" + "\n" +
            "Connected component: 2 6 1" + "\n" +
            "Connected component: 4 3" + "\n" +
            "Connected component: 5" + "\n";
        output = output.Replace("\r\n", "\n");
        Assert.AreEqual(expectedOutput, output);
    }

    [TestMethod]
    public void TestGraphConnectedComponents4Vertices()
    {
        // Arrange
        var input =
            "4" + "\n" +
            "1 2 3" + "\n" +
            "0 1 2 3" + "\n" +
            "0 1 3" + "\n" +
            "1 2" + "\n";

        // Act
        var inputReader = new StringReader(input);
        var outputWriter = new StringWriter();
        using (outputWriter)
        {
            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);
            GraphConnectedComponents.Main();
        }
        var output = outputWriter.ToString();

        // Assert
        var expectedOutput =
            "Connected component: 3 2 1 0\n";
        output = output.Replace("\r\n", "\n");
        Assert.AreEqual(expectedOutput, output);
    }
}
