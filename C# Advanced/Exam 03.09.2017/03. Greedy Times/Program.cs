using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Greedy_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<long>>> bag = new Dictionary<string, Dictionary<string, List<long>>>();

            long gold = 0, gems = 0, cash = 0;

            string input = Console.ReadLine();
            string pattern = @"(gold|[a-zA-Z]{3}|[a-zA-Z]+gem)[\s]+([0-9]+)";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            foreach(Match match in regex.Matches(input))
            {
                string item = match.Groups[1].ToString();
                long value = long.Parse(match.Groups[2].ToString());

                if(capacity >= value)
                {
                    if(item.ToLower().EndsWith("gem") && item.Length > 3)
                    {
                        if(gems + value <= gold)
                        {
                            gems += value;
                            if (!bag.ContainsKey("Gem"))
                            {
                                bag["Gem"] = new Dictionary<string, List<long>>(StringComparer.InvariantCultureIgnoreCase);
                            }

                            if (!bag["Gem"].ContainsKey(item))
                            {
                                bag["Gem"][item] = new List<long>();
                            }

                            bag["Gem"][item].Add(value);
                            capacity -= value;
                        }
                    }
                    else if(item.Length == 3)
                    {
                        if(cash + value <= gems)
                        {
                            cash += value;

                            if (!bag.ContainsKey("Cash"))
                            {
                                bag["Cash"] = new Dictionary<string, List<long>>(StringComparer.InvariantCultureIgnoreCase);
                            }

                            if (!bag["Cash"].ContainsKey(item))
                            {
                                bag["Cash"][item] = new List<long>();
                            }

                            bag["Cash"][item].Add(value);

                            capacity -= value;
                        }
                    }
                    else if(item.ToLower() == "gold")
                    {
                        gold += value;
                        if (!bag.ContainsKey("Gold"))
                        {
                            bag["Gold"] = new Dictionary<string, List<long>>(StringComparer.InvariantCultureIgnoreCase);
                        }

                        if (!bag["Gold"].ContainsKey(item))
                        {
                            bag["Gold"][item] = new List<long>();
                        }

                        bag["Gold"][item].Add(value);
                        capacity -= value;
                    }
                }
            }

            foreach(var kvp in bag.OrderByDescending(kvp => kvp.Value.Sum(kv => kv.Value.Sum())))
            {
                Console.WriteLine($"<{kvp.Key}> ${kvp.Value.Sum(kv => kv.Value.Sum())}");

                foreach(var kv in kvp.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value.Sum()))
                {
                    Console.WriteLine($"##{kv.Key} - {kv.Value.Sum()}");
                }
            }
        }
    }
}
