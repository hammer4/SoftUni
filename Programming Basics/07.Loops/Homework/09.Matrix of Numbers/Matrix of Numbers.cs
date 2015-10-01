using System;

class MatrixOfNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for(int i =1; i<=n; i++)
        {
            for(int j=i; j<i+n; j++)
            {
                Console.Write("{0,3}", j);
            }
            Console.WriteLine();
        }
    }
}