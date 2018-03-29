using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Clinic
{
    private Pet[] rooms;
    private int addIndex;
    private int releaseIndex;

    public Clinic(string name, int rooms)
    {
        if(rooms % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        this.rooms = new Pet[rooms];
        this.Name = name;
        this.addIndex = rooms / 2;
        this.releaseIndex = rooms / 2;
    }

    public string Name { get; private set; }

    public bool AddPet(Pet pet)
    {
        if(pet == null)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        for(int diff = 0; diff <= addIndex; diff++)
        {
            if(rooms[addIndex - diff] == null)
            {
                rooms[addIndex - diff] = pet;
                return true;
            }

            if (rooms[addIndex + diff] == null)
            {
                rooms[addIndex + diff] = pet;
                return true;
            }
        }

        return false;
    }

    public bool Release()
    {
        for(int i = releaseIndex; i<rooms.Length; i++)
        {
            if(rooms[i] != null)
            {
                rooms[i] = null;
                return true;
            }
        }

        for (int i = 0; i < releaseIndex; i++)
        {
            if (rooms[i] != null)
            {
                rooms[i] = null;
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        return this.rooms.Any(r => r == null);
    }

    public void PrintRoom(int number)
    {
        if(rooms[number - 1] != null)
        {
            Console.WriteLine(rooms[number - 1]);
        }
        else
        {
            Console.WriteLine("Room empty");
        }
    }

    public void Print()
    {
        foreach(var pet in rooms)
        {
            if(pet == null)
            {
                Console.WriteLine("Room empty");
            }
            else
            {
                Console.WriteLine(pet);
            }
        }
    }
}