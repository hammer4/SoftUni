using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test12
{
    [TestCase]
    public void GetById_On_Empty_Chainblock_ShouldThrow()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        //Act
        //Assert
        Assert.Throws<InvalidOperationException>(() => cb.GetById(5));
    }

}

