using NUnit.Framework;

namespace TheRace.Tests
{
    using System;

    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CunstructorShouldCreateObjecCirrectly()
        {
            UnitCar car1 = new UnitCar("model1,", 101, 2345.6);
            UnitDriver driver1 = new UnitDriver("name1", car1);
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(driver1);
            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void AddDriverShouldThrowExceptionIfDriverIsNull()
        {
            UnitCar car1 = new UnitCar("model1,", 101, 2345.6);
            //UnitDriver driver1 = new UnitDriver("name1", car1);
            UnitDriver driver1 = null;
            RaceEntry raceEntry = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddDriver(driver1);
            }, "Driver cannot be null.");
        }

        [Test]
        public void AddDriverShouldThrowExceptionIfDriverNameExistInCollection()
        {
            UnitCar car1 = new UnitCar("model1,", 101, 2345.6);
            UnitCar car2 = new UnitCar("model2,", 111, 2545.6);
            UnitDriver driver1 = new UnitDriver("name1", car1);
            UnitDriver driver2 = new UnitDriver("name1", car2);
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(driver1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddDriver(driver2);
            }, "Driver name1 is already added.");
        }

        [Test]
        public void AddDriverShouldReturnCorrectString()
        {
            UnitCar car1 = new UnitCar("model1,", 101, 2345.6);
            UnitDriver driver1 = new UnitDriver("name1", car1);
            RaceEntry raceEntry = new RaceEntry();
            string expectedString = "Driver name1 added in race.";
            string actualString = raceEntry.AddDriver(driver1);
            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowExceptionIfParticipantArLessThanMinimumCount()
        {
            UnitCar car1 = new UnitCar("model1,", 101, 2345.6);
            UnitDriver driver1 = new UnitDriver("name1", car1);
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(driver1);
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerShouldReturnCorrectResultt()
        {
            UnitCar car1 = new UnitCar("model1,", 101, 2145.5);
            UnitCar car2 = new UnitCar("model2,", 111, 2245.2);
            UnitCar car3 = new UnitCar("model3,", 121, 2345.6);
            UnitDriver driver1 = new UnitDriver("name1", car1);
            UnitDriver driver2 = new UnitDriver("name2", car2);
            UnitDriver driver3 = new UnitDriver("name3", car3);
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(driver1);
            raceEntry.AddDriver(driver2);
            raceEntry.AddDriver(driver3);
            double expectedResult = (car1.HorsePower + car2.HorsePower + car3.HorsePower) / raceEntry.Counter;
            double actualresult = raceEntry.CalculateAverageHorsePower();
            Assert.AreEqual(expectedResult, actualresult);


        }


    }
}