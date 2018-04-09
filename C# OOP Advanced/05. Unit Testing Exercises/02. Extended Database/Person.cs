using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public Person(long id, string username)
    {
        this.Id = id;
        this.Username = username;
    }

    public long Id { get; private set; }

    public string Username { get; private set; }
}