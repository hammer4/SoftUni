
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test39
{

    [TestCase]
    public void GetBySenderAndMinimumAmountDescending_ShouldThrowOnEmpty_CB()
    {
        //Arrange
        IChainblock cb = new Chainblock();
        //Act
        //Assert
        Assert.Throws<InvalidOperationException>(() => {
            cb.GetBySenderAndMinimumAmountDescending("pesho", 5);
        });
    }
}

