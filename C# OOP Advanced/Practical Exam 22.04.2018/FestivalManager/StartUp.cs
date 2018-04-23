namespace FestivalManager
{
	using Core;
	using Core.Contracts;
	using Core.IO;
	using Core.IO.Contracts;

	public class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);

			engine.Run();
		}
	}
}