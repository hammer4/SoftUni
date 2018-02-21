using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    internal string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    internal void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    internal void RemovePlayer(string playerName)
    {
        if (!this.players.Any(p => p.Name == playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }

        this.players.Remove(this.players.First(p => p.Name == playerName));
    }

    internal int Rating
    {
        get
        {
            return this.players.Count == 0 ? 0 : Convert.ToInt32((this.players.Average(p => p.Stats)));
        }
    }
}
