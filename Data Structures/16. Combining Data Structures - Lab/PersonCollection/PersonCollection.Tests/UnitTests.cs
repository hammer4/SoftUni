using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

[TestClass]
public class UnitTestsPersonCollection
{
    [TestMethod]
    public void AddPerson_ShouldWorkCorrectly()
    {
        // Arrange
        var persons = new PersonCollection();

        // Act
        var isAdded =
            persons.AddPerson("pesho@gmail.com", "Peter", 18, "Sofia");

        // Assert
        Assert.IsTrue(isAdded);
        Assert.AreEqual(1, persons.Count);
    }

    [TestMethod]
    public void AddPerson_DuplicatedEmail_ShouldWorkCorrectly()
    {
        // Arrange
        var persons = new PersonCollection();

        // Act
        var isAddedFirst =
            persons.AddPerson("pesho@gmail.com", "Peter", 18, "Sofia");
        var isAddedSecond =
            persons.AddPerson("pesho@gmail.com", "Maria", 24, "Plovdiv");

        // Assert
        Assert.IsTrue(isAddedFirst);
        Assert.IsFalse(isAddedSecond);
        Assert.AreEqual(1, persons.Count);
    }

    [TestMethod]
    public void FindPerson_ExistingPerson_ShouldReturnPerson()
    {
        // Arrange
        var persons = new PersonCollection();

        persons.AddPerson("pesho@gmail.com", "Peter", 28, "Plovdiv");

        // Act
        var person = persons.FindPerson("pesho@gmail.com");

        // Assert
        Assert.IsNotNull(person);
    }

    [TestMethod]
    public void FindPerson_NonExistingPerson_ShouldReturnNothing()
    {
        // Arrange
        var persons = new PersonCollection();

        // Act
        var person = persons.FindPerson("pesho@gmail.com");

        // Assert
        Assert.IsNull(person);
    }

    [TestMethod]
    public void DeletePerson_ShouldWorkCorrectly()
    {
        // Arrange
        var persons = new PersonCollection();
        persons.AddPerson("pesho@gmail.com", "Peter", 28, "Plovdiv");

        // Act
        var isDeletedExisting =
            persons.DeletePerson("pesho@gmail.com");
        var isDeletedNonExisting =
            persons.DeletePerson("pesho@gmail.com");

        // Assert
        Assert.IsTrue(isDeletedExisting);
        Assert.IsFalse(isDeletedNonExisting);
        Assert.AreEqual(0, persons.Count);
    }

    [TestMethod]
    public void FindPersonsByEmailDomain_ShouldReturnMatchingPersons()
    {
        // Arrange
        var persons = new PersonCollection();

        persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Sofia");
        persons.AddPerson("mary@gmail.com", "Maria", 21, "Plovdiv");
        persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");

        // Act
        var personsGmail = persons.FindPersons("gmail.com");
        var personsYahoo = persons.FindPersons("yahoo.co.uk");
        var personsHoo = persons.FindPersons("hoo.co.uk");

        // Assert
        CollectionAssert.AreEqual(
            new string[] { "ani@gmail.com", "mary@gmail.com", "pesho@gmail.com" },
            personsGmail.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "kiro@yahoo.co.uk" },
            personsYahoo.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { },
            personsHoo.Select(p => p.Email).ToList());
    }

    [TestMethod]
    public void FindPersonsByNameAndTown_ShouldReturnMatchingPersons()
    {
        // Arrange
        var persons = new PersonCollection();
        persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Sofia");
        persons.AddPerson("pepi@gmail.com", "Pesho", 21, "Plovdiv");
        persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");
        persons.AddPerson("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");

        // Act
        var personsPeshoPlovdiv = persons.FindPersons("Pesho", "Plovdiv");
        var personsLowercase = persons.FindPersons("pesho", "plovdiv");
        var personsPeshoNoTown = persons.FindPersons("Pesho", null);
        var personsAnnaBourgas = persons.FindPersons("Anna", "Bourgas");

        // Assert
        CollectionAssert.AreEqual(
            new string[] { "pepi@gmail.com", "pepi2@yahoo.fr", "pesho@gmail.com" },
            personsPeshoPlovdiv.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { },
            personsLowercase.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { },
            personsPeshoNoTown.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "ani@gmail.com" },
            personsAnnaBourgas.Select(p => p.Email).ToList());
    }

    [TestMethod]
    public void FindPersonsByAgeRange_ShouldReturnMatchingPersons()
    {
        // Arrange
        var persons = new PersonCollection();
        persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Sofia");
        persons.AddPerson("pepi@gmail.com", "Pesho", 21, "Plovdiv");
        persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");
        persons.AddPerson("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");
        persons.AddPerson("asen@gmail.com", "Asen", 21, "Rousse");

        // Act
        var personsAgedFrom21to22 = persons.FindPersons(21, 22);
        var personsAgedFrom10to11 = persons.FindPersons(10, 11);
        var personsAged21 = persons.FindPersons(21, 21);
        var personsAged19 = persons.FindPersons(19, 19);
        var personsAgedFrom0to1000 = persons.FindPersons(0, 1000);

        // Assert
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk" },
            personsAgedFrom21to22.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { },
            personsAgedFrom10to11.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr" },
            personsAged21.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "ani@gmail.com" },
            personsAged19.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "ani@gmail.com", "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk", "pesho@gmail.com" },
            personsAgedFrom0to1000.Select(p => p.Email).ToList());
    }

    [TestMethod]
    public void FindPersonsByAgeRangeAndTown_ShouldReturnMatchingPersons()
    {
        // Arrange
        var persons = new PersonCollection();
        persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        persons.AddPerson("kirosofia@yahoo.co.uk", "Kiril", 22, "Sofia");
        persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Plovdiv");
        persons.AddPerson("pepi@gmail.com", "Pesho", 21, "Plovdiv");
        persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");
        persons.AddPerson("ani17@gmail.com", "Anna", 17, "Bourgas");
        persons.AddPerson("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");
        persons.AddPerson("asen.rousse@gmail.com", "Asen", 21, "Rousse");
        persons.AddPerson("asen@gmail.com", "Asen", 21, "Plovdiv");

        // Act
        var personsAgedFrom21to22Plovdiv = persons.FindPersons(21, 22, "Plovdiv");
        var personsAgedFrom10to11Sofia = persons.FindPersons(10, 11, "Sofia");
        var personsAged21Plovdiv = persons.FindPersons(21, 21, "Plovdiv");
        var personsAged19Bourgas = persons.FindPersons(19, 19, "Bourgas");
        var personsAgedFrom0to1000Plovdiv = persons.FindPersons(0, 1000, "Plovdiv");
        var personsAgedFrom0to1000NewYork = persons.FindPersons(0, 1000, "New York");

        // Assert
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk" },
            personsAgedFrom21to22Plovdiv.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { },
            personsAgedFrom10to11Sofia.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr" },
            personsAged21Plovdiv.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "ani@gmail.com" },
            personsAged19Bourgas.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "pepi@gmail.com", "pepi2@yahoo.fr", "kiro@yahoo.co.uk", "pesho@gmail.com" },
            personsAgedFrom0to1000Plovdiv.Select(p => p.Email).ToList());
        CollectionAssert.AreEqual(
           new string[] { },
           personsAgedFrom0to1000NewYork.Select(p => p.Email).ToList());
    }

    [TestMethod]
    public void FindDeletedPersons_ShouldReturnEmptyCollection()
    {
        // Arrange
        var persons = new PersonCollection();
        persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        persons.AddPerson("kirosofia@yahoo.co.uk", "Kiril", 22, "Sofia");
        persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Plovdiv");
        persons.AddPerson("pepi@gmail.com", "Pesho", 21, "Plovdiv");
        persons.AddPerson("ani@gmail.com", "Anna", 19, "Bourgas");
        persons.AddPerson("ani17@gmail.com", "Anna", 17, "Bourgas");
        persons.AddPerson("pepi2@yahoo.fr", "Pesho", 21, "Plovdiv");
        persons.AddPerson("asen.rousse@gmail.com", "Asen", 21, "Rousse");
        persons.AddPerson("asen@gmail.com", "Asen", 21, "Plovdiv");

        persons.DeletePerson("pesho@gmail.com");
        persons.DeletePerson("kirosofia@yahoo.co.uk");
        persons.DeletePerson("kiro@yahoo.co.uk");
        persons.DeletePerson("pepi@gmail.com");
        persons.DeletePerson("ani@gmail.com");
        persons.DeletePerson("ani17@gmail.com");
        persons.DeletePerson("pepi2@yahoo.fr");
        persons.DeletePerson("asen.rousse@gmail.com");
        persons.DeletePerson("asen@gmail.com");

        // Act
        var personPeshoGmail = persons.FindPerson("pesho@gmail.com");

        var personsGmail = persons.FindPersons("gmail.com");
        var personsYahoo = persons.FindPersons("yahoo.co.uk");

        var personsPeshoPlovdiv = persons.FindPersons("Pesho", "Plovdiv");

        var personsAgedFrom21to22 = persons.FindPersons(21, 22);
        var personsAgedFrom0to1000 = persons.FindPersons(0, 1000);

        var personsAgedFrom21to22Plovdiv = persons.FindPersons(21, 22, "Plovdiv");
        var personsAged19Bourgas = persons.FindPersons(19, 19, "Bourgas");

        // Assert
        Assert.AreEqual(null, personPeshoGmail);

        Assert.AreEqual(0, personsGmail.Count());
        Assert.AreEqual(0, personsYahoo.Count());

        Assert.AreEqual(0, personsPeshoPlovdiv.Count());

        Assert.AreEqual(0, personsAgedFrom21to22.Count());
        Assert.AreEqual(0, personsAgedFrom0to1000.Count());

        Assert.AreEqual(0, personsAgedFrom21to22Plovdiv.Count());
        Assert.AreEqual(0, personsAged19Bourgas.Count());
    }

    [TestMethod]
    public void MultipleOperations_ShouldReturnWorkCorrectly()
    {
        var persons = new PersonCollection();

        var isAdded = persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        Assert.IsTrue(isAdded);
        Assert.AreEqual(1, persons.Count);

        isAdded = persons.AddPerson("pesho@gmail.com", "Pesho2", 222, "Plovdiv222");
        Assert.IsFalse(isAdded);
        Assert.AreEqual(1, persons.Count);

        persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Plovdiv");
        Assert.AreEqual(2, persons.Count);

        persons.AddPerson("asen@gmail.com", "Asen", 22, "Sofia");
        Assert.AreEqual(3, persons.Count);

        Person person = persons.FindPerson("non-existing person");
        Assert.IsNull(person);

        person = persons.FindPerson("pesho@gmail.com");
        Assert.IsNotNull(person);
        Assert.AreEqual("pesho@gmail.com", person.Email);
        Assert.AreEqual("Pesho", person.Name);
        Assert.AreEqual(28, person.Age);
        Assert.AreEqual("Plovdiv", person.Town);

        var personsGmail = persons.FindPersons("gmail.com");
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "pesho@gmail.com" },
            personsGmail.Select(p => p.Email).ToList());

        var personsPeshoPlovdiv = persons.FindPersons("Pesho", "Plovdiv");
        CollectionAssert.AreEqual(
            new string[] { "pesho@gmail.com" },
            personsPeshoPlovdiv.Select(p => p.Email).ToList());

        var personsPeshoSofia = persons.FindPersons("Pesho", "Sofia");
        Assert.AreEqual(0, personsPeshoSofia.Count());

        var personsKiroPlovdiv = persons.FindPersons("Kiro", "Plovdiv");
        Assert.AreEqual(0, personsKiroPlovdiv.Count());

        var personsAge22To28 = persons.FindPersons(22, 28);
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "kiro@yahoo.co.uk", "pesho@gmail.com" },
            personsAge22To28.Select(p => p.Email).ToList());

        var personsAge22To28Plovdiv = persons.FindPersons(22, 28, "Plovdiv");
        CollectionAssert.AreEqual(
            new string[] { "kiro@yahoo.co.uk", "pesho@gmail.com" },
            personsAge22To28Plovdiv.Select(p => p.Email).ToList());

        var isDeleted = persons.DeletePerson("pesho@gmail.com");
        Assert.IsTrue(isDeleted);

        isDeleted = persons.DeletePerson("pesho@gmail.com");
        Assert.IsFalse(isDeleted);

        person = persons.FindPerson("pesho@gmail.com");
        Assert.IsNull(person);

        personsGmail = persons.FindPersons("gmail.com");
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com" },
            personsGmail.Select(p => p.Email).ToList());

        personsPeshoPlovdiv = persons.FindPersons("Pesho", "Plovdiv");
        CollectionAssert.AreEqual(
            new string[] { },
            personsPeshoPlovdiv.Select(p => p.Email).ToList());

        personsPeshoSofia = persons.FindPersons("Pesho", "Sofia");
        Assert.AreEqual(0, personsPeshoSofia.Count());

        personsKiroPlovdiv = persons.FindPersons("Kiro", "Plovdiv");
        Assert.AreEqual(0, personsKiroPlovdiv.Count());

        personsAge22To28 = persons.FindPersons(22, 28);
        CollectionAssert.AreEqual(
            new string[] { "asen@gmail.com", "kiro@yahoo.co.uk" },
            personsAge22To28.Select(p => p.Email).ToList());

        personsAge22To28Plovdiv = persons.FindPersons(22, 28, "Plovdiv");
        CollectionAssert.AreEqual(
            new string[] { "kiro@yahoo.co.uk" },
            personsAge22To28Plovdiv.Select(p => p.Email).ToList());
    }
}
