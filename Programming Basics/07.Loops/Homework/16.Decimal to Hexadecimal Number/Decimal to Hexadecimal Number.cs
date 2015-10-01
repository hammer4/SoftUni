using System;

class DecimalToHexadecimalNumber
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        if (n == 0)
        {
            Console.WriteLine(0);
            return;
        }
        long hexDigit;
        string nInHex = "";
        while (n > 0)
        {
            hexDigit = n % 16;
            switch (hexDigit)
            {
                case 0: nInHex += '0'; break;
                case 1: nInHex += '1'; break;
                case 2: nInHex += '2'; break;
                case 3: nInHex += '3'; break;
                case 4: nInHex += '4'; break;
                case 5: nInHex += '5'; break;
                case 6: nInHex += '6'; break;
                case 7: nInHex += '7'; break;
                case 8: nInHex += '8'; break;
                case 9: nInHex += '9'; break;
                case 10: nInHex += 'A'; break;
                case 11: nInHex += 'B'; break;
                case 12: nInHex += 'C'; break;
                case 13: nInHex += 'D'; break;
                case 14: nInHex += 'E'; break;
                case 15: nInHex += 'F'; break;
            }
            n /= 16;
        }
        char[] array = nInHex.ToCharArray();
        Array.Reverse(array);
        nInHex = new string(array);
        Console.WriteLine(nInHex);
    }
}
