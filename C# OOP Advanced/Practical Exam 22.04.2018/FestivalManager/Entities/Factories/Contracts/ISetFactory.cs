namespace FestivalManager.Entities.Factories.Contracts
{
	using System;
	using System.Linq;
	using Entities.Contracts;

	public interface ISetFactory
	{
		ISet CreateSet(string name, string type);
	}
}
