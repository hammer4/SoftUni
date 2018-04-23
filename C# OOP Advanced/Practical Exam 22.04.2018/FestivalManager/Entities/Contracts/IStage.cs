namespace FestivalManager.Entities.Contracts
{
	using System.Collections.Generic;

	public interface IStage
	{
		IReadOnlyCollection<ISet> Sets { get; }

		IReadOnlyCollection<ISong> Songs { get; }

		IReadOnlyCollection<IPerformer> Performers { get; }

		IPerformer GetPerformer(string name);

		ISong GetSong(string name);

		ISet GetSet(string name);

		void AddPerformer(IPerformer performer);

		void AddSong(ISong song);

		void AddSet(ISet performer);

		bool HasPerformer(string name);

		bool HasSong(string name);

		bool HasSet(string name);
	}
}