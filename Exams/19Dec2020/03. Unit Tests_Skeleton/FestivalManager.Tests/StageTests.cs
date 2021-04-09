// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;
        private Performer performer;
        private Song song;
        [SetUp]
        public void SetUp()
        {
            stage = new Stage();
            performer = new Performer("Spasina", "Spasova", 21);
            song = new Song("California", new TimeSpan(0, 3, 30));
            //h, m, s
        }
        [Test]
        public void AddPerformerThrowsWhenPerformarIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
        }
        [Test]
        public void AddPerformerThrowsWhenPerformarIsLessThan18()
        {
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("s", "s", 16)));
        }
        [Test]
        public void AddPerformerWorksCorrectly()
        {
            stage.AddPerformer(performer);
            Assert.That(stage.Performers.Count, Is.EqualTo(1));
        }
        [Test]
        public void AddSongThrowsWhenSongIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
        }
        [Test]
        public void AddSongThrowsWhenSongMinutesLessThan1()
        {
            Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("v", new TimeSpan(0, 0, 1))));
        }
        [Test]
        public void AddSongToPerformerFirstThrow()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "pipi"));
        }
        [Test]
        public void AddSongToPerformerSecondThrow()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("California", null));
        }
        [Test]
        public void AddSongToPerformerPerformerAddSong()
        {
            performer.SongList.Add(song);
            Assert.That(performer.SongList.Count, Is.EqualTo(1));
        }
        [Test]
        public void AddSongToPerformerMessages()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            string result = stage.AddSongToPerformer("California", "Spasina Spasova");
            string expected = $"California (03:30) will be performed by Spasina Spasova";
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void AddSongToPerformerThrowsFindPerformance()
        {
            stage.AddSong(song);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("California", "Spasina Spasova"));
        }
        [Test]
        public void AddSongToPerformerThrowsFindSong()
        {
            stage.AddPerformer(performer);

            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("California", "Spasina Spasova"));
        }
        [Test]
        public void PlayWorks()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);
            performer.SongList.Add(song);
            stage.AddSongToPerformer("California", "Spasina Spasova");
            string result = stage.Play();
            string expected = $"{this.stage.Performers.Count} performers played {performer.SongList.Count} songs";
            Assert.AreEqual(result, expected);

        }
    }
}