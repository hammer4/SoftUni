using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] array = Console.ReadLine().Split().Select(long.Parse).ToArray();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] tokens = command.Split().ToArray();

                switch (tokens[0])
                {
                    case "swap":
                        long index1 = long.Parse(tokens[1]);
                        long index2 = long.Parse(tokens[2]);
                        long changer = array[index1];
                        array[index1] = array[index2];
                        array[index2] = changer;
                        break;
                    case "multiply":
                        int index11 = int.Parse(tokens[1]);
                        int index21 = int.Parse(tokens[2]);
                        array[index11] *= array[index21];
                        break;
                    case "decrease":
                        for (int i = 0; i < array.Length; i++)
                        {
                            array[i]--;
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(", ", array));
        }
    }
}
