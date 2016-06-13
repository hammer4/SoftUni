using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Football_League
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            Dictionary<string, List<long>> teams = new Dictionary<string, List<long>>();
            string command = Console.ReadLine();

            while (command.ToLower() != "final")
            {
                string[] tokens = command.Split(' ');
                string decryptedHomeTeam = tokens[0];
                int startIndex = decryptedHomeTeam.IndexOf(key);
                int endIndex = decryptedHomeTeam.LastIndexOf(key);
                string homeTeam = decryptedHomeTeam.Substring(startIndex + key.Length, endIndex - startIndex - key.Length);
                char[] homeTeamArray = homeTeam.ToUpper().ToCharArray();
                Array.Reverse(homeTeamArray);
                homeTeam = new string(homeTeamArray);

                string decryptedAwayTeam = tokens[1];
                startIndex = decryptedAwayTeam.IndexOf(key);
                endIndex = decryptedAwayTeam.LastIndexOf(key);
                string awayTeam = decryptedAwayTeam.Substring(startIndex + key.Length, endIndex - startIndex - key.Length);
                char[] awayTeamArray = awayTeam.ToUpper().ToCharArray();
                Array.Reverse(awayTeamArray);
                awayTeam = new string(awayTeamArray);

                long[] goals = tokens[2].Split(':').Select(long.Parse).ToArray();
                long homeTeamGoals = goals[0];
                long awayTeamGoals = goals[1];

                long pointsForHomeTeam;
                long pointsForAwayTeam;
                if(homeTeamGoals > awayTeamGoals)
                {
                    pointsForHomeTeam = 3;
                    pointsForAwayTeam = 0;
                }
                else if(homeTeamGoals < awayTeamGoals)
                {
                    pointsForHomeTeam = 0;
                    pointsForAwayTeam = 3;
                }
                else
                {
                    pointsForHomeTeam = 1;
                    pointsForAwayTeam = 1;
                }
                
                if(teams.ContainsKey(homeTeam))
                {
                    teams[homeTeam][0] += pointsForHomeTeam;
                    teams[homeTeam][1] += homeTeamGoals;
                }
                else
                {
                    teams[homeTeam] = new List<long>();
                    teams[homeTeam].Add(pointsForHomeTeam);
                    teams[homeTeam].Add(homeTeamGoals);
                }

                if(teams.ContainsKey(awayTeam))
                {
                    teams[awayTeam][0] += pointsForAwayTeam;
                    teams[awayTeam][1] += awayTeamGoals;
                }
                else
                {
                    teams[awayTeam] = new List<long>();
                    teams[awayTeam].Add(pointsForAwayTeam);
                    teams[awayTeam].Add(awayTeamGoals);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("League standings:");
            int counter = 1;
            
            foreach(var pair in teams.OrderByDescending(t => t.Value[0]).ThenBy(t => t.Key))
            {
                Console.WriteLine("{0}. {1} {2}", counter, pair.Key, pair.Value[0]);
                counter++;
            }

            Console.WriteLine("Top 3 scored goals:");
            foreach(var pair in teams.OrderByDescending(t => t.Value[1]).ThenBy(t => t.Key).Take(3))
            {
                Console.WriteLine("- {0} -> {1}", pair.Key, pair.Value[1]);
            }
        }
    }
}
