using System;

class NineDigitMagicNumbers
{
    static void Main()
    {
        int counter = 0;
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        for (int a=1; a<=7; a++)
            for (int b=1; b<=7; b++)
                for (int c=1; c<=7; c++)
                    for (int d=1; d<=7; d++)
                        for (int e=1; e<=7; e++)
                            for (int f=1; f<=7; f++)
                                for (int g=1; g<=7; g++)
                                    for (int h=1; h<=7; h++)
                                        for (int i=1; i<=7; i++)
                                        {
                                            if ((a + b + c + d + e + f + g + h + i == sum) && ((100 * d + 10 * e + f) - (100 * a + 10 * b + c) == diff) &&
                                                (100 * g + 10 * h + i) - (100 * d + 10 * e + f) == diff)
                                            {
                                                Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}", a, b, c, d, e, f, g, h, i);
                                                counter++;
                                            }
                                            
                                        }
        if (counter == 0)
            Console.WriteLine("No");
    }
}
