namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        
        [Test]
        public void ConstructorShouldCreateArena()
        {
            //Arrange, Act
            var arena = new Arena();
            //Assert
            Assert.IsNotNull(arena);
            Assert.AreEqual(0, arena.Warriors.Count);
        }


        [Test]
        public void AddingWorriorToArena()
        {
            //Arrange
            var arena = new Arena();
            var warrior = new Warrior("Bestwarrior", 13, 130);
            //Act
            arena.Enroll(warrior);
            //Assert
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void AddingWarriorWithExistingNameToArenaShouldThrowInvalidOperationException()
        {
            //Arrane
            var arena = new Arena();
            var warrior = new Warrior("Bestwarrior", 60, 200);
            //Act
            arena.Enroll(warrior);
            //Assert
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Bestwarrior", 70, 130)), "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void FigthWithNonExistingWarriorShouldThrowInvalidOperationException()
        {
            //Arrange
            var arena = new Arena();
            var warrior1 = new Warrior("Warrior1", 10, 130);
            var warrior2 = new Warrior("Warrior2", 20, 140);
            var warrior3 = new Warrior("Warrior3", 30, 150);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            arena.Enroll(warrior3);
            var bestWarrior1 = new Warrior("BestWorrior", 300, 500);
            var bestWarrior2 = new Warrior("BestWorrior", 300, 500);
            //Act, Assert
            Assert.Throws<InvalidOperationException>(() => arena.Fight(bestWarrior1.Name, warrior1.Name), $"There is no fighter with name {bestWarrior1.Name} enrolled for the fights!");
            Assert.Throws<InvalidOperationException>(() => arena.Fight(warrior1.Name, bestWarrior1.Name), $"There is no fighter with name {bestWarrior1.Name} enrolled for the fights!");
            Assert.Throws<InvalidOperationException>(() => arena.Fight(bestWarrior1.Name, bestWarrior2.Name), $"There is no fighter with name {bestWarrior2.Name} enrolled for the fights!");
        }


        [Test]
        public void FigthShouldChangheTheHpCorrectlyIfAttackerAndDefenderExist()
        {
            //Arrange
            var arena = new Arena();
            var warrior1 = new Warrior("Warrior1", 10, 130);
            var warrior2 = new Warrior("Warrior2", 20, 200);
            var warrior3 = new Warrior("Warrior3", 150, 300);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            arena.Enroll(warrior3);
            //Act
            arena.Fight(warrior1.Name, warrior2.Name);
            arena.Fight(warrior3.Name, warrior1.Name);
            //Assert
            Assert.AreEqual(190, warrior2.HP);
            Assert.AreEqual(0, warrior1.HP);
        }
    }
}
