using System;

class BitsUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int index = 0;
        for (int i = 1; i <= n; i++)
        {
            int b = int.Parse(Console.ReadLine());

            for (int byteIndex = 7; byteIndex >= 0; byteIndex--)
            {
                if (index % step == 1 || step ==1 && index>0)
                {
                    int mask = 1 << byteIndex;
                    b |= mask;
                }
                index++;
            }
            Console.WriteLine(b);
        }
    }
}
