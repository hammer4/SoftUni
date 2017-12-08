namespace TeamBuilder.App
{
    using System;
    using TeamBuilder.App.Core;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;

    public class Application
    {
        public static void Main()
        {
            DbTools.ResetDb();

            Engine engine = new Engine(new CommandDispatcher());
            engine.Run();
        }
    }
}
