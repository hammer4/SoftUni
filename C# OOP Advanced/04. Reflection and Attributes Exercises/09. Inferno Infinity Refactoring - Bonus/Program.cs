using System;

class Program
{
    static void Main(string[] args)
    {
        var repository = new WeaponRepository();
        var interpreter = new CommandInterpreter();
        var weaponFactory = new WeaponFactory();
        var gemFactory = new GemFactory();
        var reader = new Reader();
        var writer = new Writer();

        IRunnable engine = new Engine(gemFactory, weaponFactory, interpreter, repository, reader, writer);

        engine.Run();
    }
}