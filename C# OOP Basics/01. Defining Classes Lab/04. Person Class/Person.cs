using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
        this.accounts = new List<BankAccount>();
    }

    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.name = name;
        this.age = age;
        this.accounts = accounts;
    }

    public decimal GetBalance()
    {
        return this.accounts.Sum(a => a.Balance);
    }
}