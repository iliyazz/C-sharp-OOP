using NUnit.Framework;

namespace RepairShop.Tests
{
    using System;

    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void ConstructorShouldInitializeGarageCorrectly()
            {
                string garageName = "name1";
                int mechanicsAvailable = 5;
                Garage garage = new Garage(garageName, mechanicsAvailable);
                Assert.IsNotNull(garage, "garage should not be null");
                Assert.AreEqual(garageName, garage.Name, "The name must be correct.");
                Assert.AreEqual(mechanicsAvailable, garage.MechanicsAvailable, "Count of available mechanic must be correct.");
            }

            [TestCase(null)]
            [TestCase("")]
            public void NameShouldThrowExceptionIfStringIsNullOrEmpty(string name)
            {
                Garage garage = null;
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, 25);
                }, "Name can not be null or empty");
            }

            [TestCase(-1)]
            [TestCase(0)]
            public void AvailableMechanicsShouldThrowExceptionIfTheyAreLessThan1(int mechanicsAvailable)
            {
                Garage garage = null;
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("name1", mechanicsAvailable);
                }, "At least one mechanic must work in the garage.");
            }

            [Test]
            public void CarsInGarageShouldReturnCorrectCount()//checj also and AddCar()
            {
                Garage garage = new Garage("garageName", 20);
                Car car1 = new Car("model1", 2);
                Car car2 = new Car("model2", 3);
                garage.AddCar(car1);
                garage.AddCar(car2);
                int expectedCount = 2;
                int availableCount = garage.CarsInGarage;
                Assert.AreEqual(expectedCount, availableCount, "Cars in garage must return correct count.");
            }

            [Test]
            public void CarsInGarageShouldThrowExceptionIfCarsAreEqualToMechanicsAvailable()
            {
                Garage garage = new Garage("garageName", 2);
                Car car1 = new Car("model1", 2);
                Car car2 = new Car("model2", 3);
                Car car3 = new Car("model3", 4);
                garage.AddCar(car1);
                garage.AddCar(car2);
                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car3), "No mechanic available.");
            }

            [Test]
            public void FixCarShouldThrowExceptionIfCarDoesNotExist()
            {
                Garage garage = new Garage("garageName", 15);
                Car car1 = new Car("model1", 2);
                Car car2 = new Car("model2", 3);
                Car car3 = new Car("model3", 4);
                garage.AddCar(car1);
                garage.AddCar(car2);
                Assert.Throws<InvalidOperationException>(() => garage.FixCar(car3.CarModel),
                    $"The car {car3.CarModel} doesn't exist.");
            }

            [TestCase(1)]
            [TestCase(5)]
            public void FixCarShouldReturnCorrectNumberOfIssue(int numberOfIssues)
            {
                Garage garage = new Garage("garageName", 15);
                Car car1 = new Car("model1", numberOfIssues);
                garage.AddCar(car1);
                garage.FixCar(car1.CarModel);
                int expectedNumberOfIssues = 0;
                int actualNumberOfIssue = car1.NumberOfIssues;
                Assert.AreEqual(expectedNumberOfIssues, actualNumberOfIssue, "FixCar must return car with zero issue.");
            }

            [Test]
            public void RemoveFixedCarShouldReturnCorrectCountOfFixedCars()
            {
                Garage garage = new Garage("garageName", 15);
                Car car1 = new Car("model1", 1);
                Car car2 = new Car("model2", 3);
                Car car3 = new Car("model3", 4);
                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);
                garage.FixCar(car1.CarModel);
                garage.FixCar(car2.CarModel);
                int expectedCountOfFixedcar = 2;
                int actualCountOfFixedcar = garage.RemoveFixedCar();
                Assert.AreEqual(expectedCountOfFixedcar, actualCountOfFixedcar, "Remove fixed car should return correct count of fixed cars");
            }

            [Test]
            public void RemoveFixedCarShouldThrowExceptionIfFixedcarsAreZero()
            {
                Garage garage = new Garage("garageName", 15);
                Car car1 = new Car("model1", 1);
                Car car2 = new Car("model2", 3);
                Car car3 = new Car("model3", 4);
                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);
                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar(), "No fixed cars available.");
            }

            [Test]
            public void ReportShouldReturnCorrectString()
            {
                Garage garage = new Garage("garageName", 15);
                Car car1 = new Car("model1", 1);
                Car car2 = new Car("model2", 3);
                Car car3 = new Car("model3", 4);
                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);
                string expectedStringReport = "There are 3 which are not fixed: model1, model2, model3.";
                string actualStringreport = garage.Report();
                Assert.AreEqual(expectedStringReport, actualStringreport, "Report() must return correct string.");
            }
        }
    }
}