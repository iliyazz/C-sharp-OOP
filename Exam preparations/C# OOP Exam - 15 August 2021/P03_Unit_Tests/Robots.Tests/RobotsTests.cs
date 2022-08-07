namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    public class RobotsTests
    {
        [Test]
        public void CapacityShouldThrowExceptionIfValeuIsLessThanZero()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                var robotManager = new RobotManager(-1);
            }, "Invalid capacity!");
        }

        [Test]
        public void CapacityShouldReturnCorrectCapacity()
        {
            var robotManager = new RobotManager(5);

            int expectedCapacity = 5;
            int actualCapacity = robotManager.Capacity;
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void CountShouldReturnCorrectValue()
        {
            var robotManager = new RobotManager(5);
            Robot robot1 = new Robot("name1", 1000);
            Robot robot2 = new Robot("name2", 1500);
            Robot robot3 = new Robot("name3", 2000);
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Add(robot3);
            int expectedCount = 3;
            int actualCounty = robotManager.Count;
            Assert.AreEqual(expectedCount, actualCounty);
        }

        [Test]
        public void AddShouldThrowExceptionRobotNameExist()
        {
            var robotManager = new RobotManager(5);
            Robot robot1 = new Robot("name1", 1000);
            Robot robot2 = new Robot("name2", 1500);
            Robot robot3 = new Robot("name3", 2000);
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Add(robot3);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot2);
            }, $"There is already a robot with name {robot2.Name}!");
        }

        [Test]
        public void AddShouldThrowExceptionIfNotEnoughCapacity()
        {
            var robotManager = new RobotManager(2);
            Robot robot1 = new Robot("name1", 1000);
            Robot robot2 = new Robot("name2", 1500);
            Robot robot3 = new Robot("name3", 2000);
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot3);
            }, "Not enough capacity!");
        }

        [Test]
        public void RemoveShouldThrowExceptionRobotNametDoesNotExist()
        {
            var robotManager = new RobotManager(5);
            Robot robot1 = new Robot("name1", 1000);
            Robot robot2 = new Robot("name2", 1500);
            Robot robot3 = new Robot("name3", 2000);
            robotManager.Add(robot1);
            robotManager.Add(robot3);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("name2");
            }, $"Robot with the name {robot2.Name} doesn't exist!");
        }

        [Test]
        public void RemoveShouldRemoveRobotFromCollection()
        {
            var robotManager = new RobotManager(5);
            Robot robot1 = new Robot("name1", 1000);
            Robot robot2 = new Robot("name2", 1500);
            Robot robot3 = new Robot("name3", 2000);
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Add(robot3);
            robotManager.Remove("name2");
            int expectedCount = 2;
            int actualCounty = robotManager.Count;
            Assert.AreEqual(expectedCount, actualCounty);
        }

        [Test]
        public void WorkShouldThrowExceptionIfRobotNameDoesNotExist()
        {
            var robotManager = new RobotManager(5);
            Robot robot1 = new Robot("name1", 1000);
            Robot robot2 = new Robot("name2", 1500);
            Robot robot3 = new Robot("name3", 2000);
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Add(robot3);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("NonExistingName", "hardWork", 2300);
            }, "Robot with the name NonExistingName doesn't exist!");
        }

        [Test]
        public void WorkShouldThrowExceptionIfBatteryUssageIsLessThanBattery()
        {
            var robotManager = new RobotManager(5);
            Robot robot1 = new Robot("name1", 1000);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(robot1.Name, "hardWork", 2300);
            }, $"{robot1.Name} doesn't have enough battery!");
        }

        [Test]
        public void WorkShouldReduceBattery()
        {
            var robotManager = new RobotManager(5);
            Robot robot1 = new Robot("name1", 5000);
            robotManager.Add(robot1);
            int expectedBattery = 2000;
            robotManager.Work(robot1.Name, "hardWork", 3000);
            int actualBattery = robot1.Battery;
            Assert.AreEqual(expectedBattery, actualBattery);
        }

        [Test]
        public void ChargeShoudThrowExceptionIfRobotnameDoesNotexist()
        {
            var robotManager = new RobotManager(5);
            Robot robot1 = new Robot("name1", 1000);
            Robot robot2 = new Robot("name2", 1500);
            Robot robot3 = new Robot("name3", 2000);
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge(robot3.Name);
            }, $"Robot with the name {robot3.Name} doesn't exist!");
        }

        [Test]
        public void ChargeShoudChargeBatteryToFullCapacity()
        {
            var robotManager = new RobotManager(5);
            Robot robot1 = new Robot("name1", 5000);
            robotManager.Add(robot1);
            int expectedBattery = 2000;
            robotManager.Work(robot1.Name, "hardWork", 3000);
            int actualBattery = robot1.Battery;
            Assert.AreEqual(expectedBattery, actualBattery);
            robotManager.Charge(robot1.Name);
            Assert.AreEqual(5000, robot1.Battery);
        }





    }
}
