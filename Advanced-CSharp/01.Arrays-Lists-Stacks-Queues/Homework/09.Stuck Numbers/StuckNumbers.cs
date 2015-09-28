using System;
using System.Linq;

class StuckNumbers
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        string[] integers = Console.ReadLine().Trim().Split(' ').ToArray();
        int counter = 0;

        for (int a = 0; a <= integers.Length - 4; a++)
            for (int b = a + 1; b <= integers.Length - 3; b++)
                for (int c = b + 1; c <= integers.Length - 2; c++)
                    for (int d = c + 1; d <= integers.Length - 1; d++)
                    {
                        if (integers[a] + integers[b] == integers[c] + integers[d])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[a], integers[b], integers[c], integers[d]);
                            counter++;
                        }
                        if (integers[a] + integers[b] == integers[d] + integers[c])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[a], integers[b], integers[d], integers[c]);
                            counter++;
                        }
                        if (integers[a] + integers[c] == integers[b] + integers[d])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[a], integers[c], integers[b], integers[d]);
                            counter++;
                        }
                        if (integers[a] + integers[c] == integers[d] + integers[b])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[a], integers[c], integers[d], integers[b]);
                            counter++;
                        }
                        if (integers[a] + integers[d] == integers[b] + integers[c])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[a], integers[d], integers[b], integers[c]);
                            counter++;
                        }
                        if (integers[a] + integers[d] == integers[c] + integers[b])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[a], integers[d], integers[c], integers[b]);
                            counter++;
                        }

                        if (integers[b] + integers[a] == integers[c] + integers[d])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[b], integers[a], integers[c], integers[d]);
                            counter++;
                        }
                        if (integers[b] + integers[a] == integers[d] + integers[c])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[b], integers[a], integers[d], integers[c]);
                            counter++;
                        }
                        if (integers[b] + integers[c] == integers[a] + integers[d])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[b], integers[c], integers[a], integers[d]);
                            counter++;
                        }
                        if (integers[b] + integers[c] == integers[d] + integers[a])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[b], integers[c], integers[d], integers[a]);
                            counter++;
                        }
                        if (integers[b] + integers[d] == integers[a] + integers[c])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[b], integers[d], integers[a], integers[c]);
                            counter++;
                        }
                        if (integers[b] + integers[d] == integers[c] + integers[a])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[b], integers[d], integers[c], integers[a]);
                            counter++;
                        }

                        if (integers[c] + integers[a] == integers[b] + integers[d])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[c], integers[a], integers[b], integers[d]);
                            counter++;
                        }
                        if (integers[c] + integers[a] == integers[d] + integers[b])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[c], integers[a], integers[d], integers[b]);
                            counter++;
                        }
                        if (integers[c] + integers[b] == integers[a] + integers[d])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[c], integers[b], integers[a], integers[d]);
                            counter++;
                        }
                        if (integers[c] + integers[b] == integers[d] + integers[a])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[c], integers[b], integers[d], integers[a]);
                            counter++;
                        }
                        if (integers[c] + integers[d] == integers[a] + integers[b])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[c], integers[d], integers[a], integers[b]);
                            counter++;
                        }
                        if (integers[c] + integers[d] == integers[b] + integers[a])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[c], integers[d], integers[b], integers[a]);
                            counter++;
                        }

                        if (integers[d] + integers[a] == integers[b] + integers[c])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[d], integers[a], integers[b], integers[c]);
                            counter++;
                        }
                        if (integers[d] + integers[a] == integers[c] + integers[b])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[d], integers[a], integers[c], integers[b]);
                            counter++;
                        }
                        if (integers[d] + integers[b] == integers[a] + integers[c])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[d], integers[b], integers[a], integers[c]);
                            counter++;
                        }
                        if (integers[d] + integers[b] == integers[c] + integers[a])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[d], integers[b], integers[c], integers[a]);
                            counter++;
                        }
                        if (integers[d] + integers[c] == integers[a] + integers[b])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[d], integers[c], integers[a], integers[b]);
                            counter++;
                        }
                        if (integers[d] + integers[c] == integers[b] + integers[a])
                        {
                            Console.WriteLine("{0}|{1}=={2}|{3}", integers[d], integers[c], integers[b], integers[a]);
                            counter++;
                        }
                    }
        if(counter==0)
        {
            Console.WriteLine("No");
        }
    }
}