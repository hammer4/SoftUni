namespace FestivalManager.Entities.Factories.Contracts
{
	using Entities.Contracts;

	public interface IInstrumentFactory
	{
		IInstrument CreateInstrument(string type);
	}
}