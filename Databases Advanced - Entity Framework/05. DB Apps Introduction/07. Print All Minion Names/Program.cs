using System;
using System.Collections.Generic;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;" + "Integrated Security=true;" + "initial catalog=MinionsDB";

        SqlConnection dbCon = new SqlConnection(connectionString);
        dbCon.Open();

        List<string> minionsInitial = new List<string>();
        List<string> minionsArranged = new List<string>();

        using (dbCon)
        {
            SqlCommand command = new SqlCommand("SELECT Name FROM Minions", dbCon);

            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                if (!reader.HasRows)
                {
                    reader.Close();
                    dbCon.Close();
                    return;
                }

                while (reader.Read())
                {
                    minionsInitial.Add((string)reader["Name"]);
                }
            }
        }

        while(minionsInitial.Count > 0)
        {
            minionsArranged.Add(minionsInitial[0]);
            minionsInitial.RemoveAt(0);

            if(minionsInitial.Count > 0)
            {
                minionsArranged.Add(minionsInitial[minionsInitial.Count - 1]);
                minionsInitial.RemoveAt(minionsInitial.Count - 1);
            }
        }

        minionsArranged.ForEach(m => Console.WriteLine(m));
    }
}