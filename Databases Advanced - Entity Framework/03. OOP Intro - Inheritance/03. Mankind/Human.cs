using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    private string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (!Char.IsUpper(value[0]))
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

    private string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (!Char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            if(value.Length <= 2)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
            }

            this.lastName = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}" + Environment.NewLine + $"Last Name: {this.LastName}" + Environment.NewLine;
    }
}
