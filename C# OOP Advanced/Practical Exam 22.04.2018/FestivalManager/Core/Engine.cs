
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using IO.Contracts;

	/// <summary>
	/// by g0shk0
	/// </summary>
	public class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;
        private IStage stage;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.stage = new Stage();
            this.festivalCоntroller = new FestivalController(this.stage, new SetFactory(), new InstrumentFactory(), new PerformerFactory());
            this.setCоntroller = new SetController(this.stage);

        }

		// дайгаз
		public void Run()
		{
			while (true) // for job security
			{
				var input = reader.ReadLine();

				if (input == "END")
					break;

                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            writer.WriteLine(this.festivalCоntroller.ProduceReport());
		}

		public string ProcessCommand(string input)
		{
			var tokens = input.Split();

			var commandName = tokens.First();
			var args = tokens.Skip(1).ToArray();

            switch (commandName)
            {
                case "RegisterSet":
                    return this.festivalCоntroller.RegisterSet(args);
                case "SignUpPerformer":
                    return this.festivalCоntroller.SignUpPerformer(args);
                case "RegisterSong":
                    return this.festivalCоntroller.RegisterSong(args);
                case "AddSongToSet":
                    return this.festivalCоntroller.AddSongToSet(args);
                case "AddPerformerToSet":
                    return this.festivalCоntroller.AddPerformerToSet(args);
                case "RepairInstruments":
                    return this.festivalCоntroller.RepairInstruments(args);
                case "LetsRock":
                    return this.setCоntroller.PerformSets();
                default:
                    throw new NotImplementedException();
            }
		}
    }
}