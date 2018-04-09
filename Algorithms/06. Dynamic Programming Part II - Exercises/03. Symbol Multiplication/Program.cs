using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    //Converted From C Code

    static int MAXSLEN = 100; 
    static int LETTS;
    public static sbyte[,] rel;
    public static string s;

    public static byte[,,] table;
    public static byte[,] split = new byte[MAXSLEN, MAXSLEN];

    public static void Main()
    {
        char[] alphabet =
            Console.ReadLine()
                .Split(new[] { '=', ' ', '{', '}', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(Char.Parse)
                .ToArray();

        LETTS = alphabet.Length;
        table = new byte[MAXSLEN, MAXSLEN, LETTS];

        Console.ReadLine();

        rel = new sbyte[LETTS, LETTS];

        for (int i = 0; i < LETTS; i++)
        {
            string row = Console.ReadLine().Trim();
            for (int j = 0; j < LETTS; j++)
            {
                rel[i, j] = (sbyte)row[j];
            }
        }

        s = Console.ReadLine().Split(new[] { '=', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray()[1];

        if (can(0, (byte)(s.Length - 1), 0) != 0)
        {
            putBrackets(0, (byte)(s.Length - 1));
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No solution");
        }
    }

    public static byte can(byte i, byte j, byte ch)
    {
        byte c1;
        byte c2;
        byte pos;
        if (table[i, j, ch] != 0)
        {
            return table[i, j, ch];
        }
        if (i == j)
        {
            return (s[i] == ch + 'a') ? (byte)1 : (byte)0;
        }
        for (c1 = 0; c1 < LETTS; c1++)
        {
            for (c2 = 0; c2 < LETTS; c2++)
            {
                if (rel[c1, c2] == ch + 'a')
                {
                    for (pos = i; pos <= j - 1; pos++)
                    {
                        if (can(i, pos, c1) != 0)
                        {
                            if (can((byte)(pos + 1), j, c2) != 0)
                            {
                                table[i, j, ch] = 1;
                                split[i, j] = pos;
                                return 1;
                            }
                        }
                    }
                }
            }
        }
        table[i, j, ch] = 0;
        return 0;
    }

    public static void putBrackets(byte i, byte j)
    {
        if (i == j)
        {
            Console.Write("{0}", s[i]);
        }
        else
        {
            Console.Write("(");
            putBrackets(i, split[i, j]);
            Console.Write("*");
            putBrackets((byte)(split[i, j] + 1), j);
            Console.Write(")");
        }
    }
}