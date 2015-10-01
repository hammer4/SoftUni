using System;

class BitKiller
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int newNumber = 0;
        int index = 0;
        int byteCounter = 0;
        for (int i = 1; i <= n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if(step==1)
            {
                int bv = (number >> 7) & 1;
                switch (bv)
                {
                    case 0: Console.WriteLine(0); return;
                    case 1: Console.WriteLine(128); return;
                }
            }
            
            for (int bitIndex = 7; bitIndex >= 0; bitIndex--)
            {
                if (index % step != 1)  
                {
                    int bitValue = (number >> bitIndex) & 1;
                    newNumber <<= 1;
                    newNumber |= bitValue;
                    byteCounter++;
                }
                if (byteCounter == 8)
                {
                    Console.WriteLine(newNumber);
                    byteCounter = 0;
                    newNumber = 0;
                }
                index++;
            }
        }
        if (byteCounter!=0)
        {
            newNumber <<= (8 - byteCounter);
            Console.WriteLine(newNumber);
        }
    }
}
