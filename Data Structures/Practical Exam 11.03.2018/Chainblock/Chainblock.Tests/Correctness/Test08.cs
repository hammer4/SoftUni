using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test08
{
    [TestCase]
    public void Count_Should_Be_0_On_EmptyCollection()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        //Act
        //Assert
        Assert.AreEqual(0, cb.Count);
    }
}