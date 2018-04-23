namespace FestivalManager.Entities.Factories.Contracts
{
	using System;
	using Entities.Contracts;

	public interface ISongFactory
	{
		ISong CreateSong(string name, TimeSpan duration);
	}
}