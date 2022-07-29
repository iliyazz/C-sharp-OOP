namespace DatabaseExtended.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void AddingNewPersonWithExistingNameShouldThrowException()
        {
            //Arrange
            Database db = new Database();
            //Act
            db.Add(new Person(3569433191, "Gosho"));
            db.Add(new Person(389463131, "Pesho"));
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(68461346338446, "Pesho"));
            }, "There is already user with this username!");
        }

        [Test]
        public void AddingNewPersonWithExistingIdShouldThrowException()
        {
            //Arrange
            Database db = new Database();
            //Act
            db.Add(new Person(3569433191, "Gosho"));
            db.Add(new Person(389463131, "Pesho"));
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(389463131, "Dido"));
            }, "There is already user with this Id!");
        }

        [Test]
        public void AddingNewPersonOverCountLimitShouldThrowException()
        {
            //Arrange
            var database = new Database();
            //Act
            for (int i = 0; i < 16; i++)
            {
                var sb = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                database.Add(new Person(3684635168 + i, sb.ToString()));
            }
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(64668464688, "Gosho"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddingRangeCountOfPeopleOverLomitShouldThrowException()
        {
            //Arrange
            var people = new Person[25];
            //act
            for (int i = 0; i <= 24; i++)
            {
                var sb = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                people[i] = new Person(64668464688 + i, sb.ToString());
            }
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                new Database(people);
            }, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void AddingRangeCountOfPeopleShouldReturnCorrectCount()
        {
            //Arrange
            var people = new Person[12];
            //Act
            for (int i = 0; i < 12; i++)
            {
                var sb = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                people[i] = new Person(64668464688 + i, sb.ToString());
            }
            long actualCount = people.Length;
            long expectedCount = 12;
            //Assert
            Assert.AreEqual(expectedCount, actualCount, "AddRange must return correct count!");
        }

        [Test]
        public void RemoveShouldRemoveElementAndReturnCorrectCount()
        {
            //Arrange
            var db = new Database();
            //Act
            for (int i = 0; i < 15; i++)
            {
                var sb = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                db.Add(new Person(64668464688 + i, sb.ToString()));
            }
            db.Remove();
            db.Remove();
            db.Remove();
            //Assert
            Assert.AreEqual(12, db.Count, "Remove must return correct count!");
        }

        [Test]
        public void RemoveShouldThrowExceptionIfDatabaseIsEmpty()
        {
            //Arrange
            var db = new Database(new Person[0]);
            //Act, Assert
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }


        [Test]
        public void FindByUsernameShouldReturnCorrectPerson()
        {
            //Arrange
            var db = new Database();
            //Act
            for (int i = 0; i < 14; i++)
            {
                var sb = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                db.Add(new Person(86866323451 + i, sb.ToString()));
            }
            var pesho = db.FindByUsername("Pesho5");
            var peshoCheck = new Person(86866323456, "Pesho5");
            //Assert
            Assert.AreEqual(peshoCheck.UserName, pesho.UserName);
            Assert.AreEqual(peshoCheck.Id, pesho.Id);
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenReceiveCorrectButCaseSensitiveName()
        {

            //Arrane
            var db = new Database();
            //Act
            for (int i = 0; i < 15; i++)
            {
                var sb = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                db.Add(new Person(23468786 + i, sb.ToString()));
            }
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername("pesho8");
            }, "No user is present by this username!");
        }


        [Test]
        public void FindByUsernameShouldThrowExceptionWhenReceiveNullOrEmptyStringName()
        {
            //Arrangr
            var db = new Database();
            //Act
            for (int i = 0; i < 10; i++)
            {
                var sb = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                db.Add(new Person(68681656484 + i, sb.ToString()));
            }
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(null);
            }, "Username parameter is null!");
        }


        [Test]
        public void FindByUsernameShouldThrowExceptionWhenReceiveNotExistingName()
        {
            //Arange
            var db = new Database();
            //Act
            for (int i = 0; i < 13; i++)
            {
                var sb = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                db.Add(new Person(3546835697 + i, sb.ToString()));
            }
            //Assert
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Gosho"));
        }


        [Test]
        public void FindByIdShouldReturnCorrectPerson()
        {
            //Arrange
            var db = new Database();
            //Act
            for (int i = 0; i < 13; i++)
            {
                var sb = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                db.Add(new Person(943548435456 + i, sb.ToString()));
            }
            var pesho = db.FindById(943548435460);
            //Assert
            Assert.AreEqual(943548435460, pesho.Id);
        }


        [Test]
        public void FindByIdShouldThrowExceptionWhenReceiveNegativeId()
        {
            //Arrange
            var db = new Database();
            //Act
            for (int i = 0; i < 10; i++)
            {
                var sb = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                db.Add(new Person(943548435460 + i, sb.ToString()));
            }
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(-943548435460);
            }, "Id should be a positive number!");

        }


        [Test]
        public void FindByIdShouldThrowExceptionWhenReceiveNotExistingId()
        {
            //Arrange
            var db = new Database();
            //Act
            for (int i = 0; i < 10; i++)
            {
                var sb = new StringBuilder();
                sb.Append("Pesho");
                sb.Append(i);
                db.Add(new Person(9863458648468 + i, sb.ToString()));
            }
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(943548435460);
            }, "No user is present by this ID!");

        }

    }
}