using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

[TestFixture]
public class PerformanceTests
{
    [Test]
    public void AddEmployees()
    {
        IEnterprise enterprise = new Enterprise();

        Stopwatch watch = new Stopwatch();
        watch.Start();

        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.Hr, DateTime.Now);

            enterprise.Add(employee);
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        int count = enterprise.Count;
        Assert.AreEqual(100000, count);

        Assert.IsTrue(l1 < 350);
    }

    [Test]
    public void ContainsEmployees()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        int count = enterprise.Count;
        Assert.AreEqual(100000, count);

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (Employee employee in employees)
        {
            Assert.AreEqual(true, enterprise.Contains(employee));
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 300);
    }

    [Test]
    public void ContainsEmployeeId()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        int count = enterprise.Count;
        Assert.AreEqual(100000, count);

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (Employee employee in employees)
        {
            Assert.AreEqual(true, enterprise.Contains(employee.Id));
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 300);
    }

    [Test]
    public void ChangeId()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        int count = enterprise.Count;
        Assert.AreEqual(100000, count);

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (Employee employee in employees)
        {
            Assert.AreEqual(true, enterprise.Contains(employee.Id));
            Employee byGuid = enterprise.GetByGuid(employee.Id);
            enterprise.Change(Guid.NewGuid(), byGuid);
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 350);
    }

    [Test]
    public void FireAllEmployees()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        Assert.AreEqual(100000, enterprise.Count);

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (Employee employee in employees)
        {
            enterprise.Fire(employee.Id);
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
    }

    [Test]
    public void RaiseSalary()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        Assert.AreEqual(100000, enterprise.Count);

        Stopwatch watch = new Stopwatch();
        watch.Start();

        enterprise.RaiseSalary(DateTime.Now.Month, 1);

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
    }

    [Test]
    public void GetById()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (Employee employee in employees)
        {
            Employee byGuid = enterprise.GetByGuid(employee.Id);
            Assert.NotNull(byGuid);
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
    }

    [Test]
    public void PositionById()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (Employee employee in employees)
        {
            Position byGuid = enterprise.PositionByGuid(employee.Id);
            Assert.NotNull(byGuid);
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
    }

    [Test]
    public void GetByPosition()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Employee> byPosition = enterprise.GetByPosition(Position.Hr);
        int count = 0;

        foreach (Employee employee in byPosition)
        {
            count++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
        Assert.AreEqual(100000, count);
    }

    [Test]
    public void GetBySalary()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Employee> byPosition = enterprise.GetBySalary(1);
        int count = 0;
        foreach (Employee employee in byPosition)
        {
            count++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
        Assert.AreEqual(100000, count);
    }

    [Test]
    public void GetBySalaryAndPosition()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Employee> byPosition = enterprise.GetBySalaryAndPosition(1, Position.Hr);
        int count = 0;

        foreach (Employee employee in byPosition)
        {
            count++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
        Assert.AreEqual(100000, count);
    }

    [Test]
    public void SearchBySalary()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Employee> byPosition = enterprise.SearchBySalary(1, 1);
        int count = 0;
        foreach (Employee employee in byPosition)
        {
            count++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
        Assert.AreEqual(100000, count);
    }

    [Test]
    public void SearchByPosition()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        Stopwatch watch = new Stopwatch();
        watch.Start();

        List<Position> positions = new List<Position>();
        positions.Add(Position.Hr);

        IEnumerable<Employee> byPosition = enterprise.SearchByPosition(positions);

        int count = 0;

        foreach (Employee employee in byPosition)
        {
            count++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
        Assert.AreEqual(100000, count);
    }

    [Test]
    public void AllWithPositionAndMinSalary()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1 + i, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Employee> byPosition = enterprise.AllWithPositionAndMinSalary(Position.Hr, 50);
        int count = 0;
        foreach (Employee employee in byPosition)
        {
            count++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
        Assert.AreEqual(99951, count);
    }

    [Test]
    public void SearchByFirstName()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1 + i, Position.Hr, DateTime.Now);

            employees.Add(employee);
            enterprise.Add(employee);
        }

        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Employee> byPosition = enterprise.SearchByFirstName("a0");
        int count = 0;
        foreach (Employee employee in byPosition)
        {
            count++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.IsTrue(l1 < 150);
        Assert.AreEqual(1, count);
    }

    [Test]
    public void SearchByNameAndPosition()
    {
        IEnterprise enterprise = new Enterprise();

        List<Employee> employees = new List<Employee>();
        for (int i = 0; i < 100000; i++)
        {
            Employee employee = new Employee("a" + i, "a" + i, 1 + i, Position.Hr, new DateTime());

            employees.Add(employee);
            enterprise.Add(employee);
        }

        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Employee> byPosition = enterprise.SearchByNameAndPosition("a0", "a0", Position.Hr);
        int count = 0;
        foreach (Employee employee in byPosition)
        {
            count++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;
        Assert.IsTrue(l1 < 150);
        Assert.AreEqual(1, count);
    }
}