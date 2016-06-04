using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Censor_Your
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string text = Console.ReadLine();
            string[] emailParts = email.Split('@');
            string username = emailParts[0];
            string domain = emailParts[1];
            string emailReplacement = new string('*', username.Length) + "@" + domain;
            Console.WriteLine(text.Replace(email, emailReplacement));
        }
    }
}
