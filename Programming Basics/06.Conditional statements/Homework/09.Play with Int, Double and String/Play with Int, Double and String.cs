using System;

class PlayWithIntDoubleAndString
{
    static void Main()
    {
        Console.WriteLine("Please choose a type: ");
        Console.WriteLine("1 --> int");
        Console.WriteLine("2 --> double");
        Console.WriteLine("3 --> string");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.Write("Please enter an integer: ");
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine(input + 1);
                break;
            case 2:
                Console.Write("Please enter a double: ");
                double input2 = double.Parse(Console.ReadLine());
                Console.WriteLine(input2 + 1);
                break;
            case 3:
                Console.Write("Please enter a string: ");
                string input3 = Console.ReadLine();
                Console.WriteLine(input3 + "*");
                break;
            default: Console.WriteLine("Not a valid choice."); break;
        }

    }
}