namespace P01_HospitalDatabase.Generators
{
    using System;
    using System.Linq;

    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;
    using System.Collections.Generic;

    public class PrescriptionGenerator
    {
        internal static void InitialPrescriptionSeed(HospitalContext context)
        {
            Random rnd = new Random();

            int[] allMedicamentIds = context.Medicaments.Select(d => d.MedicamentId).ToArray();

            int[] allPatientIds = context.Patients.Select(p => p.PatientId).ToArray();

            foreach (int patientId in allPatientIds)
            {
                int patientMedicamentsCount = rnd.Next(1, 4);

                int[] medicamentIds = new int[patientMedicamentsCount];

                for (int id = 0; id < patientMedicamentsCount; id++)
                {
                    int index = -1;

                    while (!allMedicamentIds.Contains(index) || medicamentIds.Contains(index))
                    {
                        index = rnd.Next(allMedicamentIds.Max());
                    }

                    medicamentIds[id] = index;
                }

                var prescriptions = new List<PatientMedicament>();
                foreach (int medicamentId in medicamentIds)
                {
                    var prescription = new PatientMedicament()
                    {
                        PatientId = patientId,
                        MedicamentId = medicamentId
                    };

                    prescriptions.Add(prescription);
                }
                context.Patients.Find(patientId).Prescriptions = prescriptions;
            }

            context.SaveChanges();
        }

        public static void NewPrescription(int patientId, int medicamentId, HospitalContext context)
        {
            var prescription = new PatientMedicament()
            {
                PatientId = patientId,
                MedicamentId = medicamentId
            };

            context.Patients.Find(patientId).Prescriptions.Add(prescription);
            context.SaveChanges();
        }

        public static void NewPrescription(Patient patient, Medicament medicament, HospitalContext context)
        {
            var prescription = new PatientMedicament()
            {
                Patient = patient,
                Medicament = medicament
            };

            patient.Prescriptions.Add(prescription);
            context.SaveChanges();
        }
    }
}
