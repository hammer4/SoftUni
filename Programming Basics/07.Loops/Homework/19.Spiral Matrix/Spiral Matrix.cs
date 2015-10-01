using System;

class SpiralMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] array = new int[n, n];
        int start = 0;
        int end = n - 1;
        int k = 1;
        while(start<=end)
        {
            for(int i=start; i<=end; i++)
            {
                array[start, i] = k;
                k++;
            }

            for(int i=start+1; i<=end; i++)
            {
                array[i, end] = k;
                k++;
            }

            for(int i=end-1; i>=start; i--)
            {
                array[end, i] = k;
                k++;
            }

            for(int i=end-1; i>start; i--)
            {
                array[i, start] = k;
                k++;
            }

            start++;
            end--;
        }

        for(int i=0; i<n; i++)
        {
            for(int j=0; j<n; j++)
            {
                Console.Write("{0,4}", array[i, j]);
            }
            Console.WriteLine();
        }
    }
}