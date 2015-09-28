using System;

class MethodsParameters
{
	static void PrintSign(int number)
	{
        if (number > 0)
        {
            Console.WriteLine("The number {0} is positive.", number);
        }
        else if (number < 0)
        {
            Console.WriteLine("The number {0} is negative.", number);
        }
        else
        {
            Console.WriteLine("The number {0} is zero.", number);
        }
	}

	static void PrintMax(float number1, float number2)
	{
		float max = number1;
		if (number2 > number1)
			max = number2;
		Console.WriteLine("Maximal number: {0}", max);
	}

	static void Main()
	{
		Console.Write("n = ");
		int n = int.Parse(Console.ReadLine());
        
		Console.Write("m = ");
		int m = int.Parse(Console.ReadLine());

		PrintSign(n);
		PrintSign(m);
		PrintMax(n, m);
	}
}
