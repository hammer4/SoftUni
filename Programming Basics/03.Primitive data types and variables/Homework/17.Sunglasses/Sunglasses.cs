using System;

class Sunglasses
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        for(int i=1; i<= size; i++)
        {
            string lens = "*" + new string('/', 2*size - 2) + "*";
            
            if (i==1 || i==size)
            {
                string asterisks = new string('*', 2 * size);
                string spaces = new string(' ', size);
                Console.WriteLine("{0}{1}{0}", asterisks, spaces);
            }
            else if(i==size/2 +1)
            {
                Console.WriteLine("{0}{1}{0}", lens, new string('|', size));
            }
            else
            {
                Console.WriteLine("{0}{1}{0}", lens, new string(' ', size));
            }
        }
    }
}