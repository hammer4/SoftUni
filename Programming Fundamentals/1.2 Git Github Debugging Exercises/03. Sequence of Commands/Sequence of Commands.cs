using System;
using System.Linq;

public class SequenceOfCommands_broken
{
	private const char ArgumentsDelimiter = ' ';

	public static void Main()
	{
		int sizeOfArray = int.Parse(Console.ReadLine());

		long[] array = Console.ReadLine()
			.Split(ArgumentsDelimiter)
			.Select(long.Parse)
			.ToArray();

		string command = Console.ReadLine();

		while (!command.Equals("stop"))
		{
			string[] line = command.Split(ArgumentsDelimiter);
			int[] args = new int[2];

			if (line[0].Equals("add") ||
                line[0].Equals("subtract") ||
                line[0].Equals("multiply"))
			{
				args[0] = int.Parse(line[1]);
				args[1] = int.Parse(line[2]);
			}

			PerformAction(array, line[0], args);

			PrintArray(array);
			Console.Write('\n');

			command = Console.ReadLine();
		}
	}

	static void PerformAction(long[] arr, string action, int[] args)
	{
		int pos = args[0] - 1;
		int value = args[1];

		switch (action)
		{
			case "multiply":
				arr[pos] *= value;
				break;
			case "add":
				arr[pos] += value;
				break;
			case "subtract":
				arr[pos] -= value;
				break;
			case "lshift":
				ArrayShiftLeft(arr);
				break;
			case "rshift":
				ArrayShiftRight(arr);
				break;
		}
	}

	private static void ArrayShiftRight(long[] arr)
	{
        long[] array = new long[arr.Length];

        for (int i = 1; i < arr.Length; i++)
		{
			array[i] = arr[i - 1];
		}

        array[0] = arr[arr.Length - 1];

        for(int i=0; i< arr.Length; i++)
        {
            arr[i] = array[i];
        }
	}

	private static void ArrayShiftLeft(long[] arr)
	{
        long[] array = new long[arr.Length];

        for (int i = arr.Length - 2; i >= 0; i--)
		{
			array[i] = arr[i + 1];
		}

        array[arr.Length - 1] = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = array[i];
        }
    }

	private static void PrintArray(long[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write(array[i] + " ");
		}
	}
}
