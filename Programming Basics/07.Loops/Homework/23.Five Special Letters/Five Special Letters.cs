using System;

class FiveSpecialLetters
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        int avalue = 5;
        int bvalue = -12;
        int cvalue = 47;
        int dvalue = 7;
        int evalue = -32;
        int multiplier = 1;
        int counter = 0;
        int weight = 0;
        for (char i = 'a'; i <= 'e'; i++)
            for (char j = 'a'; j <= 'e'; j++)
                for (char k = 'a'; k <= 'e'; k++)
                    for (char l = 'a'; l <= 'e'; l++)
                        for (char m = 'a'; m <= 'e'; m++)
                        {
                            string word = "" + i + j + k + l + m;
                            string finalString = "" + i;
                            if (j != i)
                            {
                                finalString += j;
                            }
                            if (k != i && k != j)
                            {
                                finalString += k;
                            }
                            if (l != i && l != j && l != k)
                            {
                                finalString += l;
                            }
                            if (m != i && m != j && m != k && m != l)
                            {
                                finalString += m;
                            }

                            for (int n = 0; n < finalString.Length; n++)
                            {
                                switch (finalString[n])
                                {
                                    case 'a': weight += multiplier * avalue; break;
                                    case 'b': weight += multiplier * bvalue; break;
                                    case 'c': weight += multiplier * cvalue; break;
                                    case 'd': weight += multiplier * dvalue; break;
                                    case 'e': weight += multiplier * evalue; break;
                                }
                                multiplier++;
                            }

                            if (weight >= start && weight <= end)
                            {
                                Console.Write(word + " ");
                                counter++;
                            }
                            multiplier = 1;
                            weight = 0;
                        }

        if (counter == 0)
            Console.Write("No");
        Console.WriteLine();
    }
}