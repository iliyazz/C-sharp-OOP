namespace Gyms.Tests
{
    using System;
    using System.Text;
    using NUnit.Framework;

    public class GymsTests
    {
        // Implement unit tests here


        [Test]
        public void CreateGymByConstructor()
        {
            //Arrange
            Gym gym1 = new Gym("gym1", 20);
            Gym gym2 = new Gym("gym2", 0);
            //Act
            string expectedNameGym1 = "gym1";
            int expectedSizeGym1 = 20;
            string expectedNameGym2 = "gym2";
            int expectedSizeGym2 = 0;

            string actualNameGym1 = gym1.Name;
            int actualSizeGym1 = gym1.Capacity;
            string actualNameGym2 = gym2.Name;
            int actualSizeGym2 = gym2.Capacity;


            //Assert
            Assert.AreEqual(expectedNameGym1, actualNameGym1, "Gym constructor should initialize field \"name\" correctly.");
            Assert.AreEqual(expectedSizeGym1, actualSizeGym1, "Gym constructor should initialize field \"size\" correctly.");
            Assert.AreEqual(expectedNameGym2, actualNameGym2, "Gym constructor should initialize field \"name\" correctly.");
            Assert.AreEqual(expectedSizeGym2, actualSizeGym2, "Gym constructor should initialize field \"size\" correctly.");
            Assert.IsNotNull(gym1, "Gym constructor should create gym.");
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameCanNotBeNullOrEmpty(string name)
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 20);
            }, "Invalid gym name.");
        }

        [TestCase(-10)]
        [TestCase(-1)]
        public void SizeCapacityCanNotBeNegative(int size)
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("gym1", size);
            }, "Invalid gym capacity.");
        }

        [Test]
        public void CountShouldHaveCorretValueOfAthletes()
        {
            //Arrange
            Gym gym = new Gym("gym1", 20);
            Athlete athlete1 = new Athlete("nameOfAthlete1");
            //Act
            int expectedZeroCount = 0;
            int actualZeroCount = gym.Count;
            gym.AddAthlete(athlete1);
            int expectedCount2 = 1;
            int actualCount2 = gym.Count;
            //Assert
            Assert.AreEqual(expectedZeroCount, actualZeroCount, "Count must work correctly");
            Assert.AreEqual(expectedCount2, actualCount2, "Count must work correctly");
        }

        [Test]
        public void AddAthleteShouldThrowExceptionIfGymIsFull()
        {
            //Arrange
            int gymCapacity = 13;
            Gym gym = new Gym("gym1", gymCapacity);
            for (int i = 0; i < gymCapacity; i++)
            {
                var sb = new StringBuilder();
                sb.Append($"athlete{i}");
                Athlete athlete = new Athlete(sb.ToString());
                gym.AddAthlete(athlete);
            }
            Athlete athleteToIOEx = new Athlete("NameOfAthlete");
            //Act, Assert
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athleteToIOEx), "The gym is full.");
        }

        [Test]
        public void RemoveAthleteShouldThrowExceptionAthleteDoesNotExist()
        {
            //Arrange
            int gymCapacity = 13;
            Gym gym = new Gym("gym1", gymCapacity);
            Athlete athlete1 = new Athlete("Athlete1Name");
            Athlete athlete2 = new Athlete("Athlete2Name");
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            Athlete athlete3 = new Athlete("Athlete3Name");
            //Act, Assert
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete(athlete3.FullName), $"The athlete {athlete3.FullName} doesn't exist.");
        }

        [Test]
        public void RemoveAthleteShouldSuccessfullyRemoveAthletIfExist()
        {
            //Arrange
            int gymCapacity = 13;
            Gym gym = new Gym("gym1", gymCapacity);
            Athlete athlete1 = new Athlete("Athlete1Name");
            Athlete athlete2 = new Athlete("Athlete2Name");
            Athlete athlete3 = new Athlete("Athlete3Name");
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            gym.RemoveAthlete(athlete2.FullName);
            int expectedCount = 2;
            int actualCount = gym.Count;
            
            //Act, Assert
            Assert.AreEqual(expectedCount, actualCount, "RemoveAthlete must successfully remove Athlete.");
        }

        [Test]
        public void InjureAthleteShouldThrowExceptionIfAthletIsNull()
        {
            //Arrange
            int gymCapacity = 13;
            Gym gym = new Gym("gym1", gymCapacity);
            Athlete athlete1 = new Athlete("Athlete1Name");
            Athlete athlete2 = new Athlete("Athlete2Name");
            Athlete athlete3 = new Athlete("Athlete3Name");
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            //Act, Assert
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete(athlete3.FullName),
                $"The athlete {athlete3.FullName} doesn't exist.");
        }

        [Test]
        public void InjureAthleteShouldReturnAthleteIfExist()
        {
            //Arrange
            int gymCapacity = 13;
            Gym gym = new Gym("gym1", gymCapacity);
            Athlete athlete1 = new Athlete("Athlete1Name");
            Athlete athlete2 = new Athlete("Athlete2Name");
            Athlete athlete3 = new Athlete("Athlete3Name");
            athlete1.IsInjured = false;
            athlete2.IsInjured = false;
            athlete3.IsInjured = false;

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            //Act
            Athlete injureAthlete = gym.InjureAthlete(athlete1.FullName);
            bool expectedIsInjured = true;
            bool actualIsInjured = athlete1.IsInjured;
            //Assert
            Assert.AreSame(athlete1, injureAthlete, "InjureAthlete must return correct athlete");
            
            Assert.AreEqual(expectedIsInjured, actualIsInjured, "InjureAthlete should change athlete injure status.");
        }

        [Test]
        public void ReportShouldReturnCorrectString()
        {
            //Arrange

            int gymCapacity = 13;
            Gym gym = new Gym("gym1", gymCapacity);
            Athlete athlete1 = new Athlete("Athlete1Name");
            Athlete athlete2 = new Athlete("Athlete2Name");
            Athlete athlete3 = new Athlete("Athlete3Name");
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            athlete1.IsInjured = false;
            athlete2.IsInjured = true;
            athlete3.IsInjured = false;
            //Act
            string actualReport = gym.Report();
            string expectedReport =
                $"Active athletes at {gym.Name}: {athlete1.FullName}, {athlete3.FullName}";
            //Assert
            Assert.AreEqual(expectedReport, actualReport);

        }
    }
}
