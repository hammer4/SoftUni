using System;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        var tokens = Console.ReadLine().Split();
        string minionName = tokens[1];
        int minionAge = int.Parse(tokens[2]);
        string minionTown = tokens[3];

        tokens = Console.ReadLine().Split();
        string villainName = tokens[1];

        string connectionString = "Server=(localdb)\\MSSQLLocalDB;" + "Integrated Security=true;" + "initial catalog=MinionsDB";

        SqlConnection dbCon = new SqlConnection(connectionString);
        dbCon.Open();

        using (dbCon)
        {
            SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM Towns WHERE Name = '{minionTown}'", dbCon);

            if ((int)command.ExecuteScalar() == 0)
            {
                command = new SqlCommand($"INSERT INTO Towns(Name) VALUES ('{minionTown}')", dbCon);
                command.ExecuteNonQuery();
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }

            command = new SqlCommand($"SELECT COUNT(*) FROM Villains WHERE Name = '{villainName}'", dbCon);

            if ((int)command.ExecuteScalar() == 0)
            {
                command = new SqlCommand($"INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('{villainName}', 4)", dbCon);
                command.ExecuteNonQuery();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            command = new SqlCommand($"SELECT Id FROM Towns WHERE Name = '{minionTown}'", dbCon);
            int townId = (int)command.ExecuteScalar();

            command = new SqlCommand($"INSERT INTO Minions(Name, Age, TownId) VALUES ('{minionName}', {minionAge}, {townId})", dbCon);
            command.ExecuteNonQuery();

            int villainId = (int)new SqlCommand($"SELECT Id FROM Villains WHERE Name = '{villainName}'", dbCon).ExecuteScalar();
            int minionId = (int)new SqlCommand($"SELECT Id FROM Minions WHERE Name = '{minionName}'", dbCon).ExecuteScalar();

            command = new SqlCommand($"INSERT INTO MinionsVillains VALUES ({minionId}, {villainId})", dbCon);
            command.ExecuteNonQuery();
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }
    }
}
