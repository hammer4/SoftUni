using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Console.WriteLine(WebUtility.UrlDecode(input));
    }
}