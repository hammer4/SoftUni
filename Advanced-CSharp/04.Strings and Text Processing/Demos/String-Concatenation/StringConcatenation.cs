using System;

public class StringConcatenation
{
    public static void Main()
    {
        const string FirstName = "Software";
        const string LastName = "University";

        const string FullName = FirstName + " " + LastName;

        Console.WriteLine(FullName);

        const int Age = 25;

        string nameAndAge =
            "Name: " + FullName +
            "\nAge: " + Age;

        Console.WriteLine(nameAndAge);
    }
}