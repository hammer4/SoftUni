namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Linq;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

		private IStage stage;
        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;

		public FestivalController(IStage stage, ISetFactory setFactory, IInstrumentFactory instrumentFactory, IPerformerFactory performerFactory)
		{
			this.stage = stage;
            this.setFactory = setFactory;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
		}

        public FestivalController(IStage stage)
        {
            this.stage = stage;
        }

		public string ProduceReport()
		{
			var result = "Results:" + "\n";

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

			result += ($"Festival length: {FormatTime(totalFestivalLength)}") + "\n";

            foreach (var set in this.stage.Sets)
            {
                result += ($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.ToString().Trim();
		}

        private string FormatTime(TimeSpan totalFestivalLength)
        {
            string result = String.Empty;
            int totalMinutes = 0;

            if(totalFestivalLength.Hours > 0)
            {
                totalMinutes += totalFestivalLength.Hours * 60;
            }

            totalMinutes += totalFestivalLength.Minutes;

            if (totalMinutes < 10)
            {
                result += "0";
            }

            result += $"{totalMinutes}:";

            if (totalFestivalLength.Seconds < 10)
            {
                result += "0";
            }
            result += $"{totalFestivalLength.Seconds}";

            return result;
        }

        public string RegisterSet(string[] args)
		{
            ISet set = this.setFactory.CreateSet(args[0], args[1]);
            this.stage.AddSet(set);

            return $"Registered {set.GetType().Name} set";

        }

		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

			var instrumentsArr = args.Skip(2).ToArray();

			var instruments = instrumentsArr
				.Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			var performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instrument in instruments)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            string name = args[0];
            string[] lengthStr = args[1].Split(":");
            int minutes = int.Parse(lengthStr[0]);
            int seconds = int.Parse(lengthStr[1]);

            TimeSpan timeSpan = new TimeSpan(0, minutes, seconds);
            ISong song = new Song(name, timeSpan);
            stage.AddSong(song);

            return $"Registered song {song}";
		}

		public string AddSongToSet(string[] args)
		{
			var songName = args[0];
			var setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			var set = this.stage.GetSet(setName);
			var song = this.stage.GetSong(songName);

			set.AddSong(song);

			return $"Added {song} to {set.Name}";
		}

		public string AddPerformerToSet(string[] args)
		{
			var performerName = args[0];
			var setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException("Invalid performer provided");
			}

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			var performer = this.stage.GetPerformer(performerName);
			var set = this.stage.GetSet(setName);

			set.AddPerformer(performer);

			return $"Added {performer.Name} to {set.Name}";
		}

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}
    }
}