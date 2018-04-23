namespace FestivalManager.Core.Contracts
{
	public interface IEngine
	{
		void Run();

		string ProcessCommand(string input);
	}
}