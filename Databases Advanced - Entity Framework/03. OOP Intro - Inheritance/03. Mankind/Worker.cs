using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
        :base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    private decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
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

    private decimal WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }

        set
        {
            if(value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workHoursPerDay = value;
        }
    }

    private decimal SalaryPerHour()
    {
        return this.WeekSalary / (5 * this.WorkHoursPerDay);
    }

    public override string ToString()
    {
        return base.ToString() + $"Week Salary: {this.WeekSalary:f2}" + Environment.NewLine + $"Hours per day: {this.workHoursPerDay:f2}" + Environment.NewLine + $"Salary per hour: {this.SalaryPerHour():f2}";
    }
}
