using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Enterprise : IEnterprise
{
    private Dictionary<Guid, Employee> byGuid = new Dictionary<Guid, Employee>();

    public int Count => this.byGuid.Count;

    public void Add(Employee employee)
    {
        if (!byGuid.ContainsKey(employee.Id))
        {
            this.byGuid.Add(employee.Id, employee);
        }
    }

    public IEnumerable<Employee> AllWithPositionAndMinSalary(Position position, double minSalary)
    {
        return this.byGuid.Values
            .Where(e => e.Position.Equals(position) && e.Salary >= minSalary);
    }

    public bool Change(Guid guid, Employee employee)
    {
        if (this.byGuid.ContainsKey(guid))
        {
            var oldEmployee = this.byGuid[guid];
            oldEmployee.FirstName = employee.FirstName;
            oldEmployee.LastName = employee.LastName;
            oldEmployee.HireDate = employee.HireDate;
            oldEmployee.Position = employee.Position;
            oldEmployee.Salary = employee.Salary;
            return true;
        }

        return false;

    }

    public bool Contains(Guid guid)
    {
        return byGuid.ContainsKey(guid);
    }

    public bool Contains(Employee employee)
    {
        return this.byGuid.ContainsKey(employee.Id);

    }

    public bool Fire(Guid guid)
    {
        if (this.byGuid.ContainsKey(guid))
        {
            this.byGuid.Remove(guid);
            return true;
        }

        return false;
    }

    public Employee GetByGuid(Guid guid)
    {
        if (this.byGuid.ContainsKey(guid))
        {
            return this.byGuid[guid];
        }

        throw new ArgumentException();

    }

    public IEnumerable<Employee> GetByPosition(Position position)
    {
        var result = this.byGuid.Values
            .Where(e => e.Position.Equals(position));

        if (result.Any())
        {
            return result;
        }

        throw new ArgumentException();
    }

    public IEnumerable<Employee> GetBySalary(double minSalary)
    {
        var query = this.byGuid.Values
            .Where(e => e.Salary >= minSalary);

        if(query.Any())
        {
            return query;
        }

        throw new InvalidOperationException();
    }

    public IEnumerable<Employee> GetBySalaryAndPosition(double salary, Position position)
    {
        var result = this.byGuid.Values
            .Where(e => e.Salary.Equals(salary) && e.Position.Equals(position));

        if (result.Any())
        {
            return result;
        }

        throw new InvalidOperationException();
    }

    public IEnumerator<Employee> GetEnumerator()
    {
        foreach(var value in this.byGuid.Values)
        {
            yield return value;
        }
    }

    public Position PositionByGuid(Guid guid)
    {
        if (this.byGuid.ContainsKey(guid))
        {
            return this.byGuid[guid].Position;
        }

        throw new InvalidOperationException();
    }

    //public bool RaiseSalary(int months, int percent)
    //{
    //    var result = this.byGuid.Values
    //        .Where(e => Math.Abs((DateTime.Now.Month - e.HireDate.Month) + 12 * (DateTime.Now.Year - e.HireDate.Year)) >= months);

    //    foreach(var employee in result)
    //    {
    //        employee.Salary *= 1 + ((double)percent) / 100;
    //    }

    //    return result.Count() != 0;
    //}

    public bool RaiseSalary(int months, int percent)
    {
        var result = false;
        foreach (var keyValuePair in this.byGuid)
        {
            if (keyValuePair.Value.HireDate.AddMonths(months) <= DateTime.Now)
            {
                keyValuePair.Value.Salary += keyValuePair.Value.Salary * (percent / 100.0);
                result = true;
            }
        }

        return result;
    }

    public IEnumerable<Employee> SearchByFirstName(string firstName)
    {
        return this.byGuid.Values
            .Where(e => e.FirstName.Equals(firstName));
    }

    public IEnumerable<Employee> SearchByNameAndPosition(string firstName, string lastName, Position position)
    {
        return this.byGuid.Values
            .Where(e => e.Position.Equals(position) && e.FirstName.Equals(firstName) && e.LastName.Equals(lastName));
    }

    public IEnumerable<Employee> SearchByPosition(IEnumerable<Position> positions)
    {
        return this.byGuid.Values
            .Where(e => positions.Contains(e.Position));
    }

    public IEnumerable<Employee> SearchBySalary(double minSalary, double maxSalary)
    {
        return this.byGuid.Values
            .Where(e => e.Salary >= minSalary && e.Salary <= maxSalary);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

