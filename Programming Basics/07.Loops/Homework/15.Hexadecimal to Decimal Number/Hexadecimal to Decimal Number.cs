using System;

class HexadecimalToDecimalNumber
{
    static void Main()
    {
        string n = Console.ReadLine();
        long nInDecimal = 0;
        long multiplier = 1;
        char[] array = n.ToCharArray();
        for (int i = array.Length - 1; i >= 0; i--)
        {
            switch (array[i])
            {
                case '0': nInDecimal += 0 * multiplier; break;
                case '1': nInDecimal += 1 * multiplier; break;
                case '2': nInDecimal += 2 * multiplier; break;
                case '3': nInDecimal += 3 * multiplier; break;
                case '4': nInDecimal += 4 * multiplier; break;
                case '5': nInDecimal += 5 * multiplier; break;
                case '6': nInDecimal += 6 * multiplier; break;
                case '7': nInDecimal += 7 * multiplier; break;
                case '8': nInDecimal += 8 * multiplier; break;
                case '9': nInDecimal += 9 * multiplier; break;
                case 'A': nInDecimal += 10 * multiplier; break;
                case 'B': nInDecimal += 11 * multiplier; break;
                case 'C': nInDecimal += 12 * multiplier; break;
                case 'D': nInDecimal += 13 * multiplier; break;
                case 'E': nInDecimal += 14 * multiplier; break;
                case 'F': nInDecimal += 15 * multiplier; break;
                default: Console.WriteLine("Invalid input!");
                    return;
            }
            multiplier *= 16;
        }
        Console.WriteLine(nInDecimal);
    }
}
