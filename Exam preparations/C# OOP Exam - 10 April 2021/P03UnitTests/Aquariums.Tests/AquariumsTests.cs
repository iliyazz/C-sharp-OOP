namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    public class AquariumsTests
    {
        [Test]
        public void ConstructorShouldCreateAquariumCorrectly()
        {
            Aquarium aquarium = new Aquarium("name1", 20);

            Assert.AreEqual("name1", aquarium.Name);
            Assert.AreEqual(20, aquarium.Capacity);
        }

        [Test]
        public void ConstructorShouldInitializeCollectionCorrectly()
        {
            Fish fish1 = new Fish("name1");
            Fish fish2 = new Fish("name2");
            Aquarium aquarium = new Aquarium("name1", 20);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Assert.AreEqual(2, aquarium.Count);
        }


        [TestCase(null)]
        [TestCase("")]
        public void NameShouldReturnExceptionIfIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 20);
            }, "Invalid aquarium name!");
        }

        [TestCase(-5)]
        [TestCase(-1)]
        public void CapacityShouldReturnExceptionIfLessThanZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("name1", capacity);
            }, "Invalid aquarium capacity!");
        }

        [Test]
        public void AddShouldThrowEsceptionIfAquariumIsFull()
        {
            Aquarium aquarium = new Aquarium("1", 2);
            Fish fish1 = new Fish("name1");
            Fish fish2 = new Fish("name2");
            Fish fish3 = new Fish("name3");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish3);
            }, "Aquarium is full!");
        }

        [Test]
        public void RemoveFishShouldThrowExceptionIfFishDoesNotExist()
        {
            Aquarium aquarium = new Aquarium("1", 2);
            Fish fish1 = new Fish("name1");
            Fish fish2 = new Fish("name2");
            string nonExistinname = "name3";
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish(nonExistinname);
            }, $"Fish with the name {nonExistinname} doesn't exist!");
        }

        [Test]
        public void RemoveFishShouldRemoveCorrectly()
        {
            Aquarium aquarium = new Aquarium("1", 20);
            Fish fish1 = new Fish("name1");
            Fish fish2 = new Fish("name2");
            Fish fish3 = new Fish("name2");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.RemoveFish(fish3.Name);
            int expectedCount = 2;
            int actualCount = aquarium.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void SellFishShouldThrowExceptionIfFishDoesNotExist()
        {
            Aquarium aquarium = new Aquarium("1", 20);
            Fish fish1 = new Fish("name1");
            Fish fish2 = new Fish("name2");
            string nonExistinname = "name3";
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish(nonExistinname);
            }, $"Fish with the name {nonExistinname} doesn't exist!");
        }

        [Test]
        public void SellFishShouldReturnFishAndChangeAvailability()
        {
            Aquarium aquarium = new Aquarium("1", 20);
            Fish fish1 = new Fish("name1");
            Fish fish2 = new Fish("name2");
            Fish fish3 = new Fish("name3");
            fish1.Available = true;
            fish2.Available = true;
            fish3.Available = true;
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            bool expectedAvailableValue = false;
            aquarium.SellFish("name2");
            bool actualAvailableValue = fish2.Available;
            Assert.AreEqual(expectedAvailableValue, actualAvailableValue);
            Assert.AreSame(fish1, aquarium.SellFish("name1"));
        }


        [Test]
        public void reportShouldReturnCorrectString()
        {
            Aquarium aquarium = new Aquarium("test", 20);
            Fish fish1 = new Fish("name1");
            Fish fish2 = new Fish("name2");
            Fish fish3 = new Fish("name3");
            fish1.Available = false;
            fish2.Available = true;
            fish3.Available = true;
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            string actualReport = aquarium.Report();
            string expectedReport = $"Fish available at {aquarium.Name}: name1, name2, name3";
            Assert.AreEqual(expectedReport, actualReport);
        }
    }
}
