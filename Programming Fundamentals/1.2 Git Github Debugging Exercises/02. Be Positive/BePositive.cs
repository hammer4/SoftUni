using System;
using System.Collections.Generic;

public class BePositive_broken
{
	public static void Main()
	{
		int countSequences = int.Parse(Console.ReadLine());

		for (int i = 0; i < countSequences; i++)
		{
			string[] input = Console.ReadLine().Trim().Split(' ');
			var numbers = new List<int>();

			for (int j = 0; j < input.Length; j++)
			{
				if (!input[j].Equals(string.Empty))
				{
					int num = int.Parse(input[j]);
					numbers.Add(num);
				}
			}

			bool found = false;

			for (int j = 0; j < numbers.Count; j++)
			{
				int currentNum = numbers[j];

				if (currentNum >= 0)
				{
					if (found)
						{
							Console.Write(" ");
						}

						Console.Write(currentNum);

						found = true;
				}
				else
				{
                    if (j < numbers.Count - 1)
                    {
                        currentNum += numbers[j + 1];

                        if (currentNum >= 0)
                        {
                            if (found)
                            {
                                Console.Write(" ");
                            }

                            Console.Write(currentNum);

                            found = true;
                        }

                        j++;
                    }
				}
			}

			if (!found)
			{
				Console.Write("(empty)");
			}

            Console.WriteLine();
		}
	}
}