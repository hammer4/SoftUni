using System;
using System.Collections.Generic;
using System.Text;

public class MyList : AddRemoveCollection, IUsed
{
    public MyList()
        :base()
    { }

    public override string Remove()
    {
        string element = this.List[0];
        this.List.RemoveAt(0);

        return element;
    }

    public int Used => this.List.Count;
}