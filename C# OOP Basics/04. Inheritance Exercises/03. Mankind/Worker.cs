using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal hoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal hoursPerDay)
        :base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.HoursPerDay = hoursPerDay;
    }

    private decimal WeekSalary
    {
        get
        {
            return weekSalary;
        }

        set
        {
            if(value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }

    private decimal HoursPerDay
    {
        get
        {
            return this.hoursPerDay;
        }

        set
        {
            if(value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.hoursPerDay = value;
        }
    }

    private decimal CalculateSalaryPerHour()
    {
        return this.WeekSalary / (5 * this.HoursPerDay);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append(base.ToString())
            .AppendLine($"Week Salary: {WeekSalary:F2}")
            .AppendLine($"Hours per day: {HoursPerDay:F2}")
            .Append($"Salary per hour: {CalculateSalaryPerHour():F2}");

        return builder.ToString();
    }
}