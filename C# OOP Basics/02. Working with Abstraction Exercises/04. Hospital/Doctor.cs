using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Doctor
{
    public Doctor(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Patients = new List<Patient>();
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public List<Patient> Patients { get; private set; }

    public void AddPatient(Patient patient)
    {
        Patients.Add(patient);
    }

    public string GetPatients()
    {
        return String.Join(Environment.NewLine, Patients.Select(p => p.Name).OrderBy(p => p));
    }
}