using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());
        char[,] matrix = new char[length, length];

        int x = 0, y = 0;

        for (int i = 0; i < length; i++)
        {
            var symbols = Console.ReadLine().ToCharArray();
            for (int j = 0; j < length; j++)
            {
                matrix[i, j] = symbols[j];
                if (symbols[j] == '*')
                {
                    x = j;
                    y = i;
                }
            }
        }

        var result = new string[length, length];
        result[y, x] = "*";

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (matrix[i, j] == 'x')
                {
                    result[i, j] = "x";
                }

                if (i > 0)
                {
                    if (matrix[i - 1, j] == '*' && matrix[i, j] == '0')
                    {
                        result[i, j] = "1";
                    }
                }

                if (i < length - 1)
                {
                    if (matrix[i + 1, j] == '*' && matrix[i, j] == '0')
                    {
                        result[i, j] = "1";
                    }
                }

                if (j > 0)
                {
                    if (matrix[i, j - 1] == '*' && matrix[i, j] == '0')
                    {
                        result[i, j] = "1";
                    }
                }

                if (j < length - 1)
                {
                    if (matrix[i, j + 1] == '*' && matrix[i, j] == '0')
                    {
                        result[i, j] = "1";
                    }
                }
            }
        }

        for (int k = 2; k < length * length; k++)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i > 0)
                    {
                        if (result[i - 1, j] == (k - 1).ToString() && result[i, j] == null)
                        {
                            result[i, j] = k.ToString();
                        }
                    }

                    if (i < length - 1)
                    {
                        if (result[i + 1, j] == (k - 1).ToString() && result[i, j] == null)
                        {
                            result[i, j] = k.ToString();
                        }
                    }

                    if (j > 0)
                    {
                        if (result[i, j - 1] == (k - 1).ToString() && result[i, j] == null)
                        {
                            result[i, j] = k.ToString();
                        }
                    }

                    if (j < length - 1)
                    {
                        if (result[i, j + 1] == (k - 1).ToString() && result[i, j] == null)
                        {
                            result[i, j] = k.ToString();
                        }
                    }
                }
            }
        }

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (result[i, j] == null)
                {
                    result[i, j] = "u";
                }
                Console.Write(result[i, j]);
            }

            Console.WriteLine();
        }
    }
}