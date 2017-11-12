using System;

using P01_HospitalDatabase.Initializer;
using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase 
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new HospitalContext())
            {
                DatabaseInitializer.ResetDatabase(dbContext);
            }
        }
    }
}
