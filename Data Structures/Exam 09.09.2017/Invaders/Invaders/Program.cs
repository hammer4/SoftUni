using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var comp = new Computer(100);

        comp.AddInvader(new Invader(10, 5));
        comp.Skip(1);
        System.Console.WriteLine(comp.Invaders().ToList().Count);
        comp.AddInvader(new Invader(10, 5));
        System.Console.WriteLine(comp.Invaders().ToList().Count);
        System.Console.WriteLine(comp.Energy);
        comp.DestroyTargetsInRadius(4);
        System.Console.WriteLine(comp.Invaders().ToList().Count);
    }
}
