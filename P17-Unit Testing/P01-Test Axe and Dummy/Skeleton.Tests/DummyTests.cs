using NUnit.Framework;

namespace Skeleton.Tests
{
    using System;

    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void TestIfDummyLosesHealthIfAttacked()
        {
            //Arrange
            int attackPoint = 20;
            int dummyHealth = 50;
            Dummy dummy = new Dummy(dummyHealth, 80);

            //Act
            dummy.TakeAttack(attackPoint);
            int actualDummyhealth = dummy.Health;
            int expectedDummyhealth = dummyHealth - attackPoint;

            //Assert
            Assert.AreEqual(expectedDummyhealth, actualDummyhealth, "Dummy should lose health if attacked");
        }

        [Test]
        public void DeadDummyShouldThrowsAnExceptionIfAttacked()
        {
            int dummyHealth = 10;
            int AttackPoint = 20;
            //Arrange
            Dummy dummy = new Dummy(dummyHealth, AttackPoint);

            //Act
            dummy.TakeAttack(AttackPoint);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(AttackPoint);

            }, "Dummy is dead.");

        }
        [TestCase()]
        public void DeadDummyCanGiveXP()
        {
            //Arrange
            int dummyHealth = 30;
            int AttackPoint = 40;
            int dummyExperience = 50;
            
            Dummy dummy = new Dummy(dummyHealth, dummyExperience);

            //Act
            dummy.TakeAttack(AttackPoint);

            //Assert
            Assert.AreEqual(dummyExperience, dummy.GiveExperience());
        }
        [Test]
        public void AliveDummyCantGiveXP()
        {
            //Arrange

            int dummyHealth = 30;
            int AttackPoint = 20;
            int dummyExperience = 50;
            Dummy dummy = new Dummy(dummyHealth, dummyExperience);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();

            }, "Target is not dead.");
        }



    }
}