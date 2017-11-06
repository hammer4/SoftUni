using System;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;" + "Integrated Security=true;" + "initial catalog=MinionsDB";

        SqlConnection dbCon = new SqlConnection(connectionString);
        dbCon.Open();

        using (dbCon)
        {
            SqlCommand command = new SqlCommand("SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount FROM Villains AS v JOIN MinionsVillains AS mv ON v.Id = mv.VillainId GROUP BY v.Id, v.Name HAVING COUNT(mv.VillainId) > 3 ORDER BY COUNT(mv.VillainId)", dbCon);

            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string villainName = (string)reader["Name"];
                    int minionsCount = (int)reader["MinionsCount"];

                    Console.WriteLine($"{villainName} - {minionsCount}");
                }
            }
        }
    }
}
