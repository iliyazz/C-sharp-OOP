// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using Entities;

    [TestFixture]
	public class StageTests
    {
        private Stage stage;

        [SetUp]
        public void Setup()
        {
            stage = new Stage();
        }

		[Test]
	    public void CreateStageByConstructor()
	    {
			Stage stage1 = new Stage();
		}

        [Test]
        public void ValidteNonNullPerformerWhenAddingToStage()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null), "Can not be null!");
        }


        [TestCase("firstName1", "lastName1", 10)]
        [TestCase("firstName1", "lastName1", 17)]
        public void AddPerformerShouldThrowExceptionIfAgeIsLessThan18(string firstname, string lastName, int age)
        {
            //Arrange
            Performer performer = new Performer(firstname, lastName, age);
            //act, Assert
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer),
                "You can only add performers that are at least 18.");
        }


        [Test]
        public void AddPerformerShouldAddPerformerCorrectly()
        {
            //Arrange
            Performer performer1 = new Performer("firstname1", "lastName1", 21);
            Performer performer2 = new Performer("firstname2", "lastName2", 22);
            Performer performer3 = new Performer("firstname3", "lastName3", 23);
            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddPerformer(performer3);
            int actualCount = stage.Performers.Count;
            int expectedCount = 3;
            //act, Assert
            Assert.AreEqual(expectedCount, actualCount, "AddPerformerShouldAddPerformerCorrectly");
        }

        [Test]
        public void AddSongShouldThrowExceptionIfSongIsShorterOrEqual1ThanMinute()
        {
            //Arrange
            Song song = new Song("name1", new TimeSpan(0,0,59));
            //Act, Assert
            Assert.Throws<ArgumentException>(() => stage.AddSong(song),
                "You can only add songs that are longer than 1 minute.");

        }

        [Test]
        public void ValidteNonNullSongWhenAddingSong()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null), "Can not be null!");
        }

        [Test]
        public void AddSongToPerformerWithNullShouldThrowException()
        {
            //Song song1 = new Song("name1", null);
            //Song song2 = new Song(null, new TimeSpan(0, 5, 13));
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "name1"), "Can not be null!");
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("name2", null), "Can not be null!");
        }

        [Test]
        public void AddSongToNonExistingPerformerShouldThrowException()
        {
            Performer performer1 = new Performer("firstname1", "lastName1", 21);
            Song song1 = new Song("song1", new TimeSpan(0, 3, 59));
            stage.AddPerformer(performer1);
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("song1", "NonExistingPerformer"),
                "There is no performer with this name.");
        }

        [Test]
        public void AddNonExistingSongToPerformerShouldThrowException()
        {
            Performer performer1 = new Performer("firstname1", "lastName1", 21);
            //Song song1 = new Song("song1", new TimeSpan(0, 3, 59));
            stage.AddPerformer(performer1);
            Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("NonExistingSong", "firstname1 lastName1"),
                "There is no song with this name.");
        }

        [Test]
        public void AddSongToPerformerShouldAddSongCorrectly()
        {
            Performer performer1 = new Performer("firstname1", "lastName1", 21);
            Song song1 = new Song("song1", new TimeSpan(0, 3, 59));

            stage.AddPerformer(performer1);
            stage.AddSong(song1);

            string expected = $"{song1} will be performed by {performer1}";
            string actual = stage.AddSongToPerformer("song1", "firstname1 lastName1");

            Assert.AreEqual(expected, actual, "String from AddSongToPerformer does not match.");
            Assert.AreEqual(1, performer1.SongList.Count);
        }

        [Test]
        public void PlayShouldReturnCorrectString()
        {
            Performer[] performers = new Performer[]
            {
                new Performer("Firstname1", "LastName1", 20),
                new Performer("Firstname2", "LastName2", 22),
                new Performer("Firstname3", "LastName3", 23)
            };
            foreach (var performer in performers)
            {
                stage.AddPerformer(performer);
            }

            Song[] songs = new Song[]
            {
                new Song("Song1", new TimeSpan(0, 3, 0)),
                new Song("Song2", new TimeSpan(0, 3, 10)),
                new Song("Song3", new TimeSpan(0, 3, 20)),
                new Song("Song4", new TimeSpan(0, 3, 30)),
                new Song("Song5", new TimeSpan(0, 3, 40)),
                new Song("Song6", new TimeSpan(0, 3, 50)),
                new Song("Song7", new TimeSpan(0, 4, 0))
            };
            foreach (var song in songs)
            {
                stage.AddSong(song);
            }

            for (int i = 0; i < performers.Length; i++)
            {
                for (int j = 0; j < songs.Length; j++)
                {
                    stage.AddSongToPerformer(songs[j].Name, performers[i].FullName);
                }
            }

            string expected = "3 performers played 21 songs";
            string actual = stage.Play();
            Assert.AreEqual(expected, actual, "Wxpected string does not match");
        }
    }
}