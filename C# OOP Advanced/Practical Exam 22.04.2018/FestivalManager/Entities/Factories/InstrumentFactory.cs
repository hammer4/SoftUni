namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Entities.Contracts;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            Type typeClass = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            IInstrument instance = (IInstrument)Activator.CreateInstance(typeClass);

            return instance;
        }
	}
}