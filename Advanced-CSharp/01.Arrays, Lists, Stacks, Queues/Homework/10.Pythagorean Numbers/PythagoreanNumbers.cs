using System;

class PythagoreanNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int[] array = new int[number];
        bool pythagoreanNumbersExist = false;

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        for (int a = 0; a < array.Length; a++)
        {
            for (int b = 0; b < array.Length; b++)
            {
                for (int c = 0; c < array.Length; c++)
                {


                    if (array[a]<=array[b]   &&   array[a] * array[a] + array[b] * array[b] == array[c] * array[c])
                    {
                        Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", array[a], array[b], array[c]);
                        pythagoreanNumbersExist = true;
                    }

                }
            }
        }

        if (!pythagoreanNumbersExist)
        {
            Console.WriteLine("No");
        }
    }
}