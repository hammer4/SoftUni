using System;

class Launcher
{
    static void Main(string[] args)
    {
        var enterprise = new Enterprise();

        Guid guid = Guid.NewGuid();
        Console.WriteLine(guid.ToString());
        enterprise.Add(new Employee("first", "last", 120, Position.Manager, DateTime.Now));
        enterprise.Change(guid, new Employee("sss", "aaa", 120, Position.Developer, DateTime.Now));

        Employee emp = enterprise.GetByGuid(guid);
        var asd = enterprise.GetByPosition(Position.Developer);
    }
}
