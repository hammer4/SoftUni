using System;
using System.Collections.Generic;
using System.Text;
 
public delegate void JobCompletedHandler(Job job);

public class Job
{
    public event JobCompletedHandler JobCompleted;

    private int hoursRequired;
    private Employee employeeAssigned;

    public Job(string name, int hoursRequired, Employee employee)
    {
        this.Name = name;
        this.hoursRequired = hoursRequired;
        this.employeeAssigned = employee;
    }

    public string Name { get; private set; }

    public void Update()
    {
        this.hoursRequired -= this.employeeAssigned.HoursPerWeek;

        if(hoursRequired <= 0)
        {
            Console.WriteLine($"Job {this.Name} done!");
            this.JobCompleted.Invoke(this);
        }
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.hoursRequired}";
    }
}