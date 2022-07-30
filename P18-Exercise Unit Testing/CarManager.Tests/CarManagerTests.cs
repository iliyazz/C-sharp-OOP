namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void CreateCarByConstructorFuelAmountShouldBeZero()
        {
            //Arrange
            Car car = new Car("make1", "model1", 0.75, 53.2);
            //Act
            string actualMake = car.Make;
            string actualModel = car.Model;
            double actualFuelConsumption = car.FuelConsumption;
            double actualFuelCapacity = car.FuelCapacity;
            double actualFuelAmount = car.FuelAmount;
            string expectedMake = "make1";
            string expectedModel = "model1";
            double expectedFuelConsumption = 0.75;
            double expectedFuelCapacity = 53.2;
            double expectedFuelAmount = 0;

            //Assert
            Assert.IsNotNull(car);
            Assert.AreEqual(expectedMake, actualMake, "Database constructor should initialize field \"make1\" correctly");
            Assert.AreEqual(expectedModel, actualModel, "Database constructor should initialize field \"mode\" correctly");
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption, "Database constructor should initialize field \"fuelConsumtion\" correctly");
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity, "Database constructor should initialize field \"fuelCapacity\" correctly");
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount, "Database constructor should initialize field  \"fuelAmount\"correctly");
        }

        [TestCase(null)]
        [TestCase("")]
        public void MakeCanNotBeNullOrEmpty(string make1)
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make1, "model1", 0.75, 53.2);
            }, "Make cannot be null or empty!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void ModelCanNotBeNullOrEmpty(string model1)
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("make1", model1, 0.75, 53.2);
            }, "Model cannot be null or empty!");
        }

        [TestCase(-5.2)]
        [TestCase(-0.0001)]
        [TestCase(0)]
        public void FuelConsumptionCanNotBeZeroOrNegatove(double fuelConsumption)
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("make1", "model1", fuelConsumption, 53.2);
            }, "Fuel consumption cannot be zero or negative!");
        }

        //[TestCase(-60)]
        //[TestCase(-53.3)]
        //[TestCase(-53.201)]
        //[TestCase(-53.2)]
        //public void FuelToRefuuelCanNotBeNegatove(double amount)
        //{
        //    //Arrange
        //    Car car = new Car("make1", "model1", 0.75, 53.2);
        //    //Act, Assert
        //    this.FuelAmount =
        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //       //car.FuelAmount = amount
        //        car.Refuel(amount);
        //    }, "Fuel amount cannot be zero or negative!");
        //}

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(-0.001)]
        [TestCase(0)]
        public void FuelCapacityCanNotBeZeroOrNegatove(double capacity)
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("make1", "model1", 0.75, capacity);
            }, "Fuel amount cannot be negative!");
        }

        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(-0.001)]
        [TestCase(0)]
        public void FuelToRefuelCanNotBeZeroOrNegatove(double fuelToRefuel)
        {
            //Arrange
            Car car = new Car("make1", "model1", 0.75, 53.2);
            //Act, Assert
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            }, "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void RefuelShouldIncreaseFuelAmountByTheCapacity ()
        {
            //Arrange
            Car car1 = new Car("make1", "model1", 0.75, 53.2);
            Car car2 = new Car("make1", "model1", 0.75, 53.2);
            //Act, Assert
            double fuelToRefuel1 = 10;
            double fuelToRefuel2 = 60;
            car1.Refuel(fuelToRefuel1);
            car2.Refuel(fuelToRefuel2);
            Assert.AreEqual(fuelToRefuel1, car1.FuelAmount);
            Assert.AreEqual(53.2, car2.FuelAmount);

        }

        [TestCase(120)]
        [TestCase(101)]
        [TestCase(100.01)]
        public void DriveShouldThrowExceptionIfThereIsntEnoughFuel(double distance)
        {
            //Arrange
            Car car = new Car("make1", "model1", 10, 10);
            car.Refuel(10);
            double NeededFuel = (distance / 100) * car.FuelConsumption;
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            }, "You don't have enough fuel to drive!");
        }

       

        [TestCase(120)]
        public void DriveShouldDecreaseFuelAmount(double distance)
        {
            //Arrange
            Car car = new Car("make1", "model1", 7, 53.2);
            car.Refuel(53.2);
            //Act
            double NeededFuel = (distance / 100) * car.FuelConsumption;
            double expectedFuelAmount = car.FuelCapacity - NeededFuel;
            car.Drive(distance);
            double actualFuelAmount = car.FuelAmount;
            //Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);

        }
    }
}