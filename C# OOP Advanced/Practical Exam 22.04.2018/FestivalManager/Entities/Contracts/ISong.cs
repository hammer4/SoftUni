namespace FestivalManager.Entities.Contracts
{
	using System;

	public interface ISong
	{
		string Name { get; }

		TimeSpan Duration { get; }
	}
}