using System;

class Program
{
    static void Main(string[] args)
    {
        var repository = new WeaponRepository();
        var interpreter = new CommandInterpreter();
        var weaponFactory = new WeaponFactory();
        var gemFactory = new GemFactory();

        IRunnable engine = new Engine(gemFactory, weaponFactory, interpreter, repository);

        engine.Run();
    }
}