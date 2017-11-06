using System;
using System.Collections.Generic;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string countryName = Console.ReadLine();

        string connectionString = "Server=(localdb)\\MSSQLLocalDB;" + "Integrated Security=true;" + "initial catalog=MinionsDB";

        SqlConnection dbCon = new SqlConnection(connectionString);
        dbCon.Open();

        using (dbCon)
        {
            int? countryId = (int?)new SqlCommand($"SELECT Id FROM Countries WHERE Name = '{countryName}'", dbCon).ExecuteScalar();

            if (countryId == null)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                int townsCount = (int)new SqlCommand($"SELECT COUNT(*) FROM Towns WHERE CountryId = {countryId}", dbCon).ExecuteScalar();

                SqlDataReader reader = new SqlCommand($"SELECT * FROM Towns WHERE CountryId = {countryId}", dbCon).ExecuteReader();

                var townNamesAffected = new List<String>();
                var townIdsAffected = new List<int>();

                using (reader)
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No town names were affected.");
                        reader.Close();
                        dbCon.Close();
                        return;
                    }

                    while (reader.Read())
                    {

                        string townName = (string)reader["Name"];
                        int townId = (int)reader["Id"];

                        townNamesAffected.Add(townName.ToUpper());
                        townIdsAffected.Add(townId);
                    }
                }

                for(int i = 0; i<townIdsAffected.Count; i++)
                {
                    new SqlCommand($"UPDATE Towns SET Name = '{townNamesAffected[i].ToUpper()}' WHERE Id = {townIdsAffected[i]}", dbCon).ExecuteNonQuery();
                }

                Console.WriteLine($"{townsCount} town names were affected.");
                Console.WriteLine($"[{String.Join(", ", townNamesAffected)}]");
            }
        }
    }
}
