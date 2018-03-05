using System;
using System.Linq;

class PlayWithPersons
{
    static void Main()
    {
        var persons = new PersonCollection();
        persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        Console.WriteLine("Added a person. Count = " + persons.Count);

        persons.AddPerson("pesho@gmail.com", "Pesho2", 222, "Plovdiv222");
        Console.WriteLine("Duplicated person. Count = " + persons.Count);

        persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Plovdiv");
        Console.WriteLine("Added a person. Count = " + persons.Count);

        persons.AddPerson("asen@gmail.com", "Asen", 22, "Sofia");
        Console.WriteLine("Added a person. Count = " + persons.Count);

        var existingPerson = persons.FindPerson("pesho@gmail.com");
        Console.WriteLine("Find existing person: " + existingPerson.Email);

        var nonExistingPerson = persons.FindPerson("non-existing person");
        Console.WriteLine("Find non-existing person: " +
            (nonExistingPerson == null ? "null" : "not null"));

        var personsGmail = persons.FindPersons("gmail.com");
        Console.WriteLine("Persons @ GMail: [{0}]",
            string.Join(", ", personsGmail.Select(p => p.Email)));

        var personsPeshoPlovdiv = persons.FindPersons("Pesho", "Plovdiv");
        Console.WriteLine("Persons 'Pesho' from 'Plovdiv': [{0}]",
            string.Join(", ", personsPeshoPlovdiv.Select(p => p.Email)));

        var personsPeshoSofia = persons.FindPersons("Pesho", "Sofia");
        Console.WriteLine("Persons 'Pesho' from 'Sofia': [{0}]",
            string.Join(", ", personsPeshoSofia.Select(p => p.Email)));

        var personsKiroPlovdiv = persons.FindPersons("Kiro", "Plovdiv");
        Console.WriteLine("Persons 'Kiro' from 'Plovdiv': [{0}]",
            string.Join(", ", personsKiroPlovdiv.Select(p => p.Email)));

        var personsAge22To28 = persons.FindPersons(22, 28);
        Console.WriteLine("Persons of age 22 ... 28: [{0}]",
            string.Join(", ", personsAge22To28.Select(p => p.Email)));

        var personsAge22To28Plovdiv = persons.FindPersons(22, 28, "Plovdiv");
        Console.WriteLine("Persons of age 22 ... 28 from 'Plovdiv': [{0}]",
            string.Join(", ", personsAge22To28Plovdiv.Select(p => p.Email)));

        var isDeleted = persons.DeletePerson("pesho@gmail.com");
        Console.WriteLine("Person 'Pesho' deleted: " + isDeleted);

        var pesho = persons.FindPerson("pesho@gmail.com");
        Console.WriteLine("Find deleted person: " +
            (pesho == null ? "null" : "not null"));

        nonExistingPerson = persons.FindPerson("non-existing person");
        Console.WriteLine("Find non-existing person: " +
            (nonExistingPerson == null ? "null" : "not null"));

        personsGmail = persons.FindPersons("gmail.com");
        Console.WriteLine("Persons @ GMail: [{0}]",
            string.Join(", ", personsGmail.Select(p => p.Email)));

        personsPeshoPlovdiv = persons.FindPersons("Pesho", "Plovdiv");
        Console.WriteLine("Persons 'Pesho' from 'Plovdiv': [{0}]",
            string.Join(", ", personsPeshoPlovdiv.Select(p => p.Email)));

        personsPeshoSofia = persons.FindPersons("Pesho", "Sofia");
        Console.WriteLine("Persons 'Pesho' from 'Sofia': [{0}]",
            string.Join(", ", personsPeshoSofia.Select(p => p.Email)));

        personsKiroPlovdiv = persons.FindPersons("Kiro", "Plovdiv");
        Console.WriteLine("Persons 'Kiro' from 'Plovdiv': [{0}]",
            string.Join(", ", personsKiroPlovdiv.Select(p => p.Email)));

        personsAge22To28 = persons.FindPersons(22, 28);
        Console.WriteLine("Persons of age 22 ... 28: [{0}]",
            string.Join(", ", personsAge22To28.Select(p => p.Email)));

        personsAge22To28Plovdiv = persons.FindPersons(22, 28, "Plovdiv");
        Console.WriteLine("Persons of age 22 ... 28 from 'Plovdiv': [{0}]",
            string.Join(", ", personsAge22To28Plovdiv.Select(p => p.Email)));
    }
}
