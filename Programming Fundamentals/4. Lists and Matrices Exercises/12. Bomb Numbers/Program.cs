using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> field = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] bombData = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int bomb = bombData[0];
            int bombPower = bombData[1];
            int bombIndex = field.IndexOf(bomb);

            while (bombIndex != -1)
            {
                List<int> resultField = new List<int>();
                resultField.AddRange(field.Take(bombIndex - bombPower).ToList());
                int firstBombedIndex = bombIndex - bombPower;
                if(firstBombedIndex<0)
                {
                    resultField.AddRange(field.Skip(bombPower * 2 + 1 + firstBombedIndex + resultField.Count).Take(field.Count - (bombPower * 2 + 1) - (bombIndex - bombPower)).ToList());
                }
                else
                {
                    resultField.AddRange(field.Skip(bombPower * 2 + 1 + resultField.Count).Take(field.Count - (bombPower * 2 + 1) - (bombIndex - bombPower)).ToList());
                }
                
                field = resultField;
                bombIndex = field.IndexOf(bomb);
            }

            Console.WriteLine(field.Sum());
        }
    }
}
