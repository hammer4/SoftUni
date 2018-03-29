using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Pet> pets = new List<Pet>();
        List<Clinic> clinics = new List<Clinic>();

        int count = int.Parse(Console.ReadLine());

        for(int i=0; i<count; i++)
        {
            var tokens = Console.ReadLine().Split();
            Clinic clinic;

            switch (tokens[0])
            {
                case "Create":
                    switch (tokens[1])
                    {
                        case "Pet":
                            pets.Add(new Pet(tokens[2], int.Parse(tokens[3]), tokens[4]));
                            break;
                        case "Clinic":
                            try
                            {
                                clinics.Add(new Clinic(tokens[2], int.Parse(tokens[3])));
                            }
                            catch(InvalidOperationException ioe)
                            {
                                Console.WriteLine(ioe.Message);
                            }
                            break;
                    }
                    break;
                case "Add":
                    var pet = pets.SingleOrDefault(p => p.Name == tokens[1]);
                    clinic = clinics.Single(c => c.Name == tokens[2]);

                    try
                    {
                        Console.WriteLine(clinic.AddPet(pet));
                    }
                    catch(InvalidCastException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }
                    break;
                case "Release":
                    clinic = clinics.Single(c => c.Name == tokens[1]);
                    Console.WriteLine(clinic.Release());
                    break;
                case "HasEmptyRooms":
                    clinic = clinics.Single(c => c.Name == tokens[1]);
                    Console.WriteLine(clinic.HasEmptyRooms());
                    break;
                case "Print":
                    clinic = clinics.Single(c => c.Name == tokens[1]);

                    if (tokens.Length == 2)
                    {
                        clinic.Print();
                    }
                    else if(tokens.Length == 3)
                    {
                        clinic.PrintRoom(int.Parse(tokens[2]));
                    }
                    break;
            }
        }
    }
}