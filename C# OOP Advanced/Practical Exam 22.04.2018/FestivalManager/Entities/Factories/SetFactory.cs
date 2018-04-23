using System;

using System.Linq;
using System.Reflection;





namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type typeClass = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            ISet instance = (ISet)Activator.CreateInstance(typeClass, name);

            return instance;
        }
	}




}
