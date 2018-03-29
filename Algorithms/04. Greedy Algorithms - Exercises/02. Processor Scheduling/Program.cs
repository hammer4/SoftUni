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

        List<Task> tasks = new List<Task>();

        for(int i=0; i<count; i++)
        {
            var input = Console.ReadLine().Split();
            tasks.Add(new Task { Value = int.Parse(input.First()), Deadline = int.Parse(input.Last()) });
        }

        int endTime = tasks.Max(t => t.Deadline);

        var selectedTasks = new List<Task>();

        for(int i=0; i<endTime; i++)
        {
            var mostValuableTasks = tasks
                .Where(t => !t.IsCompleted && t.Deadline > i)
                .OrderByDescending(t => t.Value/(t.Deadline - i))
                .Take(endTime - i)
                .ToList();

            var currentTask = mostValuableTasks.First();
            currentTask.IsCompleted = true;

            selectedTasks.Add(currentTask);
        }

        Console.WriteLine($"Optimal schedule: {String.Join(" -> ", selectedTasks.Select(t => t.Id))}");
        Console.WriteLine($"Total value: {selectedTasks.Sum(t => t.Value)}");
    }

    private class Task
    {
        static int id = 1;

        public int Id { get; set; } = id++;

        public int Value { get; set; }

        public int Deadline { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}