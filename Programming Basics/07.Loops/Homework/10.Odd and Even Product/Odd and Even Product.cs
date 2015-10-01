using System;

class OddAndEvenProduct
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        string[] numbers = inputLine.Split(' ');
        int oddProduct = 1;
        int evenProduct = 1;

        for (int i=0; i<= numbers.Length-1; i++)
        {
            if(i%2 == 0)
            {
                int number = int.Parse(numbers[i]);
                oddProduct *= number;
            }
            else
            {
                int number = int.Parse(numbers[i]);
                evenProduct *= number;
            }
        }

        if(oddProduct == evenProduct)
        {
            Console.WriteLine("yes");
            Console.WriteLine("product = {0}", oddProduct);
        }
        else
        {
            Console.WriteLine("no");
            Console.WriteLine("odd_product = {0}", oddProduct);
            Console.WriteLine("even_product = {0}", evenProduct);
        }
    }
}