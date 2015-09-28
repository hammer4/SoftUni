using System;

class PositiveNumbers
{
	static bool AreAllPositive(int[] sequence)
	{
		foreach (int number in sequence)
		{
			if (number <= 0)
			{
				return false;
			}
		}
		return true;
	}

	static void Main()
	{
		Console.Write("Number of elements = ");
		int size = int.Parse(Console.ReadLine());

		int[] array = new int[size];
		for (int i = 0; i < size; i++)
		{
			Console.Write("arr[{0}] = ", i);
			array[i] = int.Parse(Console.ReadLine());
		}

		bool allPositive = AreAllPositive(array);
		if (allPositive) 
		{
			Console.WriteLine("All array elements are positive.");
		}
		else
		{
			Console.WriteLine("Not all array elements are positive.");
		}
	}
}
