namespace Database.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db = new Database();

        [SetUp]
        public void Setup()
        {
            this.db = new Database();
        }


        [TestCase(new int[] {})]
        [TestCase(new int[] {1})]
        [TestCase(new int[] {1, 2, 3})]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void ConstructorShouldAddLessThan16Elements(int[] elementsToAdd)
        {
            //Arrange
            Database testDatabase = new Database(elementsToAdd);

            //Act
            int[] actualData = testDatabase.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = testDatabase.Count;
            int expectedCount = expectedData.Length;

            //Assert
            CollectionAssert.AreEqual(expectedData, actualData, "Database constructor should initialize field correctly");
            Assert.AreEqual(expectedCount, actualCount, "Constructor should set initial value for count field");

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17})]
        public void ConstructorMustNotAllowToExceedMaxCount(int[] elementsToAdd)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database testDatabase = new Database(elementsToAdd);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void CountMustReturnActualCount()
        {
            int[] initData = new int[]{1, 2, 3};
            Database testDatabase = new Database(initData);
            int actualCount= testDatabase.Count;
            int expectedCount = initData.Length;
            Assert.AreEqual(expectedCount, actualCount, "Count should return the count of the added elements.");
        }

        [Test]
        public void CountMustReturnZeroWhenNoElements()
        {
            int actualCount = this.db.Count;
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, actualCount, "Count should be zero when there are no elements in the database.");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddShouldAddLessThem16Elements(int[] elementsToAdd)
        {
            //act
            foreach (var el in elementsToAdd)
            {
                this.db.Add(el);
            }

            int[] actualData = this.db.Fetch();
            int[] expectedData = elementsToAdd;

            int actualCount = this.db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData, "Add should physically add elements to the field");
            Assert.AreEqual(expectedCount, actualCount, "Add should increment the elements count  when adding.");
        }

        [Test]
        public void AddShouldThrowAnExceptionWhenAddingMorThan16Elements()
        {
            //Act
            for (int i = 0; i < 16; i++)
            {
                   this.db.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] {1})]
        [TestCase(new int[] {1, 2, 3, 4, 5 })]
        public void RemoveShouldRemoveTheLastElementSuccessfully(int[] startElements)
        {
            //Act
            foreach (var el in startElements)
            {
               this. db.Add(el);
            }
            this.db.Remove();
            IList<int> dbStartList = new List<int>(startElements);
            dbStartList.RemoveAt(dbStartList.Count - 1);
            int[] actualData = this.db.Fetch();
            int[] expectedData = dbStartList.ToArray();
            int actualCount= this.db.Count;
            int expectedCount = expectedData.Length;
            CollectionAssert.AreEqual(expectedData, actualData, "Remove should physicaly remove the element in the field");
            Assert.AreEqual(expectedCount, actualCount, "Remove should decrement the count of the database");
        }

        [Test]
        public void RemoveShouldRemoveTheLastElementMultipleTimes()
        {
            List<int> dbStartList = new List<int>(){1, 2, 3};
            foreach (var element in dbStartList)
            {
                this.db.Add(element);
            }

            for (int i = 0; i < dbStartList.Count; i++)
            {
                this.db.Remove();
            }

            int[] actualData = this.db.Fetch();
            int[] expectedData = new int[] { };
            int actualCount = this.db.Count;
            int expectedCount= 0;

            CollectionAssert.AreEqual(expectedData, actualData, "Remove should physicaly remove the element in the field");
            Assert.AreEqual(expectedCount, actualCount, "Remove should decrement the count of the database");
        }

        [Test]
        public void RemoveShouldThrowErrorWhenThereNoElements()
        {
            Assert.Throws<InvalidOperationException>(() => this.db.Remove(), "The collection is empty!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCopyOfArray(int[] initElements)
        {
            //Act
            foreach (var el in initElements)
            {
                this.db.Add(el);
            }
            int[] actualResult = this.db.Fetch();
            int[] expectedResult = initElements;
            CollectionAssert.AreEqual(expectedResult, actualResult, "Fecth should return Copy of existing data!");


        }
    }
    
}
