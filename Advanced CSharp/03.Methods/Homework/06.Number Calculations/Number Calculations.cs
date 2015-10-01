using System;

class NumberCalculations
{
    static void Main()
    {
        Console.WriteLine("What kind of numbers the array will be consisted of? ");
        Console.WriteLine("1. Integer");
        Console.WriteLine("2. Floating point");
        Console.WriteLine("3. Decimal");
        int choice = int.Parse(Console.ReadLine());

        switch(choice)
        {
            case 1: int[] arrayInt = ArrayOfIntegers();
                DisplayArrayData(arrayInt);
                break;
            case 2: double[] arrayDouble = ArrayOfFloating();
                DisplayArrayData(arrayDouble);
                break;
            case 3: decimal[] arrayDecimal = ArrayOfDecimals();
                DisplayArrayData(arrayDecimal);
                break;
            default: Console.WriteLine("Incorrect choice."); break;
        }
    }

    static int[] ArrayOfIntegers()
    {
        Console.WriteLine("What is the size of the array? : ");
        int size = int.Parse(Console.ReadLine());
        int[] array = new int[size];
        Console.WriteLine("Enter the elements of the array: ");

        for(int i=0; i<array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        return array;
    }

    static double[] ArrayOfFloating()
    {
        Console.WriteLine("What is the size of the array? : ");
        int size = int.Parse(Console.ReadLine());
        double[] array = new double[size];
        Console.WriteLine("Enter the elements of the array: ");

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = double.Parse(Console.ReadLine());
        }

        return array;
    }

    static decimal[] ArrayOfDecimals()
    {
        Console.WriteLine("What is the size of the array? : ");
        int size = int.Parse(Console.ReadLine());
        decimal[] array = new decimal[size];
        Console.WriteLine("Enter the elements of the array: ");

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = decimal.Parse(Console.ReadLine());
        }

        return array;
    }

    static void DisplayArrayData(int[] array)
    {
        int min = array[0];
        int max = array[0];
        int sum = 0;
        int product = 1;

        for(int i=0; i<array.Length; i++)
        {
            if(array[i] < min)
            {
                min = array[i];
            }

            if(array[i]>max)
            {
                max = array[i];
            }

            sum += array[i];
            product *= array[i];
        }

        Console.WriteLine();
        Console.WriteLine("Minimal element: {0}", min);
        Console.WriteLine("Maximal element: {0}", max);
        Console.WriteLine("Sum of all elements: {0}", sum);
        Console.WriteLine("Average value of elements: {0}", (double)sum / array.Length);
        Console.WriteLine("Product of all elements: {0}", product);
    }

    static void DisplayArrayData(double[] array)
    {
        double min = array[0];
        double max = array[0];
        double sum = 0;
        double product = 1;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }

            if (array[i] > max)
            {
                max = array[i];
            }

            sum += array[i];
            product *= array[i];
        }

        Console.WriteLine();
        Console.WriteLine("Minimal element: {0}", min);
        Console.WriteLine("Maximal element: {0}", max);
        Console.WriteLine("Sum of all elements: {0}", sum);
        Console.WriteLine("Average value of elements: {0}", sum / array.Length);
        Console.WriteLine("Product of all elements: {0}", product);
    }

    static void DisplayArrayData(decimal[] array)
    {
        decimal min = array[0];
        decimal max = array[0];
        decimal sum = 0;
        decimal product = 1;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }

            if (array[i] > max)
            {
                max = array[i];
            }

            sum += array[i];
            product *= array[i];
        }

        Console.WriteLine();
        Console.WriteLine("Minimal element: {0}", min);
        Console.WriteLine("Maximal element: {0}", max);
        Console.WriteLine("Sum of all elements: {0}", sum);
        Console.WriteLine("Average value of elements: {0}", sum / array.Length);
        Console.WriteLine("Product of all elements: {0}", product);
    }
}