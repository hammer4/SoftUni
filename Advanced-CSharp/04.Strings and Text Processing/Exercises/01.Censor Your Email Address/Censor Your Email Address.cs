using System;

class CensorYourEmailAddress
{
    static void Main()
    {
        string email = Console.ReadLine();
        string username = email.Substring(0, email.IndexOf('@'));
        string domain = email.Substring(email.IndexOf('@') + 1, email.Length - username.Length - 1);
        string replacementString = new string('*', username.Length) + '@' + domain;
        string input = Console.ReadLine();
        string output = input.Replace(email, replacementString);
        Console.WriteLine(output);
    }
}
