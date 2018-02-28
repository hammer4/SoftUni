using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    private List<Private> privates;

    public LeutenantGeneral(string id, string firstName, string lastName, double salary) 
        : base(id, firstName, lastName, salary)
    {
        this.privates = new List<Private>();
    }

    public IReadOnlyCollection<IPrivate> Privates
    {
        get
        {
            return this.privates;
        }
    }

    public void AddPrivate(Private newPrivate)
    {
        this.privates.Add(newPrivate);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine(base.ToString())
            .AppendLine("Privates:");

        foreach(var current in this.privates)
        {
            builder.AppendLine("  " + current.ToString());
        }

        return builder.ToString().TrimEnd();
    }
}
