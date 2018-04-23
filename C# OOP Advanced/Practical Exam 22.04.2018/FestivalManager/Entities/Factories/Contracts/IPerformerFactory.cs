namespace FestivalManager.Entities.Factories.Contracts
{
	using Entities.Contracts;

	public interface IPerformerFactory
	{
		IPerformer CreatePerformer(string name, int age);
	}
}