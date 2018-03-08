using System;
using System.Collections.Generic;

public interface IEnterprise : IEnumerable<Employee>
{
    void Add(Employee employee);
    bool Contains(Guid guid);
    bool Contains(Employee employee);
    bool Change(Guid guid, Employee employee);
    bool Fire(Guid guid);
    bool RaiseSalary(int months, int percent);
    int Count { get; }

    Employee GetByGuid(Guid guid);
    Position PositionByGuid(Guid guid);

    IEnumerable<Employee> GetByPosition(Position position);
    IEnumerable<Employee> GetBySalary(double minSalary);
    IEnumerable<Employee> GetBySalaryAndPosition(double salary, Position position);

    IEnumerable<Employee> SearchBySalary(double minSalary, double maxSalary);
    IEnumerable<Employee> SearchByPosition(IEnumerable<Position> positions);
    IEnumerable<Employee> AllWithPositionAndMinSalary(Position position, double minSalary);
    IEnumerable<Employee> SearchByFirstName(string firstName);
    IEnumerable<Employee> SearchByNameAndPosition(string firstName, string lastName, Position position);
}