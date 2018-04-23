namespace FestivalManager.Core.Controllers
{
	using System.Text;
	using System.Linq;

	using Contracts;
	using Entities.Contracts;

	public class SetController : ISetController
	{
		private readonly IStage stage;

		public SetController(IStage stage)
		{
			this.stage = stage;
		}

		public string PerformSets()
		{
			var sb = new StringBuilder();

			var setCount = 1;

			var sortedSets = this.stage.Sets
				.OrderByDescending(s => s.ActualDuration)
				.ThenByDescending(s => s.Performers.Count)
				.ToArray();

			foreach (var set in sortedSets)
			{
				sb.AppendLine($"{setCount++}. {set.Name}:");

				var setWasSuccessful = set.CanPerform();

				if (!setWasSuccessful)
				{
					sb.AppendLine("-- Did not perform");
					continue;
				}

				var songCount = 1;
				foreach (var song in set.Songs)
				{
					sb.AppendLine($"-- {songCount++}. {song}");

					foreach (var performer in set.Performers)
					{
						foreach (var instrument in performer.Instruments)
						{
							instrument.WearDown();
						}
					}
				}

				sb.AppendLine("-- Set Successful");
			}

			return sb.ToString().TrimEnd('\r', '\n');
		}
	}
}
