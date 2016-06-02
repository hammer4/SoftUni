using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Tour
{
    class Tour
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] distances = new int[size][];

            for (int i = 0; i< size; i++)
            {
                distances[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            int distance = 0;

            int[] cities = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int currentCity = 0;
            for(int i=0; i<cities.Length; i++)
            {
                int destination = cities[i];
                distance += distances[currentCity][destination];
                currentCity = destination;
            }

            Console.WriteLine(distance);
        }
    }
}
