using System;

class NumberAsWords
{
    static void Main()
    {
        Console.Write("Enter a number (0-999): ");
        int number = int.Parse(Console.ReadLine());
        if (number >= 0 && number <= 999)
        {
            switch (number / 100)
            {
                case 0: break;
                case 1: Console.Write("One hundred "); break;
                case 2: Console.Write("Two hundred "); break;
                case 3: Console.Write("Three hundred "); break;
                case 4: Console.Write("Four hundred "); break;
                case 5: Console.Write("Five hundred "); break;
                case 6: Console.Write("Six hundred "); break;
                case 7: Console.Write("Seven hundred "); break;
                case 8: Console.Write("Eight hundred "); break;
                case 9: Console.Write("Nine hundred "); break;
            }

            if (number / 100 != 0 && number % 100 != 0 && number % 100 > 9)
            {
                Console.Write("and ");
            }

            switch ((number / 10) % 10)
            {
                case 0: break;
                case 1:
                    switch (number % 10)
                    {
                        case 0: Console.Write("ten"); break;
                        case 1: Console.Write("eleven"); break;
                        case 2: Console.Write("twelve"); break;
                        case 3: Console.Write("thirteen"); break;
                        case 4: Console.Write("fourteen"); break;
                        case 5: Console.Write("fifteen"); break;
                        case 6: Console.Write("sixteen"); break;
                        case 7: Console.Write("seventeen"); break;
                        case 8: Console.Write("eighteen"); break;
                        case 9: Console.Write("nineteen"); break;
                    }
                    break;
                case 2: Console.Write("twenty "); break;
                case 3: Console.Write("thirty "); break;
                case 4: Console.Write("fourty "); break;
                case 5: Console.Write("fifty "); break;
                case 6: Console.Write("sixty "); break;
                case 7: Console.Write("seventy "); break;
                case 8: Console.Write("eighty "); break;
                case 9: Console.Write("ninety "); break;

            }
            if ( number/10 % 10 == 0 && number%100 !=0)
            {
                Console.Write("and ");
            }

            if ((number / 10) % 10 != 1)
            {
                switch (number % 10)
                {
                    case 0:
                        if (number == 0)
                            Console.Write("Zero");
                        break;
                    case 1: Console.Write("one"); break;
                    case 2: Console.Write("two"); break;
                    case 3: Console.Write("three"); break;
                    case 4: Console.Write("four"); break;
                    case 5: Console.Write("five"); break;
                    case 6: Console.Write("six"); break;
                    case 7: Console.Write("seven"); break;
                    case 8: Console.Write("eight"); break;
                    case 9: Console.Write("nine"); break;
                }
            }
        }
        else
        {
            Console.Write("Number too big or too small! ");
        }
        Console.WriteLine();
    }
}