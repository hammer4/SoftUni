namespace FestivalManager.Core.IO.Contracts
{
	public interface IWriter
	{
		void WriteLine(string contents);

		void Write(string contents);
	}
}