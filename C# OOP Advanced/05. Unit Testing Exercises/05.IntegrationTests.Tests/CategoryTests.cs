using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class CategoryTests
{
    [Test]
    public void AssignToParentCategoryShouldWork()
    {
        var parent = new Category("Parent");
        var child = new Category("Child");

        child.AssignToParentCategory(parent);

        Assert.That(parent.Subcategories, Contains.Item(child));
    }

    [Test]
    public void RemoveSubcategoryShouldWork()
    {
        var parent = new Category("Parent");
        var child = new Category("Child");

        child.AssignToParentCategory(parent);
        parent.RemoveSubcategory(child);

        Assert.That(parent.Subcategories, Does.Not.Contain(child));
    }

    [Test]
    public void AssignUserToCategoryShouldWork()
    {
        var category = new Category("One");
        var user = new User("Gosho");

        category.AssignUserToCategory(user);

        Assert.That(category.Users, Contains.Item(user));
    }
}