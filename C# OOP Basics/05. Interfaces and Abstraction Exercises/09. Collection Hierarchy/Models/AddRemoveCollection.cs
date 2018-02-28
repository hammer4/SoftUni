using System;
using System.Collections.Generic;
using System.Text;

public class AddRemoveCollection : AddCollection, IRemove
{
    public AddRemoveCollection()
        :base()
    { }

    public override int Add(string element)
    {
        this.List.Insert(0, element);

        return 0;
    }

    public virtual string Remove()
    {
        string element = this.List[this.List.Count - 1];
        this.List.RemoveAt(this.List.Count - 1);
        return element;
    }
}