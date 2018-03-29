using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if(x.Name.Length.CompareTo(y.Name.Length) != 0)
        {
            return x.Name.Length.CompareTo(y.Name.Length);
        }

        return String.Compare(x.Name.First().ToString(), y.Name.First().ToString(), true);
    }
}