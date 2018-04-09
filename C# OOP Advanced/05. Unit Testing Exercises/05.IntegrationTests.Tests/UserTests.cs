using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class UserTests
{
    [Test]
    public void AssignToCategoryShouldWork()
    {
        var category = new Category("One");
        var user = new User("Gosho");

        user.AssignToCategory(category);

        Assert.That(user.Categories, Contains.Item(category));
    }
}