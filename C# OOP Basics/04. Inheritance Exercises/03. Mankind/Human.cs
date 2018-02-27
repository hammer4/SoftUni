using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        protected set
        {
            if (!Char.IsUpper(value.First()))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }

            if(value.Length <= 3)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }

            this.firstName = value;
        }
    }

    protected string LastName
    {
        private get
        {
            return this.lastName;
        }

        set
        {
            if (!Char.IsUpper(value.First()))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            if (value.Length <= 2)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }

            this.lastName = value;
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"First Name: {FirstName}")
            .AppendLine($"Last Name: {LastName}");

        return builder.ToString();
    }
}
