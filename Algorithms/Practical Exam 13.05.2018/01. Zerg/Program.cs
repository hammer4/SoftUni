using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        BigInteger[,] matrix = new BigInteger[sizes[0], sizes[1]];
        int[] destination = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int enemiesCount = int.Parse(Console.ReadLine());

        bool[,] enemies = new bool[sizes[0], sizes[1]];

        for(int i=0; i<enemiesCount; i++)
        {
            int[] enemyCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
            enemies[enemyCoordinates[0], enemyCoordinates[1]] = true;
        }

        for(int i=0; i<=destination[0]; i++)
        {
            for(int j=0; j<= destination[1]; j++)
            {
                if(i == 0 && j == 0)
                {
                    matrix[i, j] = 1;
                    continue;
                }

                if(enemies[i,j] == false)
                {
                    BigInteger count = 0;

                    if (i > 0)
                    {
                        count += matrix[i - 1, j];
                    }

                    if(j > 0)
                    {
                        count += matrix[i, j - 1];
                    }

                    matrix[i, j] = count;
                }
            }
        }

        Console.WriteLine(matrix[destination[0], destination[1]]);
    }
}