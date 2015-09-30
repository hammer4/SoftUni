using System;
using System.Text;

class PrinttheASCIITable
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        for(int i=0; i<256; i++)
        {
            Console.WriteLine(i + " -> " + (char)i);
        }
    }
}