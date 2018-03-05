using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

[TestClass]
public class PerformanceTestsPersonCollection
{
    private void AddPersons(int count, PersonCollection persons)
    {
        for (int i = 0; i < count; i++)
        {
            persons.AddPerson(
                email: "pesho" + i + "@gmail" + (i % 100) + ".com",
                name: "Pesho" + (i % 100),
                age: i % 100,
                town: "Sofia" + (i % 100));
        }
    }

    [TestMethod]
    [Timeout(250)]
    public void TestPerformance_AddPerson()
    {
        // Arrange
        var persons = new PersonCollection();

        // Act
        AddPersons(5000, persons);
        Assert.AreEqual(5000, persons.Count);
    }

    [TestMethod]
    [Timeout(200)]
    public void TestPerformance_FindPerson()
    {
        // Arrange
        var persons = new PersonCollection();
        AddPersons(5000, persons);

        // Act
        for (int i = 0; i < 100000; i++)
        {
            var existingPerson = persons.FindPerson("pesho1@gmail1.com");
            Assert.IsNotNull(existingPerson);
            var nonExistingPerson = persons.FindPerson("non-existing email");
            Assert.IsNull(nonExistingPerson);
        }
    }

    [TestMethod]
    [Timeout(300)]
    public void TestPerformance_FindPersonsByEmailDomain()
    {
        // Arrange
        var persons = new PersonCollection();
        AddPersons(5000, persons);

        // Act
        for (int i = 0; i < 10000; i++)
        {
            var existingPersons =
                persons.FindPersons("gmail1.com").ToList();
            Assert.AreEqual(50, existingPersons.Count);
            var notExistingPersons =
                persons.FindPersons("non-existing email").ToList();
            Assert.AreEqual(0, notExistingPersons.Count);
        }
    }

    [TestMethod]
    [Timeout(300)]
    public void TestPerformance_FindPersonsByNameAndTown()
    {
        // Arrange
        var persons = new PersonCollection();
        AddPersons(5000, persons);

        // Act
        for (int i = 0; i < 10000; i++)
        {
            var existingPersons =
                persons.FindPersons("Pesho1", "Sofia1").ToList();
            Assert.AreEqual(50, existingPersons.Count);
            var notExistingPersons =
                persons.FindPersons("Pesho1", "Sofia5").ToList();
            Assert.AreEqual(0, notExistingPersons.Count);
        }
    }

    [TestMethod]
    [Timeout(300)]
    public void TestPerformance_FindPersonsByAgeRange()
    {
        // Arrange
        var persons = new PersonCollection();
        AddPersons(5000, persons);

        // Act
        for (int i = 0; i < 2000; i++)
        {
            var existingPersons =
                persons.FindPersons(20, 21).ToList();
            Assert.AreEqual(100, existingPersons.Count);
            var notExistingPersons =
                persons.FindPersons(500, 600).ToList();
            Assert.AreEqual(0, notExistingPersons.Count);
        }
    }

    [TestMethod]
    [Timeout(300)]
    public void TestPerformance_FindPersonsByTownAndAgeRange()
    {
        // Arrange
        var persons = new PersonCollection();
        AddPersons(5000, persons);

        // Act
        for (int i = 0; i < 5000; i++)
        {
            var existingPersons =
                persons.FindPersons(18, 22, "Sofia20").ToList();
            Assert.AreEqual(50, existingPersons.Count);
            var notExistingTownPersons =
                persons.FindPersons(20, 30, "Missing town").ToList();
            Assert.AreEqual(0, notExistingTownPersons.Count);
            var notExistingAgePersons =
                persons.FindPersons(200, 300, "Sofia1").ToList();
            Assert.AreEqual(0, notExistingTownPersons.Count);
        }
    }
}
