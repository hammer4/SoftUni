using System;
using System.Collections.Generic;

class Events
{
    static void Main()
    {
        // Create an events table: a set of pairs of (date -> event)
        SortedDictionary<DateTime, string> events = new SortedDictionary<DateTime, string>();

        // Put a few events
        events[new DateTime(1998, 9, 4)] = "Google's birth date";
        events[new DateTime(2013, 11, 5)] = "Software University's birth date";
        events[new DateTime(1975, 4, 4)] = "Microsoft's birth date";
        events[new DateTime(2004, 2, 4)] = "Facebook's birth date";
        events[new DateTime(2013, 11, 5)] =
            "Nakov left Telerik Academy to establish the Software University";

        Console.WriteLine("List of all events:");
        foreach (var entry in events)
        {
            Console.WriteLine("{0:dd-MMM-yyyy}: {1}", entry.Key, entry.Value);
        }

        Console.WriteLine();
        Console.WriteLine("List of all dates:");
        foreach (var date in events.Keys)
        {
            Console.WriteLine("{0:dd-MMM-yyyy}", date);
        }

        Console.WriteLine();
        Console.WriteLine("List of all event names:");
        foreach (var name in events.Values)
        {
            Console.WriteLine("{0}", name);
        }
    }
}
