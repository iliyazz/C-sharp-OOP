using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    using System;

    [TestFixture]
    public class SmartphoneShopTests
    {

        [TestCase(-20)]
        [TestCase(-1)]
        public void CapacityShouldThroeExceptionIfValueIsLessThanZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(capacity);

            }, "Invalid capacity.");
        }

        [Test]
        public void capacityShouldReturnCorretValue()
        {
            const int capacity = 10;
            Shop shop = new Shop(capacity);
            Assert.AreEqual(capacity, shop.Capacity);
        }

        [Test]
        public void CountShouldreturnCorrectValue()
        {
            Shop shop = new Shop(10);
            Smartphone phone1 = new Smartphone("model1", 1500);
            Smartphone phone2 = new Smartphone("model2", 2000);
            Smartphone phone3 = new Smartphone("model3", 2500);
            shop.Add(phone1);
            shop.Add(phone2);
            shop.Add(phone3);
            int expectedCount = 3;
            int actualCount = shop.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionIfPhoneModelExistInCollection()
        {
            Shop shop = new Shop(10);
            Smartphone phone1 = new Smartphone("model1", 1500);
            Smartphone phone2 = new Smartphone("model2", 2000);
            Smartphone phone3 = new Smartphone("model3", 2500);
            shop.Add(phone1);
            shop.Add(phone2);
            shop.Add(phone3);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone1);
            }, $"The phone model {phone1.ModelName} already exist.");
        }

        [Test]
        public void AddShouldThrowExceptionIfNoEnoughCapacity()
        {
            Shop shop = new Shop(2);
            Smartphone phone1 = new Smartphone("model1", 1500);
            Smartphone phone2 = new Smartphone("model2", 2000);
            Smartphone phone3 = new Smartphone("model3", 2500);
            shop.Add(phone1);
            shop.Add(phone2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone3);
            }, "The shop is full.");
        }

        [Test]
        public void RemoveShouldThrowExceptionIfPhoneModelDoesNotExistInCollection()
        {
            Shop shop = new Shop(10);
            Smartphone phone1 = new Smartphone("model1", 1500);
            Smartphone phone2 = new Smartphone("model2", 2000);
            Smartphone phone3 = new Smartphone("model3", 2500);
            shop.Add(phone1);
            shop.Add(phone2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove(phone3.ModelName);
            }, $"The phone model {phone3.ModelName} doesn't exist.");
        }

        [Test]
        public void RemoveShouldThrowRemovePhoneFromCollection()
        {
            Shop shop = new Shop(10);
            Smartphone phone1 = new Smartphone("model1", 1500);
            Smartphone phone2 = new Smartphone("model2", 2000);
            Smartphone phone3 = new Smartphone("model3", 2500);
            shop.Add(phone1);
            shop.Add(phone2);
            shop.Add(phone3);
            shop.Remove(phone1.ModelName);
            int expectedCountOfCollectoin = 2;
            int actualCpountFoCollection = shop.Count;
            Assert.AreEqual(expectedCountOfCollectoin, actualCpountFoCollection);
        }

        [Test]
        public void TestPhoneShouldThrowExceptionIfPhoneDoesNotExistInCollection()
        {
            Shop shop = new Shop(10);
            Smartphone phone1 = new Smartphone("model1", 1500);
            Smartphone phone2 = new Smartphone("model2", 2000);
            shop.Add(phone1);
            shop.Add(phone2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("model3", 3000);
            }, $"The phone model {"model3"} doesn't exist.");
        }

        [Test]
        public void TestPhoneShouldThrowExceptionIfLowBattery()
        {
            Shop shop = new Shop(10);
            Smartphone phone1 = new Smartphone("model1", 1500);
            Smartphone phone2 = new Smartphone("model2", 2000);
            shop.Add(phone1);
            shop.Add(phone2);
            int currentBatteryUsage = 1000;
            int currentBateryCharge = 500;
            phone1.CurrentBateryCharge = currentBateryCharge;
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("model1", currentBatteryUsage);
            }, $"The phone model {phone1.ModelName} is low on batery.");
        }

        [Test]
        public void TestPhoneShouldReturnCorrectCurrentBatteryCharge()
        {
            Shop shop = new Shop(10);
            Smartphone phone1 = new Smartphone("model1", 1500);
            Smartphone phone2 = new Smartphone("model2", 2000);
            shop.Add(phone1);
            shop.Add(phone2);
            int currentBatteryUsage = 300;
            phone1.CurrentBateryCharge = 1000;
            int expectedCurrenBatterCharge = 700;
            shop.TestPhone("model1", currentBatteryUsage);
            int actualCurrenBatteryCharge = phone1.CurrentBateryCharge;
            Assert.AreEqual(expectedCurrenBatterCharge, actualCurrenBatteryCharge);
        }

        [Test]
        public void ChargePhoneShouldThrowExceptionIfPhoneModelDoesNotExistInCollection()
        {
            Shop shop = new Shop(10);
            Smartphone phone1 = new Smartphone("model1", 1500);
            Smartphone phone2 = new Smartphone("model2", 2000);
            shop.Add(phone1);
            shop.Add(phone2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("model3");
            }, $"The phone model {"model3"} doesn't exist.");
        }

        [Test]
        public void ChargePhoneShouldReturnCorrectCurrentBatteryCharge()
        {
            Shop shop = new Shop(10);
            Smartphone phone1 = new Smartphone("model1", 1500);
            Smartphone phone2 = new Smartphone("model2", 2000);
            phone1.CurrentBateryCharge = 1000;
            shop.Add(phone1);
            shop.Add(phone2);
            int expectedCurrentBatteryCharge = 1500;
            shop.ChargePhone("model1");
            Assert.AreEqual(expectedCurrentBatteryCharge, phone1.CurrentBateryCharge);
        }


    }
}