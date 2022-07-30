namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using NUnit.Framework.Internal;

    [TestFixture]
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        [Test]
        public void ConstructorShouldCreateWarrior()
        {
            //Arrange, Act
            var warrior = new Warrior("Bestwarrior", 80, 130);
            //Assert
            Assert.That(warrior, Is.Not.Null);
        }


        [Test]
        public void CheckingProperties()
        {
            //Arrange, Act
            var warrior1 = new Warrior("Bestwarrior", 80, 130);
            var warrior2 = new Warrior("Bestwarrior", 80, 130);
            //Assert
            Assert.AreEqual(warrior1.Name, warrior2.Name);
            Assert.AreEqual(warrior1.Damage, warrior2.Damage);
            Assert.AreEqual(warrior1.HP, warrior2.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("          ")]
        public void CreatingWarriorWithNullOrWhiteSpacesNameShouldThrowArgumentException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 80, 130), "Name should not be empty or whitespace!");
        }


        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(0)]
        public void CreatingWarriorWithNonPositiveDamageShouldThrowArgumentException(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Bestwarrior", damage, 130), "Damage value should be positive!");
        }


        [TestCase(-10)]
        [TestCase(-1)]
        public void CreatingWarriorWithNegativeHpShouldThrowArgumentException(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Bestwarrior", 13, hp), "HP should not be negative!");
        }

        [TestCase(20)]
        [TestCase(29)]
        [TestCase(MIN_ATTACK_HP)]
        public void AttackerHpShouldBeAtLeast30ToAttackOtherWarriorsOtherwiseThrowInvalidOperationException(int hpWarrior1)
        {
            //Arrange
            var warrior1 = new Warrior("Bestwarrior", 13, hpWarrior1);
            var warrior2 = new Warrior("Bestwarrior", 13, 50);
            //Act, Assert
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2), "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(20)]
        [TestCase(29)]
        [TestCase(MIN_ATTACK_HP)]
        public void EnemyHpShouldBeAtLeast30ToAttackOtherWarriorsOtherwiseThrowInvalidOperationException(int hpWarrior2)
        {
            //Arrange
            var warrior1 = new Warrior("Bestwarrior", 13, 50);
            var warrior2 = new Warrior("Bestwarrior", 13, hpWarrior2);
            //Act, Assert
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2), $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }


        [TestCase(15)]
        [TestCase(37)]
        [TestCase(38)]
        public void AttackingTooStrongEnemyShouldThrowInvalidOperationException(int hpWarrior1)
        {
            //Arrange
            var warrior1 = new Warrior("Bestwarrior", 39, hpWarrior1);
            var warrior2 = new Warrior("Bestwarrior", 39, 50);
            //Act, Assert
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2), "You are trying to attack too strong enemy");
        }


        [TestCase(40, 100)]
        [TestCase(40, 50)]
        [TestCase(40, 40)]
        [TestCase(40, 39)]
        [TestCase(40, 31)]
        public void AttackingShouldDecreaseEnemyHp(int damageWarrior1, int hpWarrior2)
        {
            //Arrange
            var warrior1 = new Warrior("Bestwarrior", damageWarrior1, 130);
            var warrior2 = new Warrior("Bestwarrior", 15, hpWarrior2);
            //Act
            int exceptedHp2 = damageWarrior1 > hpWarrior2 ?  0 :  hpWarrior2 - damageWarrior1;
            warrior1.Attack(warrior2);
            int actualWarriorHp2 = warrior2.HP;
            //Assert
            Assert.AreEqual(exceptedHp2, actualWarriorHp2, "HP shold be reduced correcrly after atack!");
        }
    }
}