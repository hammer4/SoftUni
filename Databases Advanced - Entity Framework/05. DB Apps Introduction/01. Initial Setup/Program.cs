using System;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;" + "Integrated Security=true;";

        SqlConnection dbCon = new SqlConnection(connectionString);
        dbCon.Open();

        using (dbCon)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("CREATE DATABASE MinionsDB", dbCon);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        connectionString += "initial catalog=MinionsDB";
        dbCon = new SqlConnection(connectionString);

        string createCountriesSQL = "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))";
        string createTownsSQL = "CREATE TABLE Towns (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), CountryId INT, CONSTRAINT FK_TownCountry FOREIGN KEY (CountryId) REFERENCES Countries(Id))";
        string createMinionsSQL = "CREATE TABLE Minions (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), Age INT, TownId INT, CONSTRAINT FK_Towns FOREIGN KEY (TownId) REFERENCES Towns(Id))";
        string createEvilnessFactorsSQL = "CREATE TABLE EvilnessFactors (Id INT PRIMARY KEY, Name VARCHAR(10) UNIQUE NOT NULL)";
        string createVillainsSQL = "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT, CONSTRAINT FK_VillainEvilnessFactor FOREIGN KEY (EvilnessFactorId) REFERENCES EvilnessFactors(Id))";
        string createMinionsVillainsSQL = "CREATE TABLE MinionsVillains(MinionId INT, VillainId INT, CONSTRAINT FK_Minions FOREIGN KEY (MinionId) REFERENCES Minions(Id), CONSTRAINT  FK_Villains FOREIGN KEY (VillainId) REFERENCES Villains(Id), CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId))";

        dbCon.Open();

        using (dbCon)
        {
            try
            {
                ExecuteCommand(createCountriesSQL, dbCon);
                ExecuteCommand(createTownsSQL, dbCon);
                ExecuteCommand(createMinionsSQL, dbCon);
                ExecuteCommand(createEvilnessFactorsSQL, dbCon);
                ExecuteCommand(createVillainsSQL, dbCon);
                ExecuteCommand(createMinionsVillainsSQL, dbCon);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        string insertCountriesSQL = "INSERT INTO Countries VALUES ('Bulgaria'), ('United Kingdom'), ('United States of America'), ('France')";
        string insertTownsSQL = "INSERT INTO Towns (Name, CountryId) VALUES ('Sofia',1), ('Burgas',1), ('Varna', 1), ('London', 2),('Liverpool', 2),('Ocean City', 3),('Paris', 4)";
        string insertMinionsSQL = "INSERT INTO Minions (Name, Age, TownId) VALUES ('bob',10,1),('kevin',12,2),('stuart',9,3), ('rob',22,3), ('michael',5,2),('pep',3,2)";
        string insertEvilnessFactorsSQL = "INSERT INTO EvilnessFactors VALUES (1, 'Super Good'), (2, 'Good'), (3, 'Bad'), (4, 'Evil'), (5, 'Super Evil')";
        string insertVillainsSQL = "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru', 2),('Victor', 4),('Simon Cat', 3),('Pusheen', 1),('Mammal', 5)";
        string insertMinionsVillainsSQL = "INSERT INTO MinionsVillains VALUES (1, 2), (3, 1), (1, 3), (3, 3), (4, 1), (2, 2), (1, 1), (3, 4), (1, 4), (1, 5), (5, 1)";

        dbCon = new SqlConnection(connectionString);
        dbCon.Open();

        using (dbCon)
        {
            try
            {
                ExecuteCommand(insertCountriesSQL, dbCon);
                ExecuteCommand(insertTownsSQL, dbCon);
                ExecuteCommand(insertMinionsSQL, dbCon);
                ExecuteCommand(insertEvilnessFactorsSQL, dbCon);
                ExecuteCommand(insertVillainsSQL, dbCon);
                ExecuteCommand(insertMinionsVillainsSQL, dbCon);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public static void ExecuteCommand(string commandText, SqlConnection connection)
    {
        SqlCommand cmd = new SqlCommand(commandText, connection);
        cmd.ExecuteNonQuery();
    }
}
