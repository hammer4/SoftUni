namespace FestivalManager.Entities.Contracts
{
	using System.Collections.Generic;

	public interface IPerformer
	{
		string Name { get; }

		int Age { get; }

		IReadOnlyCollection<IInstrument> Instruments { get; }

		void AddInstrument(IInstrument instrument);
	}
}