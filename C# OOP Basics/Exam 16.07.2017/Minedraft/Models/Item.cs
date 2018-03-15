using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Item
{
    protected Item(string id)
    {
        this.Id = id;
    }

    public string Id { get; private set; }
}