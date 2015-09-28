using System;

public class JaggedArrays
{
    static void Main()
    {
        int[] numbers = { 0, 1, 4, 113, 55, 3, 1, 2, 66, 557, 124, 2 };
        int[] sizes = new int[3];
        int[] offsets = new int[3];

        // Calculate the sizes for each reminder (0, 1 and 2)
        foreach (var number in numbers)
        {
            int remainder = number % 3;
            sizes[remainder]++;
        }

        // Calculate the list of numbers for each reminder (0, 1 and 2)
        int[][] numbersByRemainder = new int[3][] { new int[sizes[0]], new int[sizes[1]], new int[sizes[2]] };
        foreach (var number in numbers)
        {
            int remainder = number % 3;
            int index = offsets[remainder];
            numbersByRemainder[remainder][index] = number;
            offsets[remainder]++;
        }

        // Print the result jagged array
        for (int row = 0; row < numbersByRemainder.GetLength(0); row++)
        {
            foreach (var num in numbersByRemainder[row])
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
