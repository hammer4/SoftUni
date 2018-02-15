using System;
using System.Collections.Generic;
using System.Text;

public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int? age;

    public Employee(string name, decimal salary, string position, string department)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
    }

    public Employee(string name, decimal salary, string position, string department, string email) 
        : this(name, salary, position, department)
    {
        this.Email = email;
    }

    public Employee(string name, decimal salary, string position, string department, int? age)
        :this(name, salary, position, department)
    {
        this.Age = age;
    }

    public Employee(string name, decimal salary, string position, string department, string email, int? age)
        : this(name, salary, position, department)
    {
        this.Email = email;
        this.Age = age;
    }

    public int? Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public string Position
    {
        get { return position; }
        set { position = value; }
    }

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append($"{this.Name} ");
        builder.Append($"{this.Salary:F2} ");
        builder.Append($"{(this.Email == null ? "n/a" : this.Email)} ");
        builder.Append($"{(this.Age == null ? -1 : this.Age)}");

        return builder.ToString();
    }

}