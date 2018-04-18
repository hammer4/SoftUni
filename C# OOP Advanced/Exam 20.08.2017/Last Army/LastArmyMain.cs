using System;
using System.Text;

public class LastArmyMain
{
    static void Main()
    {
        var engine = new Engine(new ConsoleReader(), new ConsoleWriter());
        engine.Run();
    }
}
