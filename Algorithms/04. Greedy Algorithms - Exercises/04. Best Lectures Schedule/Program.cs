using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine().Split().Last());
        List<Lecture> lectures = new List<Lecture>();

        for(int i=0; i<count; i++)
        {
            var input = Console.ReadLine().Split();
            string subject = input[0].Substring(0, input[0].Length - 1);
            int start = int.Parse(input[1]);
            int end = int.Parse(input[3]);
            lectures.Add(new Lecture { Subject = subject, StartTime = start, EndTime = end });
        }

        List<Lecture> selected = new List<Lecture>();

        while(lectures.Count > 0)
        {
            var current = lectures
                .OrderBy(l => l)
                .First();

            selected.Add(current);
            lectures.RemoveAll(l => l.StartTime < current.EndTime);
        }

        Console.WriteLine($"Lectures ({selected.Count}):");
        foreach(var lecture in selected)
        {
            Console.WriteLine($"{lecture.StartTime}-{lecture.EndTime} -> {lecture.Subject}");
        }
    }

    private class Lecture : IComparable<Lecture>
    {
        public string Subject { get; set; }

        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public int CompareTo(Lecture other)
        {
            return this.EndTime.CompareTo(other.EndTime);
        }
    }
}