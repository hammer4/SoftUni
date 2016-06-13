using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Trifon_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            long health = long.Parse(Console.ReadLine());
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[][] matrix = new char[rows][];

            for(int  i=0; i<rows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            int turns = 0;
            int counter = 0;

            for(int j=0; j<cols; j++)
            {
                for (int i = j % 2 == 0 ? 0 : rows - 1; i < rows && i >= 0; i = j % 2 == 0 ? i + 1 : i - 1)
                {
                    switch(matrix[i][j])
                    {
                        case 'F':
                            health = health - turns / 2;
                            break;
                        case 'H':
                            health = health + turns / 3;
                            break;
                        case 'T':
                            turns += 2;
                            break;
                    }

                    counter++;
                    if(health <= 0)
                    {
                        Console.WriteLine("Died at: [{0}, {1}]", i, j);
                        return;
                    }

                    turns++;
                }
            }

            Console.WriteLine("Quest completed!");
            Console.WriteLine("Health: {0}", health);
            Console.WriteLine("Turns: {0}", turns);
        }
    }
}
