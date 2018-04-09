using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Database
{
    private int[] database;
    private int index;

    public Database(params int[] data)
    {
        if(data.Length > 16)
        {
            throw new InvalidOperationException();
        }

        this.database = new int[16];
        this.index = data.Length;

        Array.Copy(data, database, data.Length);
    }

    public void Add(int item)
    {
        if(index == 16)
        {
            throw new InvalidOperationException();
        }

        this.database[index++] = item;
    }

    public int Remove()
    {
        if(index == 0)
        {
            throw new InvalidOperationException();
        }

        return this.database[--index];
    }

    public int[] Fetch()
    {
        return this.database.Take(index).ToArray();
    }
}