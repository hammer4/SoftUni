namespace P01_HospitalDatabase.Generators
{
    using System;
    //using System.IO;

    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;

    public class PatientGenerator
    {
        private static Random rnd = new Random();

        public static Patient NewPatient(HospitalContext context)
        {
            string firstName = NameGenerator.FirstName();
            string lastName = NameGenerator.LastName();

            var patient = new Patient()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = EmailGenerator.NewEmail(firstName + lastName),
                Address = AddressGenerator.NewAddress(),
            };

            patient.Visitations = GenerateVisitations(patient);
            patient.Diagnoses = GenerateDiagnoses(patient);

            return patient;
        }

        private static Diagnose[] GenerateDiagnoses(Patient patient)
        {
            var diagnoseNames = new string[] 
            {
                "Limp Scurvy",
                "Fading Infection",
                "Cow Feet",
                "Incurable Ebola",
                "Snake Blight",
                "Spider Asthma",
                "Sinister Body",
                "Spine Diptheria",
                "Pygmy Decay",
                "King's Arthritis",
                "Desert Rash",
                "Deteriorating Salmonella",
                "Shadow Anthrax",
                "Hiccup Meningitis",
                "Fading Depression",
                "Lion Infertility",
                "Wolf Delirium",
                "Humming Measles",
                "Incurable Stomach",
                "Grave Heart",
            };
            //var diagnoseNames = File.ReadAllLines("<INSERT DIR HERE>");

            int diagnoseCount = rnd.Next(1, 4);
            var diagnoses = new Diagnose[diagnoseCount];
            for (int i = 0; i < diagnoseCount; i++)
            {
                string diagnoseName = diagnoseNames[rnd.Next(diagnoseNames.Length)];

                var diagnose = new Diagnose()
                {
                    Name = diagnoseName,
                    Patient = patient
                };

                diagnoses[i] = diagnose;
            }

            return diagnoses;
        }

        private static Visitation[] GenerateVisitations(Patient patient)
        {
            int visitationCount = rnd.Next(1, 5);

            var visitations = new Visitation[visitationCount];

            for (int i = 0; i < visitationCount; i++)
            {
                var visitationDate = RandomDay(2005);

                var visitation = new Visitation()
                {
                    Date = visitationDate,
                    Patient = patient
                };

                visitations[i] = visitation;
            }

            return visitations;
        }

        private static DateTime RandomDay(int startYear)
        {
            DateTime start = new DateTime(startYear, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }
    }
}
