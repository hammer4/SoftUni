using System;
using System.Globalization;

class GenericArraySort
{
    static void Main()
    {
        Console.WriteLine("What type will be the array?");
        Console.WriteLine("1. Numbers");
        Console.WriteLine("2. Strings");
        Console.WriteLine("3. DateTime");
        Console.Write("Your choice : ");
        int choice = int.Parse(Console.ReadLine());

        switch(choice)
        {
            case 1: double[] doubleArray = DoubleArray();
                Console.WriteLine("The elements before sorting: {0}", String.Join(", ", doubleArray));
                Console.WriteLine("The elements after sorting: {0}", String.Join(", ", SortArray(doubleArray)));
                break;
            case 2: string[] stringArray = StringArray();
                Console.WriteLine("The elements before sorting: {0}", String.Join(", ", stringArray));
                Console.WriteLine("The elements after sorting: {0}", String.Join(", ", SortArray(stringArray)));
                break;
            case 3: DateTime[] dateTimeArray = DateTimeArray();
                Console.WriteLine("The elements before sorting: {0}", String.Join(", ", dateTimeArray));
                Console.WriteLine("The elements after sorting: {0}", String.Join(", ", SortArray(dateTimeArray)));
                break;
            default: Console.WriteLine("Incorrect input."); break;
        }
    }

    static double[] DoubleArray()
    {
        Console.Write("What size will be the array? : ");
        int size = int.Parse(Console.ReadLine());
        double[] array = new double[size];
        Console.WriteLine("Enter the elements of the array: ");

        for(int i=0; i<array.Length; i++)
        {
            array[i] = double.Parse(Console.ReadLine());
        }

        return array;
    }

    static string[] StringArray()
    {
        Console.Write("What size will be the array? : ");
        int size = int.Parse(Console.ReadLine());
        string[] array = new string[size];
        Console.WriteLine("Enter the elements of the array: ");

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Console.ReadLine();
        }

        return array;
    }

    static DateTime[] DateTimeArray()
    {
        Console.Write("What size will be the array? : ");
        int size = int.Parse(Console.ReadLine());
        DateTime[] array = new DateTime[size];
        Console.WriteLine("Enter the elements of the array in format: d.MM.yyyy :");

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
        }

        return array;
    }

    static double[] SortArray(double[] unsortedArray)
    {
        int sortedElements = 0;
        for (int i = 0; i < unsortedArray.Length - 1; i++)
        {
            bool arrayIsSorted = true;
            for (int j = 0; j < unsortedArray.Length - sortedElements - 1; j++)
            {
                if (unsortedArray[j] > unsortedArray[j + 1])
                {
                    double changer = unsortedArray[j];
                    unsortedArray[j] = unsortedArray[j + 1];
                    unsortedArray[j + 1] = changer;
                    arrayIsSorted = false;
                }
            }
            if (arrayIsSorted)
            {
                break;
            }
            sortedElements++;
        }
        return unsortedArray;
    }

    static DateTime[] SortArray(DateTime[] unsortedArray)
    {
        int sortedElements = 0;
        for (int i = 0; i < unsortedArray.Length - 1; i++)
        {
            bool arrayIsSorted = true;
            for (int j = 0; j < unsortedArray.Length - sortedElements - 1; j++)
            {
                if (unsortedArray[j] > unsortedArray[j + 1])
                {
                    DateTime changer = unsortedArray[j];
                    unsortedArray[j] = unsortedArray[j + 1];
                    unsortedArray[j + 1] = changer;
                    arrayIsSorted = false;
                }
            }
            if (arrayIsSorted)
            {
                break;
            }
            sortedElements++;
        }
        return unsortedArray;
    }

    static string[] SortArray(string[] unsortedArray)
    {
        int sortedElements = 0;
        for (int i = 0; i < unsortedArray.Length - 1; i++)
        {
            bool arrayIsSorted = true;
            for (int j = 0; j < unsortedArray.Length - sortedElements - 1; j++)
            {
                int min = Math.Min(unsortedArray[j].Length, unsortedArray[j+1].Length);
                
                for(int k=0; k<min; k++)
                {
                    if(unsortedArray[j][k] > unsortedArray[j+1][k])
                    {
                        string changer = unsortedArray[j];
                        unsortedArray[j] = unsortedArray[j+1];
                        unsortedArray[j+1] = changer;
                        arrayIsSorted = false;
                        break;
                    }
                    else if(unsortedArray[j][k]==unsortedArray[j+1][k])
                    {
                        if(k == min -1)
                        {
                            if(unsortedArray[j].Length > unsortedArray[j+1].Length)
                            {
                                string changer = unsortedArray[j];
                                unsortedArray[j] = unsortedArray[j+1];
                                unsortedArray[j+1] = changer;
                                arrayIsSorted = false;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (arrayIsSorted)
            {
                break;
            }
            sortedElements++;
        }
        return unsortedArray;
    }
}