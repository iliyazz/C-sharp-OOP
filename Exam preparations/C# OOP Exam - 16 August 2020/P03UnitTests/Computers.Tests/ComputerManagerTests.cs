using NUnit.Framework;

namespace Computers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitialiseCollection()
        {
            Computer computer = new Computer("manufacturer1", "model1", 1000.0m);
            ComputerManager manager = new ComputerManager();
            Assert.AreEqual(0, manager.Count);
            manager.AddComputer(computer);
            Assert.AreEqual(1, manager.Count);
            //Assert.AreEqual(1, manager.Computers.Count);
        }

        [Test]
        public void ComputersPropertyShouldBeReadOnly()
        {
            Type type = typeof(ComputerManager);
            PropertyInfo propertyInfo = type.GetProperty("Computers");
            Assert.That(propertyInfo.CanWrite == false);
        }


        [Test]
        public void AddComputerShouldThrowExceptionIfComputerAlreadyExist()
        {
            Computer computer1 = new Computer("manufacturer1", "model1", 1000.0m);
            Computer computer2 = new Computer("manufacturer1", "model1", 1500.0m);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(computer1);
            Assert.Throws<ArgumentException>(() =>
            {
                manager.AddComputer(computer2);
            }, "This computer already exists.");
        }

        [Test]
        public void RemoveComputerShouldReturnCorrectValue()
        {
            Computer computer1 = new Computer("manufacturer1", "model1", 1000.0m);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(computer1);
            Assert.AreEqual(computer1, manager.RemoveComputer("manufacturer1", "model1"));
        }

        [Test]
        public void RemoveComputerShouldWorkProperly()
        {
            Computer computer1 = new Computer("manufacturer1", "model1", 1000.0m);
            Computer computer2 = new Computer("manufacturer2", "model2", 1500.0m);
            Computer computer3 = new Computer("manufacturer3", "model3", 1600.0m);
            Computer computer4 = new Computer("manufacturer4", "model4", 1700.0m);
            Computer computer5 = new Computer("manufacturer5", "model5", 1800.0m);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);
            manager.AddComputer(computer3);
            manager.AddComputer(computer4);
            manager.AddComputer(computer5);
            Assert.AreEqual(5, manager.Count);
            manager.RemoveComputer("manufacturer4", "model4");
            manager.RemoveComputer("manufacturer2", "model2");
            Assert.AreEqual(3, manager.Count);

        }

        [Test]
        public void GetComputerShouldThrowExceptionIfComputerDoesNotExistInCollection()
        {
            Computer computer1 = new Computer("manufacturer1", "model1", 1000.0m);
            //Computer computer2 = new Computer("manufacturer2", "model2", 1500.0m);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(computer1);
            Assert.Throws<ArgumentException>(() =>
            {
                manager.GetComputer("manufacturer2", "model2");
            },"There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerShouldReturnCorrectValue()
        {
            Computer computer1 = new Computer("manufacturer1", "model1", 1000.0m);
            Computer computer2 = new Computer("manufacturer2", "model2", 1500.0m);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);
            Assert.AreEqual(computer1, manager.GetComputer("manufacturer1", "model1"));
        }

        [Test]
        public void GetComputersByManufacturerShouldReturnCorrectValue()
        {
            Computer computer1 = new Computer("manufacturer1", "model1", 1000.0m);
            Computer computer2 = new Computer("manufacturer2", "model2", 1500.0m);
            Computer computer3 = new Computer("manufacturer1", "model3", 1600.0m);
            Computer computer4 = new Computer("manufacturer2", "model4", 1700.0m);
            Computer computer5 = new Computer("manufacturer1", "model5", 1800.0m);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);
            manager.AddComputer(computer3);
            manager.AddComputer(computer4);
            manager.AddComputer(computer5);
            List<Computer> expectedList = new List<Computer> { computer1, computer3, computer5 };
            CollectionAssert.AreEqual(expectedList, manager.GetComputersByManufacturer("manufacturer1"));
        }

        [Test]
        public void ValidateNullValueShouldWurkCorrectly()
        {
            Computer computer1 = new Computer("manufacturer1", "model1", 1000.0m);
            Computer computer2 = new Computer("manufacturer2", "model2", 1500.0m);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);
            Assert.Throws<ArgumentNullException>(() => manager.RemoveComputer(null, null));
            Assert.That(() => manager.AddComputer(null), Throws.ArgumentNullException.With.Message.EqualTo("Can not be null! (Parameter 'computer')"));
        }
    }
}