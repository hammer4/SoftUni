using System;
using System.Collections.Generic;
using System.Linq;

class Palindromes
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] words = input.Split(new char[] {' ', ',', '.','?','!'},StringSplitOptions.RemoveEmptyEntries);
        List<string> listOfPalindromes = new List<string>();

        foreach(string word in words)
        {
            bool isPalindrome = true;
            
            for(int i=0; i<word.Length/2; i++)
            {
                if(word[i] != word[word.Length - i - 1])
                {
                    isPalindrome = false;
                }
            }

            if(isPalindrome)
            {
                listOfPalindromes.Add(word);
            }
        }
 
        listOfPalindromes.Sort();
        Console.WriteLine(string.Join(", ", listOfPalindromes.Distinct()));
    }
}