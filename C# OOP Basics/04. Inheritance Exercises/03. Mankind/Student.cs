using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        :base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    private string FacultyNumber
    {
        get
        {
            return this.facultyNumber;
        }

        set
        {
            var pattern = @"^[a-zA-Z0-9]{5,10}$";

            if(!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append(base.ToString())
            .AppendLine($"Faculty number: {FacultyNumber}");

        return builder.ToString();
    }
}