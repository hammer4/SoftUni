using System;

class BitsInverter
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int index=1;

        for(int i=0; i<n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            int newNumber=0;
            int bitValue;
            for(int j=7; j>=0; j--)
            {
                bitValue = (number >> j) & 1;
                
                if(index % step == 1|| step==1)
                {
                    if(bitValue==0)
                    {
                        bitValue = 1;
                    }
                    else
                    {
                        bitValue = 0;
                    }
                }

                newNumber <<= 1;
                newNumber |= bitValue;
                index++;
            }

            Console.WriteLine(newNumber);
        }
    }
}
