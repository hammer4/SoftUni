using System;
using System.Collections.Generic;
using System.Text;

public class Animal : ISoundProducable
{
    private string name;
    private int age;
    private Gender gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    private string Name
    {
        set
        {
            if(String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.name = value;
        }
    }

    private int Age
    {
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Invalid input!");
            }

            this.age = value;
        }
    }

    private string Gender
    {
        set
        {
            Gender gender;
            if(String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) || !Enum.TryParse<Gender>(value, out gender))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.gender = gender;
        }
    }

    public virtual string ProduceSound()
    {
        return null;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine(this.GetType().Name)
            .AppendLine($"{this.name} {this.age} {this.gender.ToString()}")
            .Append($"{this.ProduceSound()}");

        return builder.ToString();
    }
}