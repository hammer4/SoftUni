namespace FestivalManager.Entities.Contracts
{
	using System;
	using System.Collections.Generic;

	public interface ISet
	{
		string Name { get; }

		TimeSpan MaxDuration { get; }

		TimeSpan ActualDuration { get; }

		IReadOnlyCollection<IPerformer> Performers { get; }

		IReadOnlyCollection<ISong> Songs { get; }

		void AddPerformer(IPerformer performer);

		void AddSong(ISong song);

		bool CanPerform();
	}
}