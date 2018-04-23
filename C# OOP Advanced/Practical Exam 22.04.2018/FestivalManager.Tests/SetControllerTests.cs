// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    //using FestivalManager.Core.Controllers;
    //using FestivalManager.Core.Controllers.Contracts;
    //using FestivalManager.Entities;
    //using FestivalManager.Entities.Contracts;
    //using FestivalManager.Entities.Instruments;
    //using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class SetControllerTests
    {
        private IStage stage;
        private ISetController setController;

        [SetUp]
        public void TestInit()
        {
            this.stage = new Stage();
            this.setController = new SetController(stage);
        }

		[Test]
	    public void PerformSetsShoulPerform()
	    {
            var set1 = new Short("Set1");
            var set2 = new Medium("Set2");

            var ivan = new Performer("Ivan", 20);
            ivan.AddInstrument(new Guitar());
            var gosho = new Performer("Gosho", 24);
            gosho.AddInstrument(new Drums());
            var pesho = new Performer("Pesho", 19);
            pesho.AddInstrument(new Guitar());
            pesho.AddInstrument(new Microphone());

            Song song1 = new Song("Song1", new TimeSpan(0, 1, 2));

            set1.AddSong(song1);
            set1.AddPerformer(gosho);
            set1.AddPerformer(pesho);

            stage.AddSet(set1);
            stage.AddSet(set2);

            var expected = @"1. Set1:
-- 1. Song1 (01:02)
-- Set Successful
2. Set2:
-- Did not perform";

            var actual = setController.PerformSets();

            Assert.That(expected, Is.EqualTo(actual));
            Assert.That(pesho.Instruments.First().Wear, Is.EqualTo(40));
        }
	}
}