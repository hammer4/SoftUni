using System;

class PrintLongSequence
{
    static void Main()
    {
        int number =2;
        for(int i=0; i<1000; i++)
        {
            if(i%2 == 0)
            {
                Console.Write(number + i + " ");
            }
            else
            {
                Console.Write(-(number + i) + " ");
            }
        }
    }
}