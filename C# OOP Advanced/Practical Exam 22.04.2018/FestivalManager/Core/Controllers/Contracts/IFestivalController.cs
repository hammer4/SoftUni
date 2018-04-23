namespace FestivalManager.Core.Controllers.Contracts
{
	public interface IFestivalController
	{
		string ProduceReport();

		string RegisterSet(string[] args);

		string SignUpPerformer(string[] args);

		string RegisterSong(string[] args);

		string AddSongToSet(string[] args);

		string AddPerformerToSet(string[] args);

		string RepairInstruments(string[] args);
	}
}