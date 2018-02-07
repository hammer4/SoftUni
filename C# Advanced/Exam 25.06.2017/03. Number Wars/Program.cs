using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Queue<string> player1 = new Queue<string>(input);

            input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Queue<string> player2 = new Queue<string>(input);

            int turns = 0;

            while (player1.Count > 0 && player2.Count > 0)
            {
                if (turns > 200000)
                {
                    if (player1.Count > player2.Count)
                    {
                        Console.WriteLine($"First player wins after 1000000 turns");
                    }
                    else if (player1.Count < player2.Count)
                    {
                        Console.WriteLine($"Second player wins after 1000000 turns");
                    }
                    else
                    {
                        Console.WriteLine($"Draw after {turns} turns");
                    }

                    return;
                }
                turns++;

                List<string> cardsPlayed = new List<string>();
                string card1 = player1.Dequeue();
                int card1Number = int.Parse(card1.Substring(0, card1.Length - 1));
                string card2 = player2.Dequeue();
                int card2Number = int.Parse(card2.Substring(0, card2.Length - 1));
                cardsPlayed.Add(card1);
                cardsPlayed.Add(card2);

                if (card1Number > card2Number)
                {
                    cardsPlayed
                        .OrderByDescending(c => int.Parse(c.Substring(0, c.Length - 1)))
                        .ThenByDescending(c => c.Substring(c.Length - 1, 1))
                        .ToList()
                        .ForEach(player1.Enqueue);
                }
                else if (card1Number < card2Number)
                {
                    cardsPlayed
                        .OrderByDescending(c => int.Parse(c.Substring(0, c.Length - 1)))
                        .ThenByDescending(c => c.Substring(c.Length - 1, 1))
                        .ToList()
                        .ForEach(player2.Enqueue);
                }
                else
                {
                    while (player2.Count > 0 && player1.Count > 0)
                    {
                        string war11 = player1.Dequeue();
                        string war12 = player1.Dequeue();
                        string war13 = player1.Dequeue();

                        string war21 = player2.Dequeue();
                        string war22 = player2.Dequeue();
                        string war23 = player2.Dequeue();

                        cardsPlayed.Add(war11);
                        cardsPlayed.Add(war12);
                        cardsPlayed.Add(war13);
                        cardsPlayed.Add(war21);
                        cardsPlayed.Add(war22);
                        cardsPlayed.Add(war23);

                        int sum1 = cardsPlayed
                            .Skip(cardsPlayed.Count - 6)
                            .Take(3)
                            .Select(s => s[s.Length - 1])
                            .Sum(c => c);

                        int sum2 = cardsPlayed
                            .Skip(cardsPlayed.Count - 3)
                            .Take(3)
                            .Select(s => s[s.Length - 1])
                            .Sum(c => c);

                        if (sum1 > sum2)
                        {
                            cardsPlayed
                                .OrderByDescending(c => int.Parse(c.Substring(0, c.Length - 1)))
                                .ThenByDescending(c => c.Substring(c.Length - 1, 1))
                                .ToList()
                                .ForEach(player1.Enqueue);
                            break;
                        }
                        else if (sum1 < sum2)
                        {
                            cardsPlayed
                                .OrderByDescending(c => int.Parse(c.Substring(0, c.Length - 1)))
                                .ThenByDescending(c => c.Substring(c.Length - 1, 1))
                                .ToList()
                                .ForEach(player2.Enqueue);
                            break;
                        }
                    }
                }
            }

            if (player1.Count == 0 && player2.Count == 0)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else if (player1.Count == 0)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
            else if (player2.Count == 0)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
        }
    }
}

