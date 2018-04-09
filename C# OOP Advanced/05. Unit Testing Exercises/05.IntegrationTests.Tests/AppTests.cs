using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AppTests
{
    private Category categoryOne;
    private Category categoryTwo;
    private Category categoryThree;
    private User gosho;
    private User pesho;

    private App app;

    [SetUp]
    public void TestInit()
    {
        categoryOne = new Category("One");
        categoryTwo = new Category("Two");
        categoryThree = new Category("Three");

        gosho = new User("Gosho");
        pesho = new User("Pesho");

        app = new App();
    }

    [Test]
    public void AddCategoryNonExistingCategoryShouldWork()
    {
        app.AddCategory(categoryOne);

        Assert.That(app.Categories, Contains.Item(categoryOne));
    }

    [Test]
    public void AddSameCategoryTwiceShouldThrow()
    {
        app.AddCategory(categoryOne);

        Assert.That(() => app.AddCategory(categoryOne), Throws.InvalidOperationException);
    }

    [Test]
    public void RemoveCategoryShouldWork()
    {
        app.AddCategory(categoryOne);
        app.RemoveCategory(categoryOne);

        Assert.That(app.Categories, Does.Not.Contain(categoryOne));
    }

    [Test]
    public void RemoveNonExistingCategoryShouldThrow()
    {
        app.AddCategory(categoryOne);

        Assert.That(() => app.RemoveCategory(categoryTwo), Throws.InvalidOperationException);
    }

    [Test]
    public void RemoveChildCategoryShouldRemove()
    {
        app.AddCategory(categoryOne);
        app.AddCategory(categoryTwo);

        app.AssignChildCategoryToParentCategory(categoryOne, categoryTwo);
        app.RemoveCategory(categoryTwo);

        Assert.That(categoryOne.Subcategories, Does.Not.Contain(categoryTwo));
    }

    [Test]
    public void RemoveParentCategoryShouldTransferItsUsersToSubcategories()
    {
        app.AddCategory(categoryOne);
        app.AddCategory(categoryTwo);
        app.AddCategory(categoryThree);

        app.AddUser(pesho);
        app.AddUser(gosho);

        app.AssignChildCategoryToParentCategory(categoryOne, categoryTwo);
        app.AssignChildCategoryToParentCategory(categoryOne, categoryThree);

        app.AssignUserToCategory(categoryOne, pesho);
        app.AssignUserToCategory(categoryOne, gosho);

        app.RemoveCategory(categoryOne);

        Assert.That(categoryTwo.Users.Count, Is.EqualTo(2));
        Assert.That(categoryThree.Users.Count, Is.EqualTo(2));
    }

    [Test]
    public void AssignChildCategoryToParentShouldAssignIt()
    {
        app.AddCategory(categoryOne);
        app.AddCategory(categoryTwo);

        app.AssignChildCategoryToParentCategory(categoryOne, categoryTwo);

        Assert.That(app.Categories.First().Subcategories, Contains.Item(categoryTwo));
    }

    [Test]
    public void AssignChildCategoryToParentNonExistentParentShoudThrow()
    {
        app.AddCategory(categoryOne);

        Assert.That(() => app.AssignChildCategoryToParentCategory(categoryTwo, categoryOne), Throws.InvalidOperationException);
    }

    [Test]
    public void AssignChildCategoryToParentNonExistentchildShoudThrow()
    {
        app.AddCategory(categoryOne);

        Assert.That(() => app.AssignChildCategoryToParentCategory(categoryOne, categoryTwo), Throws.InvalidOperationException);
    }

    [Test]
    public void AssignChildCategoryToParentRemoveChildFromPreviousParent()
    {
        app.AddCategory(categoryOne);
        app.AddCategory(categoryTwo);
        app.AddCategory(categoryThree);

        app.AssignChildCategoryToParentCategory(categoryOne, categoryTwo);
        app.AssignChildCategoryToParentCategory(categoryThree, categoryTwo);

        Assert.That(app.Categories.First().Subcategories.Count, Is.EqualTo(0));
        Assert.That(app.Categories.Last().Subcategories.Count, Is.EqualTo(1));
    }

    [Test]
    public void AssignUserToCategoryAssignsthem()
    {
        app.AddUser(gosho);
        app.AddCategory(categoryOne);

        app.AssignUserToCategory(categoryOne, gosho);

        Assert.That(app.Categories.First().Users, Contains.Item(gosho));
        Assert.That(app.Users.First().Categories, Contains.Item(categoryOne));
    }

    [Test]
    public void AssignUserToCategoryNonExistingUserShouldThrow()
    {
        app.AddCategory(categoryOne);

        Assert.That(() => app.AssignUserToCategory(categoryOne, gosho), Throws.InvalidOperationException);
    }

    [Test]
    public void assignUserToCategoryNonExistinggCategoryShouldThrow()
    {
        app.AddUser(gosho);

        Assert.That(() => app.AssignUserToCategory(categoryOne, gosho), Throws.InvalidOperationException);
    }
}