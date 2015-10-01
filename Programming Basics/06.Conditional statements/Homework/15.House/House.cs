using System;

class House
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i=1; i<=n; i++)
        {
            if (i==1)
            {
                string dots = new string('.', n / 2);
                Console.WriteLine("{0}*{0}", dots);
            }
            else if (i>1 && i<=n/2)
            {
                string outerDots = new string('.', ((n - i * 2 - 1) / 2)+1);
                string innerDots = new string('.', i * 2 - 3);
                Console.WriteLine("{0}*{1}*{0}", outerDots, innerDots);
            }
            else if (i == n/2 +1)
            {
                string middle = new string('*', n);
                Console.WriteLine(middle);
            }
            else if (i > n/2+1 && i<n)
            {
                string outerDots = new string('.', n / 4);
                string innerDots = new string('.', n - (2*(n / 4) + 2));
                Console.WriteLine("{0}*{1}*{0}",outerDots,innerDots);
            }
            else
            {
                string dots = new string('.', n / 4);
                string asterisk = new string('*', n - 2*(n /4));
                Console.WriteLine("{0}{1}{0}", dots, asterisk, dots);
            }
        }
    }
}
