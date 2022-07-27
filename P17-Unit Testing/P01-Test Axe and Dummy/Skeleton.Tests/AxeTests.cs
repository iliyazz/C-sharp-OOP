using NUnit.Framework;

namespace Skeleton.Tests
{
    using System;

    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeShouldLooseDurabilityAfterAttack()
        {
            Axe axe = new Axe(12, 13);
            Dummy dummy = new Dummy(20, 15);
            axe.Attack(dummy);
            Assert.AreEqual(12, axe.DurabilityPoints, "Axe Durabilty doesn't change after attack.");
        }
        [Test]
        public void AttackWithBrokenWeaponShouldThrowException()
        {
            Axe axe = new Axe(12, 1);
            Dummy dummy = new Dummy(50, 30);
            axe.Attack(dummy);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            }, "Axe is broken.");
        }
        [Test]
        public void TestConstructor()
        {
            int expectedAttakPoints = 12;
            int expectedDurabilityPoints = 15;
            Axe axe=new Axe(12, 15);
            Assert.AreEqual(expectedAttakPoints, axe.AttackPoints, "Axe constructor should initialize data field correctly.");
            Assert.AreEqual(expectedDurabilityPoints, axe.DurabilityPoints, "Axe constructor should initialize data field correctly.");

        }
    }
}