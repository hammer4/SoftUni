using System;
using System.Collections.Generic;
using System.Text;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public IReadOnlyCollection<Person> FirstTeam
    {
        get
        {
            return this.firstTeam;
        }
    }

    public IReadOnlyCollection<Person> ReserveTeam
    {
        get
        {
            return this.reserveTeam;
        }
    }

    public void AddPlayer(Person person)
    {
        if(person.Age < 40)
        {
            this.firstTeam.Add(person);
        }
        else
        {
            this.reserveTeam.Add(person);
        }
    }
}
