using _01._Event_Implementation.Models;
using System;

namespace _01._Event_Implementation.Models
{
    public class Handler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
        }
    }
}