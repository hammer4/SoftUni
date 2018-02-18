using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Department
{
    private List<Room> rooms;
    private string name;

    public Department(string name)
    {
        this.name = name;

        this.rooms = new List<Room>();
        for(int i=0; i<20; i++)
        {
            rooms.Add(new Room(i + 1));
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
    }

    public void AddPatientToRoom(Patient patient)
    {
        var room = this.rooms.FirstOrDefault(r => r.Patients.Count < 3);

        if(room != null)
        {
            room.AddPatient(patient);
        }
    }

    public string GetAllPatients()
    {
        var a = this.rooms.SelectMany(r => r.Patients).ToList();
        return String.Join(Environment.NewLine, this.rooms.SelectMany(r => r.Patients).Select(p => p.Name).ToList());
    }

    public string GetPatientsByRoom(int id)
    {
        return String.Join(Environment.NewLine, rooms.Single(r => r.Id == id).Patients.Select(p => p.Name).OrderBy(p => p));
    }
}
