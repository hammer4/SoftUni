using System;

class BitExchangeAdvanced
{
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int q = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        if(p<0 || q<0 || p+k-1>31 || q+k-1>31)
        {
            Console.WriteLine("out of range");
            return;
        }

        if(p>q)
        {
            if(q+k-1 >= p)
            {
                Console.WriteLine("overlapping");
                return;
            }
        }
        else if (p==q)
        {
            Console.WriteLine(number);
            return;
        }
        else
        {
            if(p+k-1 >= q)
            {
                Console.WriteLine("overlapping");
                return;
            }
        }

        uint bitsOne = 0;
        
        for(int i=1; i<=k; i++)
        {
            bitsOne <<= 1;
            bitsOne |= 1;
        }

        uint mask1 = bitsOne & (number >> p);
        uint mask2 = bitsOne & (number >> q);

        uint zerosAtP=0;

        for(int i=0; i<32; i++)
        {
            if(i>=32-p-k && i<32-p)
            {
                zerosAtP <<= 1;
            }
            else
            {
                zerosAtP <<= 1;
                zerosAtP |= 1;
            }
        }

        uint zerosAtQ = 0;

        for (int i = 0; i < 32; i++)
        {
            if (i >= 32-q-k && i <32- q)
            {
                zerosAtQ <<= 1;
            }
            else
            {
                zerosAtQ <<= 1;
                zerosAtQ |= 1;
            }
        }

        number &= zerosAtP;
        number &= zerosAtQ;
        number |= mask2<<p;
        number |= mask1<<q;

        Console.WriteLine(number);
    }
}