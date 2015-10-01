using System;

class BitRoller
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int f = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());
        int newNumber=0;

        if(f<18 && f>0)
        {
            for(int i=1; i<=r; i++)
            {
                int bitAtPostion = n & 1;
                newNumber <<= 1;
                newNumber |= bitAtPostion;
                
                for(int j=18; j>=1; j--)
                {
                    if(j != f+1)
                    {
                        bitAtPostion = (n >> j) & 1;
                        newNumber <<= 1;
                        newNumber |= bitAtPostion;
                    }
                    else
                    {
                        bitAtPostion = (n >> f) & 1;
                        newNumber <<= 1;
                        newNumber |= bitAtPostion;
                        bitAtPostion = (n >> f + 1) & 1;
                        newNumber <<= 1;
                        newNumber |= bitAtPostion;
                        j--;
                    }
                }
                n = newNumber;
                newNumber = 0;
            }
        }

        else if(f==18)
        {
            for(int i=1; i<=r; i++)
            {
                int bitAtPosition = (n >> 18) & 1;
                newNumber <<= 1;
                newNumber |= bitAtPosition;
                bitAtPosition = n & 1;
                newNumber <<= 1;
                newNumber |= bitAtPosition;

                for(int j=17; j>=1; j--)
                {
                    bitAtPosition = (n >> j) & 1;
                    newNumber <<= 1;
                    newNumber |= bitAtPosition;
                }
                
                n = newNumber;
                newNumber = 0;
            }
        }

        else
        {
            for(int i=1; i<=r; i++)
            {
                int bitAtPosition = n >> 1 & 1;
                newNumber <<= 1;
                newNumber |= bitAtPosition;

                for(int j=18; j>=2; j--)
                {
                    bitAtPosition = n >> j & 1;
                    newNumber <<= 1;
                    newNumber |= bitAtPosition;
                }

                bitAtPosition = n & 1;
                newNumber <<= 1;
                newNumber |= bitAtPosition;

                n = newNumber;
                newNumber = 0;
            }
        }
        Console.WriteLine(n);
    }
}