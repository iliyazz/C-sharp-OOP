namespace Presents.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void CreateShouldThrowExceptionIfPresentIsNull()
        {
            Bag bag = new Bag();
            Present present = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            }, "Present is null");

        }

        [Test]
        public void CreateShouldThrowExceptionIfPresentExistInCollection()
        {
            Bag bag = new Bag(){};
            Present present1 = new Present("name1", 1.13);
            bag.Create(present1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present1);
            }, "This present already exists!");
        }

        [Test]
        public void CreateShouldReturnCorrectStringIsAddIsSuccessful()
        {
            Bag bag = new Bag() { };
            Present present1 = new Present("name1", 1.13);
            string expectedString = $"Successfully added present {present1.Name}.";
            string actualString = bag.Create(present1);
            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void RemoveShouldReturnCorrectValue()
        {
            Bag bag = new Bag() { };
            Present present1 = new Present("name1", 1.13);
            Present present2 = new Present("name2", 2.13);
            bag.Create(present1);
            bag.Create(present2);
            Assert.IsTrue(bag.Remove(present1));
            Assert.IsFalse(bag.Remove(present1));
        }

        [Test]
        public void GetPresentWithLeastMagicShouldReturnCorrectPresent()
        {
            Bag bag = new Bag() { };
            Present present1 = new Present("name1", 5.13);
            Present present2 = new Present("name2", 2.13);
            Present present3 = new Present("name3", 12.13);
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);
            Assert.AreSame(present2, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void GetPresentShouldReturnCorrectPresent()
        {
            Bag bag = new Bag() { };
            Present present1 = new Present("name1", 5.13);
            Present present2 = new Present("name2", 2.13);
            Present present3 = new Present("name3", 12.13);
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);
            Assert.AreSame(present1, bag.GetPresent("name1"));
        }

        [Test]
        public void GetPresentsShouldReturnCorrectCollection()
        {
            Bag bag = new Bag() { };
            Present present1 = new Present("name1", 5.13);
            Present present2 = new Present("name2", 2.13);
            Present present3 = new Present("name3", 12.13);
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);
            List<Present> expectedPresents = new List<Present>();
            expectedPresents.Add(present1);
            expectedPresents.Add(present2);
            expectedPresents.Add(present3);
            CollectionAssert.AreEqual((IReadOnlyCollection<Present>)expectedPresents, bag.GetPresents());
        }






    }
}
